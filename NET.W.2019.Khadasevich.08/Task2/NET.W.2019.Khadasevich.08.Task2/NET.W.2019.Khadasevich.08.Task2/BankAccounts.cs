using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Khadasevich._08.Task2
{
    public class BankAccounts
    {
        string pathToFile;

        List<Account> accounts;

        /// <summary>
        /// Provides instance of BankAccount
        /// </summary>
        /// <param name="path">path to fail (repository of accounts)</param>
        public BankAccounts(string path)
        {
            pathToFile = path;
            FileInfo f = new FileInfo(pathToFile);
            using (BinaryWriter bw = new BinaryWriter(f.Open(FileMode.OpenOrCreate,
                FileAccess.ReadWrite, FileShare.None))) { }
            accounts = GetAccounts();
        }

        /// <summary>
        /// Create account
        /// </summary>
        public Account CreateAccount()
        {
            Account acc;
            Console.WriteLine("Создание: ");
                FillNameAndLastName(out string name, out string lastName);
                if (CheckOwnerAccount(name, lastName))
                    throw new Exception("У вас уже есть счёт!");
                Console.Write("Введите ваш начальный капитал: ");
                decimal sum = Convert.ToDecimal(Console.ReadLine());
                FileInfo f = new FileInfo(pathToFile);
                int number = 1;
                if (accounts.Count != 0)
                    number = accounts.LastOrDefault().Number + 1;
                acc = new Account(number, name, lastName);
                acc.Amount = sum;
                using (BinaryWriter bw = new BinaryWriter(f.Open(FileMode.Append,
                            FileAccess.Write, FileShare.None)))
                {

                    bw.Write(acc.Number);
                    bw.Write(acc.Name);
                    bw.Write(acc.LastName);
                    bw.Write(acc.Bonuses);
                    bw.Write(acc.Amount);
                    bw.Write((int)acc.CardType);
                }
                accounts.Add(acc);
                return acc;            
            throw new Exception("Неверные данные!");
        }

        /// <summary>
        /// Close account
        /// </summary>
        public void CloseAccount(int id)
        {
            accounts.Remove(GetAccountById(id));
            ReWrittingAllFile();
            Console.WriteLine("Ваш счёт удалён!");
        }

        /// <summary>
        /// Fill name and last name
        /// </summary>
        private void FillNameAndLastName(out string name, out string lastName)
        {
            Console.Write("Введите имя: ");
            name = Console.ReadLine();
            Console.Write("Введите фамилию: ");
            lastName = Console.ReadLine();
        }


        /// <summary>
        /// have an account with the same name and lastname
        /// </summary>
        private bool CheckOwnerAccount(string name, string lastName)
        {
            foreach (var a in accounts)
            {
                if (a.Name.ToLower() == name.ToLower() && a.LastName.ToLower() == lastName.ToLower())
                    return true;
            }
            return false;
        }


        public Account GetAccount()
        {
            FillNameAndLastName(out string name, out string lastName);
            foreach (var a in accounts)
            {
                if (a.Name.ToLower() == name.ToLower() && a.LastName.ToLower() == lastName.ToLower())
                    return a;
            }
            throw new Exception("Account not  found");
        }

        /// <summary>
        /// take accounts from file in acc
        /// </summary>
        private List<Account> GetAccounts()
        {
            List<Account> acc = new List<Account>();
            FileInfo f = new FileInfo(pathToFile);
            using (BinaryReader br = new BinaryReader(f.OpenRead()))
            {

                while (br.PeekChar() > -1)
                {
                    int id = br.ReadInt32();
                    string name = br.ReadString();
                    string lastname = br.ReadString();
                    int bonus = br.ReadInt32();
                    decimal sum = br.ReadDecimal();
                    int card = br.ReadInt32();

                    acc.Add(new Account(id, name, lastname, bonus, sum, (CardType)card));
                }
            }
            return acc;
        }

        /// <summary>
        /// show all accounts
        /// </summary>
        public void Show()
        {
            if (accounts.Count == 0)
                Console.WriteLine("Счета отсутствуют");
            foreach (var a in accounts)
            {
                Console.WriteLine(a);
            }
        }


        public void WithDrawMoney(Account account)
        {
            accounts.Find(a => a.Number== account.Number).Withdraw();
            ReWrittingAllFile();
        }
        public void PutMoney(Account account)
        {
            accounts.Find(a => a.Number == account.Number).Put();
            ReWrittingAllFile();
        }

        /// <summary>
        //overwrite the file
        /// </summary>
        private void ReWrittingAllFile()
        {
            FileInfo f = new FileInfo(pathToFile);
            using (BinaryWriter bw = new BinaryWriter(f.Open(FileMode.Truncate,
                   FileAccess.Write, FileShare.None)))
            {

                foreach (var acc in accounts)
                {

                    bw.Write(acc.Number);
                    bw.Write(acc.Name);
                    bw.Write(acc.LastName);
                    bw.Write(acc.Bonuses);
                    bw.Write(acc.Amount);
                    bw.Write((int)acc.CardType);
                }
            }
        }

        /// <summary>
        /// get account
        /// </summary>
        private Account GetAccountById(int number)
        {
            foreach (var a in accounts)
            {
                if (a.Number == number)
                    return a;
            }
            throw new Exception("Счёт не найден");
        }
    }
}

