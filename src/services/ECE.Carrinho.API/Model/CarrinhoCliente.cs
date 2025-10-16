using System;
using System.Collections.Generic;
using System.Linq;

namespace ECE.Carrinho.API.Model
{
    public class CarrinhoCliente
    {
        internal const int MAX_QUANTIDADE_ITEM = 5;

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

        internal void CalcularValorCarrinho()
        {
            ValorTotal = Items.Sum(p => p.CalcularValor());
        }

        internal bool CarrinhoItemExistente(CarrinhoItem item)
        {
            return Items.Any(p => p.ProdutoId == item.ProdutoId);
        }

        internal CarrinhoItem ObterProdutoId(Guid produtoId)
        {
            return Items.FirstOrDefault(p => p.ProdutoId == produtoId);
        }

        internal void AdicionarItem(CarrinhoItem item)
        {
            if (!item.EhValido())
            {
                return;
            }

            item.AssociarCarrinho(Id);

            if (CarrinhoItemExistente(item))
            {
                var itemExistente = ObterProdutoId(item.ProdutoId);
                itemExistente.AdicionarUnidades(item.Quantidade);

                item = itemExistente;
                Items.Remove(itemExistente);
            }

            Items.Add(item);

            CalcularValorCarrinho();
        }

        internal void AtualizarItem(CarrinhoItem item)
        {
            if (!item.EhValido())
            {
                return;
            }

            item.AssociarCarrinho(Id);

            var itemExistente = ObterProdutoId(item.ProdutoId);

            Items.Remove(itemExistente);
            Items.Add(item);

            CalcularValorCarrinho();
        }

        internal void AtualizarUnidades(CarrinhoItem item, int unidades)
        {
            item.AtualizarUnidades(unidades);
            AtualizarItem(item);
        }

        internal void RemoverItem(CarrinhoItem item)
        {
            Items.Remove(ObterProdutoId(item.ProdutoId));
            CalcularValorCarrinho();
        }
    }
}
