using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Khadasevich._08.Task2
{
    public class BonusCount
    {
        /// <summary>
        /// calculates bonus
        /// </summary>
        public int CalсulateBonus(Account account, decimal money, bool add)
            {
            int bonus;
            if(add)
                bonus= ((int)money / (40 - (int)account.CardType));
            else
                bonus= ((int)money / (80 - (int)account.CardType));
            return bonus;
            }
        }
    }

