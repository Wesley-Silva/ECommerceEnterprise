using ECE.Core.Messages;
using ECE.Pedido.API.Application.DTO;
using ECE.Pedido.API.Application.Events;
using ECE.Pedido.Domain;
using ECE.Pedido.Domain.Pedidos;
using ECE.Pedido.Domain.Vouchers.Specs;
using FluentValidation.Results;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ECE.Pedido.API.Application.Commands
{
    public class PedidoCommandHandler : CommandHandler,
        IRequestHandler<AdicionarPedidoCommand, ValidationResult>
    {
        private readonly IVoucherRepository _voucherRepository;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoCommandHandler(IVoucherRepository voucherRepository,
            IPedidoRepository pedidoRepository)
        {
            _voucherRepository = voucherRepository;
            _pedidoRepository = pedidoRepository;
        }

        public async Task<ValidationResult> Handle(AdicionarPedidoCommand message, CancellationToken cancellationToken)
        {
            // validacao do comando
            if (!message.EhValido())
            {
                return message.ValidationResult;
            }

            // mapear pedido
            var pedido = MapearPedido(message);

            // aplicar voucher se houve
            if (!await AplicarVoucher(message, pedido))
            {
                return ValidationResult;
            }

            // validar pedido
            if (!ValidarPedido(pedido))
            {
                return ValidationResult;
            }

            // processar pagamento
            if (!ProcessarPagamento(pedido))
            {
                return ValidationResult;
            }

            // se pagamento tudo ok
            pedido.AutorizarPedido();

            // adicionar evento
            pedido.AdicionarEvento(new PedidoRealizadoEvent(pedido.Id, pedido.ClienteId));

            // adicionar pedido repositorio
            _pedidoRepository.Adicionar(pedido);

            // persistir dados de pedido e voucher
            return await PersistirDados(_pedidoRepository.unitOfWork);
        }

        private ECE.Pedido.Domain.Pedidos.Pedido MapearPedido(AdicionarPedidoCommand message)
        {
            var endereco = new Endereco
            {
                Logradouro = message.Endereco.Logradouro,
                Numero = message.Endereco.Numero,
                Complemento = message.Endereco.Complemento,
                Bairro = message.Endereco.Bairro,
                Cep = message.Endereco.Cep,
                Cidade = message.Endereco.Cidade,
                Estado = message.Endereco.Estado
            };

            var pedido = new ECE.Pedido.Domain.Pedidos.Pedido(message.ClienteId,
                message.ValorTotal, message.PedidoItems.Select(PedidoItemDTO.ParaPedidoItem).ToList(),
                message.VoucherUtilizado, message.Desconto);

            pedido.AtribuirEndereco(endereco);
            return pedido;
        }

        private async Task<bool> AplicarVoucher(AdicionarPedidoCommand message, ECE.Pedido.Domain.Pedidos.Pedido pedido)
        {
            if (!message.VoucherUtilizado) return true;

            var voucher = await _voucherRepository.ObterVoucherPorCodigo(message.VoucherCodigo);
            if (voucher == null)
            {
                AdicionarErro("O voucher informado não existe!");
                return false;
            }

            var voucherValidation = new VoucherValidation().Validate(voucher);
            if (!voucherValidation.IsValid)
            {
                voucherValidation.Errors.ToList().ForEach(m => AdicionarErro(m.ErrorMessage));
                return false;
            }

            pedido.AtribuirVoucher(voucher);
            voucher.DebitarQuantidade();

            _voucherRepository.Atualizar(voucher);

            return true;
        }

        private bool ValidarPedido(ECE.Pedido.Domain.Pedidos.Pedido pedido)
        {
            var pedidoValorOriginal = pedido.ValorTotal;
            var pedidoDesconto = pedido.Desconto;

            pedido.CalcularValorPedido();

            if (pedido.ValorTotal != pedidoValorOriginal)
            {
                AdicionarErro("O valor total do pedido não confere com o cálculo do pedido");
                return false;
            }

            if (pedido.Desconto != pedidoDesconto)
            {
                AdicionarErro("O valor total não confere com o cálculo do pedido");
                return false;
            }

            return true;
        }

        public bool ProcessarPagamento(ECE.Pedido.Domain.Pedidos.Pedido pedido)
        {
            return true;
        }
    }
}
