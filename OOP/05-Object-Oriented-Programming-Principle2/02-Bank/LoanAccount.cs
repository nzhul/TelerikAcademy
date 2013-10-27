using System;

namespace Bank
{
    public class LoanAccount : Account, IDepositable
    {
        // Constructor
        public LoanAccount(Customer customer, decimal balance, decimal interest)
            : base(customer, balance, interest)
        { }

        // CalculateInterest abstract method - override
        public override decimal CalculateInterest(int monthsCount)
        {
            if (monthsCount <= 2 && this.Customer == Customer.Company)
            {
                return 0;
            }
            else if (monthsCount <= 3 && this.Customer == Customer.Individual)
            {
                return 0;
            }
            else if (this.Customer == Customer.Company)
            {
                return this.Balance * (this.Interest / 100) * (monthsCount - 2);
            }
            else
            {
                return this.Balance * (this.Interest / 100) * (monthsCount - 3);
            }
        }

        // IDepositable
        public void Deposit(int deposit)
        {
            this.Balance += deposit;
        }
    }
}
