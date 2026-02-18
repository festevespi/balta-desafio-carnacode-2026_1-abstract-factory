namespace GestaoPagamento.SistemaPagamento.Interfaces;

public interface IGatewayPagamento
{
    IValidarPagamento Validar();
    IProcessarPagamento ProcessarPagamento();
    ILogger GerarLog();
}