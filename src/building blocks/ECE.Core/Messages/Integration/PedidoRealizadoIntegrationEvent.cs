using System;
using System.Collections.Generic;
using System.Text;

namespace ECE.Core.Messages.Integration
{
    public class PedidoRealizadoIntegrationEvent : IntegrationEvent
    {
        public Guid ClienteId { get; private set; }
        public PedidoRealizadoIntegrationEvent(Guid clienteId)
        {
            ClienteId = clienteId;
        }
    }
}
