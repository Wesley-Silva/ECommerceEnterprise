using NetDevPack.Specification;

namespace ECE.Pedido.Domain.Vouchers.Specs
{
    public class VoucherValidation : SpecValidator<Voucher>
    {
        public VoucherValidation()
        {
            var dataApec = new VoucherDataSpecification();
            var qtdeSpec = new VoucherQuantidadeSpecification();
            var ativoSpec = new VoucherAtivoSpecification();

            Add("dataSpec", new Rule<Voucher>(dataApec, "Este voucher está expirado"));
            Add("qtdeSpec", new Rule<Voucher>(qtdeSpec, "Este voucher já foi utilizado"));
            Add("ativoSpec", new Rule<Voucher>(ativoSpec, "Este voucher não está mais ativo"));
        }
    }
}
