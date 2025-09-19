using System;
using System.Collections.Generic;

namespace ECE.Carrinho.API.Model
{
    public class CarrinhoCliente
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public decimal ValorTotal { get; set; }

        public List<CarrinhoItem> Items { get; set; } = new List<CarrinhoItem>();

        public CarrinhoCliente(Guid clienteId)
        {
            Id = Guid.NewGuid();
            ClienteId = clienteId;
        }

        // facilita a vida do EF pois no constructor acima não tem um "Guid clienteId"
        public CarrinhoCliente()
        {            
        }
    }
}
