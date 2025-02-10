using System;
using System.Collections.Generic;

namespace PersonalBudgetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Transaction> transactions = new List<Transaction>();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Personal Budget App");
                Console.WriteLine("1. Add Income");
                Console.WriteLine("2. Add Expense");
                Console.WriteLine("3. View Balance");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTransaction(transactions, true);
                        break;
                    case "2":
                        AddTransaction(transactions, false);
                        break;
                    case "3":
                        ViewBalance(transactions);
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void AddTransaction(List<Transaction> transactions, bool isIncome)
        {
            Console.Write("Enter amount: ");
            if (decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                transactions.Add(new Transaction
                {
                    Amount = isIncome ? amount : -amount,
                    Date = DateTime.Now
                });
                Console.WriteLine(isIncome ? "Income added." : "Expense added.");
            }
            else
            {
                Console.WriteLine("Invalid amount. Please try again.");
            }
        }

        static void ViewBalance(List<Transaction> transactions)
        {
            decimal balance = 0;
            foreach (var transaction in transactions)
            {
                balance += transaction.Amount;
            }
            Console.WriteLine($"Current Balance: {balance:C}");
        }
    }

    class Transaction
    {
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}