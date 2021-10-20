using Locadora.Domain.Commands.Inputs.Filme;
using Locadora.Domain.Commands.Outputs;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Infra.Interfaces.Commands;

namespace Locadora.Domain.Handlers
{
    public class FilmeHandler : ICommandHandler<AdicionarFilmeCommand>, ICommandHandler<AtualizarFilmeCommand>,
        ICommandHandler<ExcluirFilmeCommand>
    {

        private readonly IFilmeRepository _repository;

        public FilmeHandler(IFilmeRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(AdicionarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new FilmeCommandResult(false, "Possui erro de validações", command.Notifications);

                long id = 0;

                Filme filme = new Filme(id, command.Titulo, command.Diretor);

                id = _repository.Inserir(filme);

                filme.AtualizarId(id);

                return new FilmeCommandResult(true, "Filme cadastrado com sucesso!", filme);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(ExcluirFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new FilmeCommandResult(false, "Possui erro de validações", command.Notifications);

                if (!_repository.CheckId(command.Id))
                    return new FilmeCommandResult(false, "Este filme não existe.", new { });

                _repository.Excluir(command.Id);
                return new FilmeCommandResult(true, "Filme excluído com sucesso!", new { });
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public ICommandResult Handle(AtualizarFilmeCommand command)
        {
            try
            {
                if (!command.ValidarCommand())
                    return new FilmeCommandResult(false, "Possui erro de validações", command.Notifications);

                if (!_repository.CheckId(command.Id))
                    return new FilmeCommandResult(false, "Este filme não existe.", command.Notifications);

                Filme filme = new Filme(command.Id, command.Titulo, command.Diretor);

                _repository.Atualizar(filme);

                return new FilmeCommandResult(true, "Filme atualizado com sucesso!", filme);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
