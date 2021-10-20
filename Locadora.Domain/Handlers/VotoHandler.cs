using Locadora.Domain.Commands.Inputs.Voto;
using Locadora.Domain.Commands.Outputs;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Infra.Interfaces.Commands;

namespace Locadora.Domain.Handlers
{
    public class VotoHandler : ICommandHandler<AdicionarVotoCommand>, ICommandHandler<ExcluirVotoCommand>
    {
        private readonly IVotoRepository _votoRepository;
        private readonly IFilmeRepository _filmeRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public VotoHandler(IVotoRepository votoRepository, IFilmeRepository filmeRepository, IUsuarioRepository usuarioRepository)
        {
            _votoRepository = votoRepository;
            _filmeRepository = filmeRepository;
            _usuarioRepository = usuarioRepository;
        }

        public ICommandResult Handle(ExcluirVotoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new VotoCommandResult(false, "Possui erro de validações", command.Notifications);

                if (!_votoRepository.CheckId(command.Id))
                    return new VotoCommandResult(false, "Este voto não existe", command.Notifications);

                if (!_filmeRepository.CheckId(command.Id))
                    return new VotoCommandResult(false, "Este filme não existe", command.Notifications);

                if (!_usuarioRepository.CheckId(command.Id))
                    return new VotoCommandResult(false, "Este usuário não existe", command.Notifications);

                _votoRepository.Excluir(command.Id);

                return new VotoCommandResult(true, "Voto excluído com sucesso!", new
                {
                    Id = command.Id
                });
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(AdicionarVotoCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new VotoCommandResult(false, "Possui erro de validações", command.Notifications);

                if (!_filmeRepository.CheckId(command.FilmeId))
                    return new VotoCommandResult(false, "Este filme não existe", command.Notifications);

                if (!_usuarioRepository.CheckId(command.UsuarioId))
                    return new VotoCommandResult(false, "Este usuário não existe", command.Notifications);

                if (_votoRepository.JaFoiVotado(command.UsuarioId, command.FilmeId))
                    return new VotoCommandResult(false, "O usuário já votou nesse filme", command.Notifications);

                long id = 0;

                Voto voto = new Voto(id, command.UsuarioId, command.FilmeId);

                id = _votoRepository.Inserir(voto);

                voto.AtualizarId(id);

                return new VotoCommandResult(true, "Voto computado com sucesso!", voto);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
