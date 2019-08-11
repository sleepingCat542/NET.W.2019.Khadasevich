using System;
using System.Globalization;

namespace MathTasks
{
    public class MathMetods5
    {
        static double Pow(double a, int pow)        // function for power
        {
            double result = 1;
            for (int i = 0; i < pow; i++) result *= a;
            return result;
        }

        public static double FindNthRoot(double basis, int exponent, double accuracy)
        {
            double x = basis / exponent;     //upper root range

            var approach = (1.0 / exponent) * (((exponent - 1) * x) + (basis / Pow(x, exponent - 1)));     //first approach

            while (Math.Abs(approach - x) > accuracy)                 //until accuracy is achieved
            {
                x = approach;
                approach = (1.0 / exponent) * (((exponent - 1) * x) + (basis / Pow(x, (int)exponent - 1)));  //new approach
            }

            return Math.Round(approach, GetRoundNumber(accuracy));
        }

        private static int GetRoundNumber(double acc)
        {
            var str = acc.ToString(CultureInfo.InvariantCulture);
            var indexPot = str.LastIndexOf(".", StringComparison.Ordinal);
            var strAfterPot = str.Substring(indexPot + 1);
            var roundNumber = strAfterPot.Length;

            return roundNumber;
        }
    }
    
}
