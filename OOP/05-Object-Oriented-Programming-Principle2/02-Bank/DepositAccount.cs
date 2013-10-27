using System;

namespace Bank
{
    public class DepositAccount : Account, IDepositable, IWithdrawable
    {
        //Constructor
        public DepositAccount(Customer customer, decimal balance, decimal interest)
            : base(customer, balance, interest)
        { }

        // CalculateInterest abstract method - override
        public override decimal CalculateInterest(int monthsCount)
        {
            if (this.Balance <= 1000)
            {
                return 0;
            }
            else
            {
                return this.Balance * (this.Interest / 100) * monthsCount;
            }
        }

        // IDepositable
        public void Deposit(int deposit)
        {
            this.Balance += deposit;
        }

        // IWithrawable
        // We must enter the value as negative number:
        // Example: DepositAccount.Withdraw(-25);
        public void Withdraw(int withdraw)
        {
            if ((this.Balance + withdraw) >= 0)
            {
                this.Balance += withdraw;
            }
            else
            {
                throw new ApplicationException("You cannot withdraw more money than you have!");
            }
        }
    }
}
