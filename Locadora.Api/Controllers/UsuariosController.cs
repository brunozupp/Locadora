using Locadora.Domain.Commands.Inputs.Usuario;
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
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _repository;
        private readonly UsuarioHandler _handler;

        public UsuariosController(IUsuarioRepository repository, UsuarioHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }

        [AllowAnonymous]
        [HttpPost]
        public ICommandResult InserirUsuario([FromBody] AdicionarUsuarioCommand command)
        {
            return _handler.Handle(command);
        }

        [HttpPut]
        [Route("{id:long}")]
        public ICommandResult AtualizarUsuario([FromRoute] long id, [FromBody] AtualizarUsuarioCommand command)
        {
            command.Id = id;
            return _handler.Handle(command);
        }

        [HttpDelete]
        [Route("{id:long}")]
        public ICommandResult ExcluirUsuario([FromRoute] long id)
        {
            var command = new ExcluirUsuarioCommand() { Id = id };
            return _handler.Handle(command);
        }

        [HttpGet]
        public List<UsuarioQueryResult> ListarUsuarios()
        {
            return _repository.Listar();
        }

        [HttpGet]
        [Route("{id:long}")]
        public UsuarioQueryResult ObterUsuario([FromRoute] long id)
        {
            return _repository.Obter(id);
        }
    }
}
