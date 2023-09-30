using ACE.Clientes.API.Data;
using Microsoft.Extensions.DependencyInjection;

namespace ACE.Clientes.API.Configuration
{
    public static class DepencencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ClientesContext>();
        }
    }
}
