using ECE.Cliente.API.Application.Commands;
using ECE.Core.Mediator;
using ECE.WebAPI.Core.Controller;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ECE.Cliente.API.Controllers
{
    public class ClienteController : MainController
    {
        private readonly IMediatorHandler _mediatorHandler;

        public ClienteController(IMediatorHandler mediatorHandler)
        {
            _mediatorHandler = mediatorHandler;
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            var resultado = await _mediatorHandler.EnviarComando(new RegistrarClienteCommand(
                Guid.NewGuid(), "Wesley", "wesleybf3@gmail.com", "02965358005"));
                       

            return CustomResponse(resultado);
        }
    }
}
