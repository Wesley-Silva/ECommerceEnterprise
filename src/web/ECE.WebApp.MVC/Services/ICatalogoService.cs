using ECE.WebApp.MVC.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECE.WebApp.MVC.Services
{
    public interface ICatalogoService
    {
        Task<IEnumerable<ProdutoViewModel>> ObterTodos(); 
        Task<ProdutoViewModel> ObterPorId(Guid id);
    }
}
