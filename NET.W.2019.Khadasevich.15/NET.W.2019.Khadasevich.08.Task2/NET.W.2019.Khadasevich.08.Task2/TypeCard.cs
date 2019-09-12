using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Khadasevich._08.Task2
{
    public class TypeCard
    {
        /// <summary>
        /// Change card type (card type depends from amount)
        /// </summary>
        public void ChangeCardType(Account account)
            {
                if (account.Amount < 500m)
                    account.CardType = CardType.Base;
                else if (account.Amount > 500m && account.Amount < 2000m)
                    account.CardType = CardType.Gold;
                else if (account.Amount > 2000m)
                    account.CardType = CardType.Platinum;
            }
    }
    
}
