using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECE.Core.Messages
{
    public abstract class Command : Message
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
