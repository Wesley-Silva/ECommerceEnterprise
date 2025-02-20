using ECE.WebApp.MVC.Models;
using System;
using System.Collections;
using System.Threading.Tasks;

namespace ECE.WebApp.MVC.Services
{
    public interface ICatalogoService
    {
        Task<IEnumerable> ObterTodos(); 
        Task<ProdutoViewModel> ObterPorId(Guid id);
    }
}
