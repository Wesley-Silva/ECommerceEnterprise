using ECE.Core.Mediator;
using ECE.Pedido.API.Application.Queries;
using ECE.Pedido.Domain;
using ECE.Pedido.Infra.Data;
using ECE.Pedido.Infra.Data.Repository;
using ECE.WebAPI.Core.Usuario;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace ECE.Pedido.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // API
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IAspNetUser, AspNetUser>();
                        
            // Application
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IVoucherQueries, VoucherQueries>();

            // Data          
            services.AddScoped<IVoucherRepository, VoucherRepository>();
            services.AddScoped<PedidosContext>();
        }
    }
}
