// DESAFIO: Sistema de Pagamentos Multi-Gateway
// PROBLEMA: Uma plataforma de e-commerce precisa integrar com múltiplos gateways de pagamento
// (PagSeguro, MercadoPago, Stripe) e cada gateway tem componentes específicos (Processador, Validador, Logger)
// O código atual está muito acoplado e dificulta a adição de novos gateways

using DesignPatternChallenge.MetodosPagamento;

namespace DesignPatternChallenge
{
    // Contexto: Sistema de pagamentos que precisa trabalhar com diferentes gateways
    // Cada gateway tem sua própria forma de processar, validar e logar transações
    
    public class PaymentService(string gateway)
    {
        private readonly string _gateway = gateway;

        public void ProcessPayment(decimal amount, string cardNumber)
        {
            // Problema: Switch case gigante para cada gateway
            // Quando adicionar novo gateway, precisa modificar este método
            switch (_gateway.ToLower())
            {
                case "pagseguro":
                    var pagSeguroValidator = new PagSeguroValidator();
                    if (!pagSeguroValidator.ValidateCard(cardNumber))
                    {
                        Console.WriteLine("PagSeguro: Cartão inválido");
                        return;
                    }
                    
                    var pagSeguroProcessor = new PagSeguroProcessor();
                    var pagSeguroResult = pagSeguroProcessor.ProcessTransaction(amount, cardNumber);
                    
                    var pagSeguroLogger = new PagSeguroLogger();
                    pagSeguroLogger.Log($"Transação processada: {pagSeguroResult}");
                    break;

                case "mercadopago":
                    var mercadoPagoValidator = new MercadoPagoValidator();
                    if (!mercadoPagoValidator.ValidateCard(cardNumber))
                    {
                        Console.WriteLine("MercadoPago: Cartão inválido");
                        return;
                    }
                    
                    var mercadoPagoProcessor = new MercadoPagoProcessor();
                    var mercadoPagoResult = mercadoPagoProcessor.ProcessTransaction(amount, cardNumber);
                    
                    var mercadoPagoLogger = new MercadoPagoLogger();
                    mercadoPagoLogger.Log($"Transação processada: {mercadoPagoResult}");
                    break;

                case "stripe":
                    var stripeValidator = new StripeValidator();
                    if (!stripeValidator.ValidateCard(cardNumber))
                    {
                        Console.WriteLine("Stripe: Cartão inválido");
                        return;
                    }
                    
                    var stripeProcessor = new StripeProcessor();
                    var stripeResult = stripeProcessor.ProcessTransaction(amount, cardNumber);
                    
                    var stripeLogger = new StripeLogger();
                    stripeLogger.Log($"Transação processada: {stripeResult}");
                    break;

                default:
                    throw new ArgumentException("Gateway não suportado");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Sistema de Pagamentos ===\n");

            // Problema: Cliente precisa saber qual gateway está usando
            // e o código de processamento está todo acoplado
            var pagSeguroService = new PaymentService("pagseguro");
            pagSeguroService.ProcessPayment(150.00m, "1234567890123456");

            Console.WriteLine();

            var mercadoPagoService = new PaymentService("mercadopago");
            mercadoPagoService.ProcessPayment(200.00m, "5234567890123456");

            Console.WriteLine();

            // Pergunta para reflexão:
            // - Como adicionar um novo gateway sem modificar PaymentService?
            // - Como garantir que todos os componentes de um gateway sejam compatíveis entre si?
            // - Como evitar criar componentes de gateways diferentes acidentalmente?
        }
    }
}
