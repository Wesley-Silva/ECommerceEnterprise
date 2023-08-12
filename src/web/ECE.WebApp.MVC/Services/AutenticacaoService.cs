using ECE.WebApp.MVC.Models;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECE.WebApp.MVC.Services
{
    public class AutenticationService : Service, IAutenticationService
    {
        private readonly HttpClient _httpClient;

        public AutenticationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<UsuarioRespostaLogin> Login(UsuarioLogin usuarioLogin)
        {
            var loginContent = ObterConteudo(usuarioLogin);

            var response = await _httpClient.PostAsync("https://localhost:44312/api/identidade/autenticar", loginContent);

            //var teste = await response.Content.ReadAsStringAsync();                      

            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }
            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }

        public async Task<UsuarioRespostaLogin> Registro(UsuarioRegistro usuarioRegistro)
        {
            var registroContent = ObterConteudo(usuarioRegistro);

            var response = await _httpClient.PostAsync("https://localhost:44312/api/identidade/nova-conta", registroContent);
             
            if (!TratarErrosResponse(response))
            {
                return new UsuarioRespostaLogin
                {
                    ResponseResult = await DeserializarObjetoResponse<ResponseResult>(response)
                };
            }
            return await DeserializarObjetoResponse<UsuarioRespostaLogin>(response);
        }
    }
}
