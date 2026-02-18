using GestaoPagamento;
using GestaoPagamento.SistemaPagamento;

new GatewayPagamento(EMeioPagamento.MercadoPago).ExecutarPagamento(30.00m, "5432154321543210");

Console.WriteLine();

new GatewayPagamento(EMeioPagamento.PagSeguro).ExecutarPagamento(40.00m, "1234554321543210");

Console.WriteLine();

new GatewayPagamento(EMeioPagamento.Stripe).ExecutarPagamento(80.00m, "4234567890123456");