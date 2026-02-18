using GestaoPagamento.SistemaPagamento.Interfaces;
using GestaoPagamento.SistemaPagamento.MetodosPagamento;

namespace GestaoPagamento.SistemaPagamento;

public class GatewayPagamento(EMeioPagamento gatewayPagamento)
{
    private IGatewayPagamento? Gateway;

    public void ExecutarPagamento(decimal total, string cartaoCredito)
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
                return;
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
