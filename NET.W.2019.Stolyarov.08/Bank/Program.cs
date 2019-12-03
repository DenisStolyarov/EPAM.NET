using System;

namespace Bank
{
    class Program
    {
        static void Show(Bank bank)
        {
            foreach (var account in bank.GetBankAccounts())
            {
                Console.WriteLine(account);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            try
            {
                Bank bank = new Bank();

                bank.AddAccount("Denis", "Stolyarov", Bank.Variety.Platinum);
                bank.AddAccount("Petr", "Petrov", Bank.Variety.Gold);
                bank.AddAccount("Ivan", "Ivanov", Bank.Variety.Base);
                bank.AddAccount("Kola", "Ivanov", Bank.Variety.Base);

                Show(bank);

                bank.CloseAccount(4);

                Show(bank);

                bank.Replenish(1, 110);
                bank.Replenish(2, 50);
                bank.Replenish(3, 5);

                Show(bank);

                bank.Debit(1, 10);
                bank.Debit(2, 20);
                bank.Debit(3, 1);

                Show(bank);

                string path = @"D:\Accounts.txt";

                bank.Save(path);

                bank.Clear();

                bank.Load(path);

                Show(bank);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
