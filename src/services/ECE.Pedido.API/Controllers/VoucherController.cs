using ECE.WebAPI.Core.Controller;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ECE.Pedido.API.Controllers
{
    [Authorize]
    public class VoucherController : MainController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
