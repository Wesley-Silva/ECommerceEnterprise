using ECE.BFF.Compras.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;

namespace ECE.BFF.Compras.Services
{
    public interface ICarrinhoService
    {

    }

    public class CarrinhoService : ICarrinhoService
    {
        private readonly HttpClient _httpClient;

        public CarrinhoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.CarrinhoUrl);
        }
    }
}
