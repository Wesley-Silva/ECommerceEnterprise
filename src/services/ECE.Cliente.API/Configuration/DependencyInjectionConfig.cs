using ECE.Cliente.API.Application.Commands;
using ECE.Cliente.API.Application.Events;
using ECE.Cliente.API.Data;
using ECE.Cliente.API.Data.Repository;
using ECE.Cliente.API.Models;
using ECE.Cliente.API.Services;
using ECE.Core.Mediator;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ECE.Cliente.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();

            services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<ClientesContext>();

            services.AddHostedService<RegistroClienteIntegrationHandler>();
        }
    }
}