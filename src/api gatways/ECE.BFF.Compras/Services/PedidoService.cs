using ECE.BFF.Compras.Extensions;
using Microsoft.Extensions.Options;
using System;
using System.Net.Http;

namespace ECE.BFF.Compras.Services
{
    public interface IPedidoService
    {

    }

    public class PedidoService : IPedidoService
    {
        private readonly HttpClient _httpClient;

        public PedidoService(HttpClient httpClient, IOptions<AppServicesSettings> settings)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(settings.Value.PedidoUrl);
        }
    }
}
