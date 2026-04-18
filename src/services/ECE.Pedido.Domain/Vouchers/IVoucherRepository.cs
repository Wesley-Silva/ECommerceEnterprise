using ECE.Core.Data;
using ECE.Pedido.Domain;
using ECE.Pedido.Domain.Vouchers;
using System.Threading.Tasks;

namespace ECE.Pedido.Domain
{
    public interface IVoucherRepository : IRepository<Voucher>
    {
        Task<Voucher> ObterVoucherPorCodigo(string codigo);
        void Atualizar(Voucher voucher);
    }
}
