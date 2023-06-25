using ECE.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace ECE.WebApp.MVC.Services
{
    public interface IAutenticationService
    {
        Task<string> Login(UsuarioLogin usuarioLogin);
        Task<string> Registro(UsuarioRegistro usuarioRegistro);
    }
}
