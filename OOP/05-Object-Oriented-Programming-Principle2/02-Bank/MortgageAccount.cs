using System;

namespace Bank
{
    class MortgageAccount : Account, IDepositable
    {
        // Constructor
        public MortgageAccount(Customer customer, decimal balance, decimal interest)
            : base(customer, balance, interest)
        { }

        // CalculateInterest abstract method - override
        public override decimal CalculateInterest(int monthsCount)
        {
            if (this.Customer == Customer.Company && monthsCount <= 12)
            {
                return this.Balance * (this.Interest / 100 / 2) * monthsCount;
            }
            else if (this.Customer == Customer.Individual && monthsCount <= 6)
            {
                return 0;
            }
            else if (this.Customer == Customer.Company)
            {
                return (this.Balance * (this.Interest / 100 / 2) * 12) + (monthsCount * (this.Interest / 100) * (monthsCount - 12));
            }
            else
            {
                return this.Balance * (this.Interest / 100) * (monthsCount - 6);
            }
        }

        // IDepositable
        public void Deposit(int deposit)
        {
            this.Balance += deposit;
        }
    }
}
