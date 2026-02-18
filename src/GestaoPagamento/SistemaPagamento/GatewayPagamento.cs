using GestaoPagamento.SistemaPagamento.Interfaces;

namespace GestaoPagamento.SistemaPagamento;

public class GatewayPagamento(IGatewayPagamento GatewayPagamento)
{
    public void ExecutarPagamento(decimal total, string cartaoCredito)
    {
        var validar = GatewayPagamento.Validar();
        if (!validar.ValidarCartao(cartaoCredito))
        {
            Console.WriteLine($"{GatewayPagamento.GetType().Name.Replace("Factory", "")}: Cartão inválido");
            return;
        }

        var processor = GatewayPagamento.ProcessarPagamento();
        var logger = GatewayPagamento.GerarLog();
        var result = processor.ProcesarTransacao(total, cartaoCredito);
        logger.Log($"Transação processada: {result}");
    }
}
