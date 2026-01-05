using ECE.Core.Data;
using ECE.Pedido.Domain;

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
    }
}
