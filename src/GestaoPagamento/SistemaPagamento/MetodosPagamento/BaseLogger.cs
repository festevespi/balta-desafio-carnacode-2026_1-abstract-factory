using GestaoPagamento.SistemaPagamento.Interfaces;

namespace GestaoPagamento.SistemaPagamento.MetodosPagamento;

public abstract class BaseLogger(string operador) : ILogger
{
    public void Log(string? mensagem)
    {
        mensagem ??= "pagamento efetuado com sucesso";

        Console.WriteLine($"[{operador} Log] {DateTime.Now}: {mensagem}");
    }
}
