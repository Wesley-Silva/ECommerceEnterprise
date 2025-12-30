using ECE.Core.Data;
using ECE.Pedido.Domain;

namespace ECE.Pedido.Infra.Data.Repository
{
    public class VoucherRepository : IVoucherRepository
    {
        private readonly PedidoContext _context;

        public VoucherRepository(PedidoContext context)
        {
            _context = context;
        }

        public IUnitOfWork unitOfWork => (IUnitOfWork)_context;

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
