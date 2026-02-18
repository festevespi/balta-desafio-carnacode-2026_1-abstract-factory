using GestaoPagamento;
using GestaoPagamento.SistemaPagamento;

//var gateway01 = new GatewayPagamento(new MercadoPagoGateway());
//gateway01.ExecutarPagamento(20.00m, "");

//Console.WriteLine();

//var gateway02 = new GatewayPagamento(new MercadoPagoGateway());
//gateway02.ExecutarPagamento(30.00m, "5432154321543210");

//Console.WriteLine();

//var gateway03 = new GatewayPagamento(new PagSeguroGateway());
//gateway03.ExecutarPagamento(40.00m, "5234567890123456");

//Console.WriteLine();

//var gateway04 = new GatewayPagamento(new StripeGateway());
//gateway04.ExecutarPagamento(80.00m, "4234567890123456");

new GatewayPagamento().ExecutarPagamento(EMeioPagamento.MercadoPago, 30.00m, "5432154321543210");

Console.WriteLine();

new GatewayPagamento().ExecutarPagamento(EMeioPagamento.PagSeguro, 40.00m, "1234554321543210");

Console.WriteLine();

new GatewayPagamento().ExecutarPagamento(EMeioPagamento.Stripe, 80.00m, "4234567890123456");