using Locadora.Domain.Commands.Inputs.Filme;
using Locadora.Domain.Handlers;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Domain.Query;
using Locadora.Infra.Interfaces.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Locadora.Api.Controllers
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeRepository _repository;
        private readonly FilmeHandler _handler;

        public FilmesController(IFilmeRepository repository, FilmeHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        public ICommandResult InserirFilme([FromBody] AdicionarFilmeCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut("{id:long}")]
        public ICommandResult AtualizarFilme([FromRoute] long id, [FromBody] AtualizarFilmeCommand command)
        {
            command.Id = id;
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public ICommandResult ExcluirFilme([FromRoute] long id)
        {
            var command = new ExcluirFilmeCommand() { Id = id };
            return _handler.Handle(command);
        }

        [HttpGet]
        [Route("")]
        public List<FilmeQueryResult> ListarFilmes()
        {
            return _repository.Listar();
        }

        [HttpGet]
        [Route("{id:long}")]
        public FilmeQueryResult ObterFilme([FromRoute] long id)
        {
            return _repository.Obter(id);
        }
    }
}
