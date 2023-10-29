using FluentValidation.Results;
using MediatR;
using System;

namespace ECE.Core.Messages
{
    public abstract class Command : Message, IRequest<ValidationResult>
    {
        public DateTime TimesStamp { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public Command()
        {
            TimesStamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
