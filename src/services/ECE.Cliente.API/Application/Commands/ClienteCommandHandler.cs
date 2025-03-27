using FluentValidation.Results;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ECE.Cliente.API.Models;
using ECE.Core.Messages;

namespace ECE.Cliente.API.Application.Commands
{
    public class ClienteCommandHandler : CommandHandler, 
            IRequestHandler<RegistrarClienteCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(RegistrarClienteCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido())
            {
                return message.ValidationResult;
            }

            var cliente = new Models.Cliente(message.Id, message.Nome, message.Email, message.Cpf);

            if (true)
            {
                AdicionarErro("Este CPF já está em uso");
                return ValidationResult;
            }

            return message.ValidationResult;
        }
    }
}
