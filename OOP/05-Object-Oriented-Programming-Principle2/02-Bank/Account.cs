using System;

namespace Bank
{
    public abstract class Account
    {
        // Properties
        private Customer customer;
        private decimal balance;
        private decimal interest;

        // Fields
        public Customer Customer
        {
            get { return this.customer; }
            set { this.customer = value; }
        }

        public decimal Balance
        {
            get { return this.balance; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The account cannot be negative!");
                }
                this.balance = value;
            }
        }

        public decimal Interest
        {
            get { return this.interest; }
            set { this.interest = value; }
        }

        // Constructors
        public Account(Customer customer, decimal balance, decimal interest)
        {
            this.customer = customer;
            this.balance = balance;
            this.interest = interest;
        }

        // Methods
        public abstract decimal CalculateInterest(int monthsCount);

    }
}
