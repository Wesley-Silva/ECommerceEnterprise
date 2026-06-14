using ECE.WebApp.MVC.Models;
using ECE.WebApp.MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ECE.WebApp.MVC.Controllers
{
    [Authorize]
    public class PedidoController : MainController
    {
        private readonly IClienteService _clienteService;
        private readonly IComprasBffService _comprasBffService;

        public PedidoController(IComprasBffService comprasBffService, IClienteService clienteService)
        {
            _comprasBffService = comprasBffService;
            _clienteService = clienteService;
        }

        [HttpGet]
        [Route("endereco-de-entrega")]
        public async Task<ActionResult> EnderecoEntrega(ItemCarrinhoViewModel itemCarrinho)
        {
            var carrinho = await _comprasBffService.ObterCarrinho();
            if (carrinho.Itens.Count == 0)
            {
                return RedirectToAction("Index", "Carrinho");
            }

            var endereco = await _clienteService.ObterEndereco();
            var pedido = _comprasBffService.MapearParaPedido(carrinho, endereco);

            return View(pedido);
        }
    }
}
