using ECE.WebAPI.Core.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECE.BFF.Compras.Controllers
{
    [Authorize]
    public class CarrinhoController : MainController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
