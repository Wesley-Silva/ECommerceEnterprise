using ACE.Clientes.API.Application.Commands;
using ACE.Clientes.API.Data;
using ECE.Core.Mediator;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ACE.Clientes.API.Configuration
{
    public static class DepencencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();

            services.AddScoped<ClientesContext>();
        }
    }
}
