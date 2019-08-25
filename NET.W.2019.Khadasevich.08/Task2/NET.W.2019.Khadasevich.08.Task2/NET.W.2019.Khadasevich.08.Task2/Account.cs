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
        private TypeCard cardType =new TypeCard();      

        public int Number { get; set; }
        public string Name { get;  set; }
        public string LastName { get;  set; }
        public int Bonuses { get;  set; }
        public decimal Amount{ get;  set; }
        public CardType CardType;


        /// <summary>
        /// Provides instance of bank account
        /// </summary>
        /// <param name="number">Account number</param>
        /// <param name="CardType">Card Type</param>
        /// <param name="amount">Amount</param>
        /// <param name="bonus">Bonus</param>

        public Account()
        {

        }

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
        /// <param name="sum">money withdrawn from the account</param>
        private void ExcludeBonuses(decimal sum)
        {
            Bonuses -= bonus.CalсulateBonus(this, sum, false);
            if (Bonuses < 0)
                Bonuses = 0;
        }

        /// <summary>
        /// bonus increase
        /// </summary>
        /// <param name="sum">money deposited into the account</param>
        private void PutBonuses(decimal sum)
        {
            Bonuses += bonus.CalсulateBonus(this, sum, true);
        }

        /// <summary>
        /// withdrawing money from an account
        /// </summary>
        public void Withdraw()
        {
            Console.Write("Введите сумму, которую хотите снять:");
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            if (sum > Amount)
                throw new Exception("Недостаточно средств на счете!");
            else
            {
                Amount = Amount-sum+(Bonuses/10); 
                ExcludeBonuses(sum);
                cardType.ChangeCardType(this);
                Console.WriteLine("Вы сняли: " + sum);
            }
        }

        /// <summary>
        /// adding money to the account
        /// </summary>
        public void Put()
        {
            Console.Write("Введите сумму, на которую хотите пополнить счёт:");
            decimal sum = Convert.ToDecimal(Console.ReadLine());
            Amount += sum + (Bonuses / 10);
            PutBonuses(sum);
            Console.WriteLine("Вы увеличили счёт на: " + sum);
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
