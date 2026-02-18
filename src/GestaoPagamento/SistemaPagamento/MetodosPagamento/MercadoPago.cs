using GestaoPagamento.SistemaPagamento.Interfaces;

namespace GestaoPagamento.SistemaPagamento.MetodosPagamento;

public class MercadoPagoGateway() : IGatewayPagamento
{
    public IValidarPagamento Validar() => new MercadoPagoValidator();

    public IProcessarPagamento ProcessarPagamento() => new MercadoPagoProcessarPagamento();

    public ILogger GerarLog() => new MercadoPagoLogger();

    // Componentes do MercadoPago
    private class MercadoPagoValidator : IValidarPagamento
    {
        public bool ValidarCartao(string numeroCartao)
        {
            Console.WriteLine("MercadoPago: Validando cartão...");
            return numeroCartao.Length == 16 && numeroCartao.StartsWith("5");
        }
    }

    private class MercadoPagoProcessarPagamento : IProcessarPagamento
    {
        public string ProcesarTransacao(decimal total, string numeroCartao)
        {
            Console.WriteLine($"MercadoPago: Processando R$ {total}...");
            return $"MP-{Guid.NewGuid().ToString()[..8]}";
        }
    }

    private class MercadoPagoLogger : BaseLogger
    {
        public MercadoPagoLogger(string? mensagem = null) : base("MercadoPago")
        {
            Log(mensagem);
        }
    }
}