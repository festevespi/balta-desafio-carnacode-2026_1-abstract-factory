using GestaoPagamento.SistemaPagamento.Interfaces;

namespace GestaoPagamento.SistemaPagamento.MetodosPagamento;


public class PagSeguroGateway() : IGatewayPagamento
{
    public IValidarPagamento Validar() => new PagSeguroValidator();

    public IProcessarPagamento ProcessarPagamento() => new PagSeguroProcessarPagamento();

    public ILogger GerarLog() => new PagSeguroLogger();



    // Componentes do PagSeguro
    private class PagSeguroValidator : IValidarPagamento
    {
        public bool ValidarCartao(string cardNumber)
        {
            Console.WriteLine("PagSeguro: Validando cartão...");
            return cardNumber.Length == 16;
        }
    }

    private class PagSeguroProcessarPagamento : IProcessarPagamento
    {
        public string ProcesarTransacao(decimal amount, string cardNumber)
        {
            Console.WriteLine($"PagSeguro: Processando R$ {amount}...");
            return $"PAGSEG-{Guid.NewGuid().ToString()[..8]}";
        }
    }

    private class PagSeguroLogger : BaseLogger
    {
        public PagSeguroLogger(string? mensagem = null) : base("PagSeguro")
        {
            Log(mensagem);
        }
    }
}