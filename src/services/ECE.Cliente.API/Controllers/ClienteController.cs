using ECE.Cliente.API.Application.Commands;
using ECE.Cliente.API.Models;
using ECE.Core.Mediator;
using ECE.WebAPI.Core.Controller;
using ECE.WebAPI.Core.Usuario;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ECE.Cliente.API.Controllers
{
    public class ClienteController : MainController
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMediatorHandler _mediator;
        private readonly IAspNetUser _user;

        public ClienteController(IMediatorHandler mediator,
            IAspNetUser user,
            IClienteRepository clienteRepository)
        {
            _mediator = mediator;
            _user = user;
            _clienteRepository = clienteRepository;
        }

        [HttpGet("cliente/endereco")]
        public async Task<IActionResult> ObterEndereco()
        {
            var endereco = await _clienteRepository.ObterEnderecoPorId(_user.ObterUserId());

            return endereco == null ? NotFound() : CustomResponse(endereco);
        }

        [HttpGet("cliente/endereco")]
        public async Task<IActionResult> AdicionarEndereco(AdicionarEnderecoCommand endereco)
        {
            endereco.ClienteId = _user.ObterUserId();

            return CustomResponse(await _mediator.EnviarComando(endereco));
        }

        [HttpGet("clientes")]
        public async Task<IActionResult> Index()
        {
            var resultado = await _mediator.EnviarComando(new RegistrarClienteCommand(
                Guid.NewGuid(), "Wesley", "wesleybf3@gmail.com", "02965358005"));
                       

            return CustomResponse(resultado);
        }
    }
}
