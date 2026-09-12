using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace ConsoleApp1
{
    public abstract class PaymentMethod
    {
        public required string AccountInfo { get; set; }
        public abstract decimal ProcessPayment(decimal amount);
        public void Pay(decimal amount)
        {
            Console.WriteLine($"Charged {ProcessPayment(amount)} via {AccountInfo}");
        }
    }

    public class CreditCardPayment : PaymentMethod
    {
        public override decimal ProcessPayment(decimal amount)
        {
            return amount * 1.02m;
        }
    }

    public class PayPalPayment : PaymentMethod
    {
        public override decimal ProcessPayment(decimal amount)
        {
            return amount + 0.30m;
        }
    }

    public interface INotifier
    {
        void Notify(string message);
    }

    public class EmailNotifier : INotifier
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }

    public class SMSNotifier : INotifier
    {
        public void Notify(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }

    public class PaymentProcessor
    {
        private readonly PaymentMethod _paymentMethod;
        private readonly INotifier _notifier;

        public PaymentProcessor(PaymentMethod paymentMethod, INotifier notifier)
        {
            _paymentMethod = paymentMethod;
            _notifier = notifier;
        }

        public void Process(decimal amount)
        {
            _paymentMethod.Pay(amount);
            _notifier.Notify($"Payment of {amount} processed successfully.");
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            PaymentMethod creditCard = new CreditCardPayment { AccountInfo = "Visa **** 1234" };
            INotifier emailNotifier = new EmailNotifier();
            PaymentProcessor processor1 = new PaymentProcessor(creditCard, emailNotifier);
            processor1.Process(100m);
            PaymentMethod paypal = new PayPalPayment { AccountInfo = "PayPal **** 5678" };
            INotifier smsNotifier = new SMSNotifier();
            PaymentProcessor processor2 = new PaymentProcessor(paypal, smsNotifier);
            processor2.Process(100m);
        }
    }
}