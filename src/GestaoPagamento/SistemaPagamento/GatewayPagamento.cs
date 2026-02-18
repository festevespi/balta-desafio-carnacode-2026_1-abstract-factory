using GestaoPagamento.SistemaPagamento.Interfaces;
using GestaoPagamento.SistemaPagamento.MetodosPagamento;

namespace GestaoPagamento.SistemaPagamento;

public class GatewayPagamento()
{
    private IGatewayPagamento? Gateway;

    public void ExecutarPagamento(EMeioPagamento gatewayPagamento, decimal total, string cartaoCredito)
    {
        switch (gatewayPagamento)
        {
            case EMeioPagamento.MercadoPago:
                Gateway = new MercadoPagoGateway();
                break;
            case EMeioPagamento.PagSeguro:
                Gateway = new PagSeguroGateway();
                break;
            case EMeioPagamento.Stripe:
                Gateway = new StripeGateway();
                break;
            default:
                Console.WriteLine("Meio de pagamento incorreto.");
                break;
        }

        if (Gateway is null)
        {
            Console.WriteLine("Meio de pagamento incorreto.");
        }

        var validar = Gateway!.Validar();
        if (!validar.ValidarCartao(cartaoCredito))
        {
            Console.WriteLine($"{Gateway.GetType().Name.Replace("Factory", "")}: Cartão inválido");
            return;
        }

        var processor = Gateway.ProcessarPagamento();
        var logger = Gateway.GerarLog();
        var result = processor.ProcesarTransacao(total, cartaoCredito);
        logger.Log($"Transação processada: {result}");
    }
}
