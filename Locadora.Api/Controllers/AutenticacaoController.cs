using Locadora.Domain.Commands.Inputs.Autenticacao;
using Locadora.Domain.Handlers;
using Locadora.Infra.Interfaces.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Locadora.Api.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly AutenticacaoHandler _handler;

        public AutenticacaoController(AutenticacaoHandler handler)
        {
            _handler = handler;
        }

        [HttpPost]
        [Route("signin")]
        public ICommandResult Autenticar([FromBody] AutenticacaoCommand command)
        {
            return _handler.Handle(command);
        }
    }
}
