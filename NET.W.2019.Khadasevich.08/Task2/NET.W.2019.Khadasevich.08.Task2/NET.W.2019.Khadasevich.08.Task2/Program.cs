using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Khadasevich._08.Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameFile = "Account.dat";
            BankAccounts repo = new BankAccounts(nameFile);
            int number = 0;
            Account account = new Account();

            while (true)
            {
                while (true)
                {
                    try
                    {

                        Console.Write(" (1) Создать счёт\n, (2) Найти счёт,\n (3) Показать счета:");
                        number = Convert.ToInt32(Console.ReadLine());
                        if (number == 1)
                        {
                            account = repo.CreateAccount();
                            if (account == null)
                                throw new Exception("Счёт не создан");
                            break;
                        }
                        if (number == 2)
                        {
                            account = repo.GetAccount();
                            break;
                        }
                        if (number == 3)
                        {
                            repo.Show();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }
                }
 
                while (true)
                {
                    try
                    {

                        Console.Write(" (1) Добавить сумму,\n (2) Снять сумму,\n (3) Показать счёт,\n (4) Закрыть счёт,\n (5) Выход: ");
                        number = Convert.ToInt32(Console.ReadLine());
                        if (number == 1)
                            repo.PutMoney(account);
                        if (number == 2)
                            repo.WithDrawMoney(account);
                        if (number == 3)
                            account.ShowAccount();
                        if (number == 4)
                        {
                            repo.CloseAccount(account.Number);
                            break;
                        }
                        if (number == 5)
                            break;


                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }
                }
            }
        }
    }
    
}
