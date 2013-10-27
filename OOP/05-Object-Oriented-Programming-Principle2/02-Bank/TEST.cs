using System;

namespace Bank
{
    class TEST
    {
        static void Main()
        {
            DepositAccount myDeposit = new DepositAccount(Customer.Individual, 0, 1);
            myDeposit.Deposit(2500);

            Console.WriteLine("Balance: {0}", myDeposit.Balance);
            Console.WriteLine("Interest: {0}", myDeposit.CalculateInterest(12));

            Console.WriteLine("... Withdrawing $2000 ...");
            myDeposit.Withdraw(-2000);
            // myDeposit.Withdraw(-2800); - this will throw exeption

            Console.WriteLine("New Balance {0}", myDeposit.Balance);
            Console.WriteLine("new Interest: {0}", myDeposit.CalculateInterest(12));
        }
    }
}
