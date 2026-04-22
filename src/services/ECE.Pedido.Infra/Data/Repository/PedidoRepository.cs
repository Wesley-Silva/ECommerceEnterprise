using ECE.Core.Data;
using ECE.Pedido.Domain.Pedidos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace ECE.Pedido.Infra.Data.Repository
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidosContext _context;

        public PedidoRepository(PedidosContext context)
        {
            _context = context;
        }

        public IUnitOfWork unitOfWork => _context;

        public DbConnection ObterConexao()
        {
            return _context.Database.GetDbConnection();
        }

        public async Task<Domain.Pedidos.Pedido> ObterPedidoId(Guid id)
        {
            return await _context.Pedidos.FindAsync(id);
        }

        public async Task<IEnumerable<Domain.Pedidos.Pedido>> ObterListaPorClienteId(Guid clienteId)
        {
            return await _context.Pedidos
                .Include(p => p.PedidoItems)
                .AsNoTracking().Where(p => p.ClienteId == clienteId)
                .ToListAsync();
        }

        public void Adicionar(Domain.Pedidos.Pedido pedido)
        {
            _context.Pedidos.Add(pedido);
        }

        public void Atualizar(Domain.Pedidos.Pedido pedido)
        {
            _context.Pedidos.Update(pedido);
        }
        
        public async Task<PedidoItem> ObterItemPorId(Guid id)
        {
            return await _context.PedidoItems.FindAsync(id);
        }

        public async Task<PedidoItem> ObterItemPorPedido(Guid pedidoId, Guid produtoId)
        {
            return await _context.PedidoItems
                .FirstOrDefaultAsync(p => p.ProdutoId == produtoId && p.PedidoId == pedidoId);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
