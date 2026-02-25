using ECE.Core.Data;
using ECE.Pedido.Domain;
using ECE.Pedido.Domain.Vouchers;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ECE.Pedido.Infra.Data.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly PedidosContext _context;

        public VoucherRepository(PedidosContext context)
        {
            _context = context;
        }

        public IUnitOfWork unitOfWork => (IUnitOfWork)_context;

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Voucher> ObterVoucherPorCodigo(string codigo)
        {
            return await _context.Vouchers.FirstOrDefaultAsync(c => c.Codigo == codigo);
        }
    }
}
