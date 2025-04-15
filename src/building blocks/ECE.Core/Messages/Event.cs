using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECE.Core.Messages
{
    public class Event : Message, INotification
    {
        public DateTime Timestamp { get; set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
