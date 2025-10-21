using ECE.WebApp.MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ECE.WebApp.MVC.Controllers
{
    public class CarrinhoController : Controller
    {
        [Route("carrinho")]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        [Route("carrinho/adicionar-item")]
        public async Task<ActionResult> AdicionarItemCarrinho(ItemProdutoViewModel itemProduto)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("carrinho/adicionar-item")]
        public async Task<ActionResult> AtualizarItemCarrinho(Guid produtoId, int quantidade)
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("carrinho/remover-item")]
        public async Task<ActionResult> RemoverItemCarrinho(Guid produtoId)
        {
            return RedirectToAction("Index");
        }
    }
}
