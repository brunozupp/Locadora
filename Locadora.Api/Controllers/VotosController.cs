using Locadora.Domain.Commands.Inputs.Voto;
using Locadora.Domain.Handlers;
using Locadora.Domain.Interfaces.Repositories;
using Locadora.Domain.Query;
using Locadora.Infra.Interfaces.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Locadora.Api.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class VotosController : ControllerBase
    {
        private readonly IVotoRepository _repository;
        private readonly VotoHandler _handler;

        public VotosController(IVotoRepository repository, VotoHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [HttpPost]
        public ICommandResult InserirVoto([FromBody] AdicionarVotoCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public ICommandResult ExcluirVoto(long id)
        {
            return _handler.Handle(new ExcluirVotoCommand() { Id = id });
        }

        [HttpGet]
        public List<VotoQueryResult> ListarVotos()
        {
            return _repository.Listar();
        }
    }
}
