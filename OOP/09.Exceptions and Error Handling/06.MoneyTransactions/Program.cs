using System;
using System.Collections.Generic;

namespace _06.MoneyTransactions
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, double> accounts = new Dictionary<int, double>();
            string[] givenAccounts = Console.ReadLine().Split(",");

            foreach (var account in givenAccounts)
            {
                string[] accountInfo = account.Split("-");
                int accNumber = int.Parse(accountInfo[0]);
                double accBalance = double.Parse(accountInfo[1]);

                accounts.Add(accNumber, accBalance);
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] commands = input.Split();
                string action = commands[0];
                int accNumber = int.Parse(commands[1]);
                double sum = double.Parse(commands[2]);

                try
                {
                    ValidateData(accounts, action, accNumber, sum);
                    DepositOrWithdraw(accounts, action, accNumber, sum);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

                input = Console.ReadLine();
            }
        }

        private static void DepositOrWithdraw(Dictionary<int, double> accounts, string action, int accNumber, double sum)
        {
            if (action == "Deposit")
            {
                accounts[accNumber] += sum;
            }
            else if (action == "Withdraw")
            {
                accounts[accNumber] -= sum;
            }
            Console.WriteLine($"Account {accNumber} has new balance: {accounts[accNumber]:f2}");
        }

        private static void ValidateData(Dictionary<int, double> accounts, string action, int accNumber, double sum)
        {
            if (action != "Deposit" && action != "Withdraw")
            {
                throw new InvalidOperationException("Invalid command!");
            }
            else if (!accounts.ContainsKey(accNumber))
            {
                throw new KeyNotFoundException("Invalid account!");
            }
            else if (action == "Withdraw" && accounts[accNumber] < sum)
            {
                throw new ArgumentException("Insufficient balance!");
            }
        }
    }
}
