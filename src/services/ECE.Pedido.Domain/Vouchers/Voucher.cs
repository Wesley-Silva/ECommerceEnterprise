using ECE.Core.DomainObjets;
using ECE.Pedido.Domain.Specs;
using System;

namespace ECE.Pedido.Domain.Vouchers
{
    public class Voucher : Entity, IAggregateRoot
    {
        public string Codigo { get; private set; }
        public decimal? Percentual { get; private set; }
        public decimal? ValorDesconto { get; private set; }
        public int Quantidade { get; private set; }
        public TipoDescontoVoucher TipoDesconto { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public DateTime? DataUtilizacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public bool Ativo { get; private set; }
        public bool Utilizado { get; set; }

        public bool EstaValidoParaUtilizacao()
        {
            var spec = new VoucherAtivoSpecification()
                .And(new VoucherDataSpecification()
                .And(new VoucherQuantidadeSpecification()));

            return spec.IsSatisfiedBy(this);
        }

        public void MarcarComoUtilizado()
        {

        }
    }
}
