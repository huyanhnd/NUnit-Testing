using System;

namespace BankingSystem
{
    public class BankAccount
    {
        private double balance;

        public BankAccount()
        {
        }

        public BankAccount(double balance)
        {
            this.balance = balance;
        }

        public double Balance
        {
            get { return balance; }
        }

        public string Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            if (amount > 5000000 || amount == 0)
            {
                return "failed transaction, current balance: " + balance;
            }    

            balance += amount;
            return "successful transaction, current balance: " + balance;
        }

        public string Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount));
            }

            if (amount > 5000000 || amount == 0)
            {
                return "failed transaction, current balance: " + balance;
            }

            if (amount > balance - 50000)
            {
                return "not enough balance, current balance: " + balance;
            }

            balance -= amount;
            return "successful transaction, current balance: " + balance;
        }
    }
}
