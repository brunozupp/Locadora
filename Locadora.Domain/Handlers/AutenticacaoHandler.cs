using Locadora.Domain.Commands.Inputs.Autenticacao;
using Locadora.Domain.Commands.Outputs;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Infra.Interfaces.Commands;
using Locadora.Infra.Settings;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Locadora.Domain.Handlers
{
    public class AutenticacaoHandler : ICommandHandler<AutenticacaoCommand>
    {
        private readonly IUsuarioRepository _repository;
        private readonly AppSettings _settings;

        public AutenticacaoHandler(IUsuarioRepository repository, AppSettings settings)
        {
            _repository = repository;
            _settings = settings;
        }

        public ICommandResult Handle(AutenticacaoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new AutenticacaoCommandResult(false, "Possui erro de validações", command.Notifications);

                if (!_repository.Autenticar(command.Login, command.Senha))
                    return new AutenticacaoCommandResult(false, "Login ou senha inválido.", command.Notifications);

                return new AutenticacaoCommandResult(true, "Token gerado com sucesso", GerarToken(command.Login));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object GerarToken(string login)
        {
            var claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Name, login));

            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Secret);

            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _settings.Issuer,
                Audience = _settings.Audience,
                Subject = identityClaims,
                Expires = DateTime.UtcNow.AddHours(_settings.Expiration),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            });
            var encodedToken = tokenHandler.WriteToken(token);

            return new
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_settings.Expiration).TotalSeconds
            };
        }
    }
}
