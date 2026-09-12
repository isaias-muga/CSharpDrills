
namespace drill5
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }

    }

    class Program
    {
        static void Main(String[] args)
        {
            static void Withdraw(decimal balance, decimal amount)
            {
                if (amount > balance)
                {
                    throw new InsufficientFundsException("the balance isn't enough");
                }
                else
                {
                    Console.WriteLine($"New balance: {balance} - {amount} -> {balance - amount}");
                }
            }
            static void AttemptWithdraw(decimal balance, decimal amount)
            {
                try
                {
                    Withdraw(balance, amount);
                }
                catch (InsufficientFundsException e)
                {
                    Console.WriteLine($"Exception: {e.Message}");
                }
                finally
                {
                    Console.WriteLine("Operation Finished.");
                }
            }

            AttemptWithdraw(1000, 500);
            AttemptWithdraw(500, 600);
        }
    }
}