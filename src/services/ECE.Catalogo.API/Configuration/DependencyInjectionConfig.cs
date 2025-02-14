using ECE.Catalogo.API.Data.Repository;
using ECE.Catalogo.API.Data;
using ECE.Catalogo.API.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ECE.Catalogo.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterService(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<CatalogoContext>();
        }
    }
}