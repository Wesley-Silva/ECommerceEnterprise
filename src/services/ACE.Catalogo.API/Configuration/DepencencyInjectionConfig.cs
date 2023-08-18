using ACE.Catalogo.API.Data;
using ACE.Catalogo.API.Data.Repository;
using ACE.Catalogo.API.Models;
using Microsoft.Extensions.DependencyInjection;

namespace ACE.Catalogo.API.Configuration
{
    public static class DepencencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<CatalogoContext>();            
        }
    }
}
