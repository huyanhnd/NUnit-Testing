using System;

namespace BankingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount(100000);
            Console.WriteLine(account);
        }
    }
}
