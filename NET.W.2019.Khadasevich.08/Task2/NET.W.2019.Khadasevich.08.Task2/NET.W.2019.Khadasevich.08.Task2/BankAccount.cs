using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Khadasevich._08.Task2
{

    public enum CardType
    {
        Base=3,
        Gold=6,
        Platinum=10
    }

    /// <summary>
    /// Provides bank account object
    /// </summary>
    public class Account
    {
        private BonusCount bonus = new BonusCount();   
        private CardType cardType =new CardType();      

        public int Number { get; set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public int Bonuses { get; private set; }
        public decimal Amount{ get; private set; }
        public CardType CardType;


        /// <summary>
        /// Provides instance of bank account
        /// </summary>
        /// <param name="bankUser">Account owner</param>
        /// <param name="accountId">Account id</param>
        /// <param name="CardType">Card Type</param>
        /// <param name="amount">Amount</param>
        /// <param name="bonus">Bonus</param>
        public Account(int number, string name, string lastName)
        {
            Number = number;
            Name = name;
            LastName = lastName;
            CardType = CardType.Base;
        }

        public Account(int number, string name, string lastName, int bonus, decimal amount, CardType card)
        {
            Number = number;
            Name = name;
            LastName = lastName;
            Bonuses = bonus;
            Amount = amount;
            CardType = card;
        }

        /// <summary>
        /// bonus reduction
        /// </summary>
        /// <param name="bankUser">Account owner</param>
        /// <param name="accountId">Account id</param>
        /// <param name="CardType">Card Type</param>
        /// <param name="amount">Amount</param>
        /// <param name="bonus">Bonus</param>
        private void WithdrawBonuses(decimal sum)
        {
            Bonuses -= bonus.CalсulateBonus(this, sum, false);
            if (Bonuses < 0)
                Bonuses = 0;
        }

        /// <summary>
        /// bonus increase
        /// </summary>
        /// <param name="bankUser">Account owner</param>
        /// <param name="accountId">Account id</param>
        /// <param name="CardType">Card Type</param>
        /// <param name="amount">Amount</param>
        /// <param name="bonus">Bonus</param>
        private void PutBonuses(decimal sum)
        {
            Bonuses += bonus.CalсulateBonus(this, sum, true);
        }
        public void Withdraw()
        {
            Console.Write("Enter sum which you want to withdraw:");
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            if (sum > SumOnAccount)
                throw new Exception("Not enough money in the account!");
            else
            {
                SumOnAccount -= sum + (Bonuses / 10);
                WithdrawBonuses(sum);
                cardType.ChangeCardType(this);
                Console.WriteLine("You withdrawed: " + sum);
            }

        }
        public void Put()
        {
            Console.Write("Enter sum which you want to put:");
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            SumOnAccount += sum + (Bonuses / 10);
            PutBonuses(sum);
            Console.WriteLine("You put: " + sum);
            cardType.ChangeCardType(this);
        }
        public override string ToString()
        {
            string str = "\nNumber: " + Number + "\nName: " + Name + "\nLast Name: " + LastName + "\nBonus: " + Bonuses + "\nAmount: " + Amount + "\nCard: " + CardType;
            return str;
        }
        public void ShowAccount()
        {
            Console.WriteLine(this);
        }
    }
}
