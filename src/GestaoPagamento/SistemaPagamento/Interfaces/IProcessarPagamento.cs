namespace GestaoPagamento.SistemaPagamento.Interfaces;

public interface IProcessarPagamento { string ProcesarTransacao(decimal amount, string cardNumber); }