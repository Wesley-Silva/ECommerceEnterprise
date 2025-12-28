using ECE.WebApp.MVC.Models;
using ECE.WebApp.MVC.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ECE.WebApp.MVC.Controllers
{
    public class CarrinhoController : MainController
    {
        private readonly IComprasBFFService _comprasBffService;

        public CarrinhoController(IComprasBFFService comprasBffService)
        {
            _comprasBffService = comprasBffService;
        }

        [Route("carrinho")]
        public async Task<ActionResult> Index()
        {
            return View(await _comprasBffService.ObterCarrinho());
        }

        [HttpPost]
        [Route("carrinho/adicionar-item")]
        public async Task<ActionResult> AdicionarItemCarrinho(ItemCarrinhoViewModel itemCarrinho)
        {            
            var resposta = await _comprasBffService.AdicionarItemCarrinho(itemCarrinho);

            if (ResponsePossuiErros(resposta))
            {
                return View("Index", await _comprasBffService.ObterCarrinho());
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("carrinho/atualizar-item")]
        public async Task<ActionResult> AtualizarItemCarrinho(Guid produtoId, int quantidade)
        {
            var item = new ItemCarrinhoViewModel
            {
                ProdutoId = produtoId,
                Quantidade = quantidade
            };

            var resposta = await _comprasBffService.AtualizarItemCarrinho(produtoId, item);

            if (ResponsePossuiErros(resposta))
            {
                return View("Index", await _comprasBffService.ObterCarrinho());
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("carrinho/remover-item")]
        public async Task<ActionResult> RemoverItemCarrinho(Guid produtoId)
        {
            var resposta = await _comprasBffService.RemoverItemCarrinho(produtoId);

            if (ResponsePossuiErros(resposta))
            {
                return View("Index", await _comprasBffService.ObterCarrinho());
            }

            return RedirectToAction("Index");
        }
    }
}
