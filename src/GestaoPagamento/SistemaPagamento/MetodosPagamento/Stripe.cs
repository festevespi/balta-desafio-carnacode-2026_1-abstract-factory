using GestaoPagamento.SistemaPagamento.Interfaces;

namespace GestaoPagamento.SistemaPagamento.MetodosPagamento;


public class StripeGateway() : IGatewayPagamento
{
    public IValidarPagamento Validar() => new StripeValidator();

    public IProcessarPagamento ProcessarPagamento() => new StripeProcessarPagamento();

    public ILogger GerarLog() => new StripeLogger("mensagem em branco");


    // Componentes do Stripe
    private class StripeValidator : IValidarPagamento
    {
        public bool ValidarCartao(string cardNumber)
        {
            Console.WriteLine("Stripe: Validando cartão...");
            return cardNumber.Length == 16 && cardNumber.StartsWith("4");
        }
    }

    private class StripeProcessarPagamento : IProcessarPagamento
    {
        public string ProcesarTransacao(decimal amount, string cardNumber)
        {
            Console.WriteLine($"Stripe: Processando ${amount}...");
            return $"STRIPE-{Guid.NewGuid().ToString()[..8]}";
        }
    }

    private class StripeLogger : BaseLogger
    {
        public StripeLogger(string? mensagem) : base("Stripe")
        {
            Log(mensagem);
        }
    }
}

