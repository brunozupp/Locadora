using Locadora.Domain.Commands.Inputs.Usuario;
using Locadora.Domain.Commands.Outputs;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Infra.Interfaces.Commands;

namespace Locadora.Domain.Handlers
{
    public class UsuarioHandler : ICommandHandler<AdicionarUsuarioCommand>, ICommandHandler<AtualizarUsuarioCommand>,
        ICommandHandler<ExcluirUsuarioCommand>
    {

        private readonly IUsuarioRepository _repository;

        public UsuarioHandler(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AtualizarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new UsuarioCommandResult(false, "Possui erro de validações", command.Notifications);

                if (!_repository.CheckId(command.Id))
                    return new UsuarioCommandResult(false, "Este usuário não existe.", command.Notifications);

                Usuario usuario = new Usuario(command.Id, command.Nome, command.Login, command.Senha);

                _repository.Atualizar(usuario);

                return new UsuarioCommandResult(true, "Usuário atualizado com sucesso.", usuario);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(AdicionarUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new UsuarioCommandResult(false, "Possui erro de validações", command.Notifications);

                long id = 0;

                Usuario usuario = new Usuario(id, command.Nome, command.Login, command.Senha);

                id = _repository.Inserir(usuario);

                usuario.AtualizarId(id);

                return new UsuarioCommandResult(true, "Usuário cadastrado com sucesso!", new
                {
                    Nome = usuario.Nome,
                    Login = usuario.Login
                });
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(ExcluirUsuarioCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new UsuarioCommandResult(false, "Possui erro de validações", command.Notifications);

                if (!_repository.CheckId(command.Id))
                    return new UsuarioCommandResult(false, "Este usuário não existe.", command.Notifications);

                _repository.Excluir(command.Id);

                return new UsuarioCommandResult(true, "Usuário excluído com sucesso", new
                {
                    Id = command.Id
                });
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
