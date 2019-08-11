using System;

namespace MathTasks
{
    public class MathMetods
    {
        static double Pow(double a, int pow)// function for power
        {
            double result = 1;
            for (int i = 0; i < pow; i++) result *= a;
            return result;
        }

        public static double FindNthRoot(double basis, int exponent, double accuracy)
        {
            double x = basis / exponent;     //upper root range

            var approach = (1 / exponent) * ((exponent - 1) * x + basis / Pow(x, (int)exponent - 1));     //first approach

            while (Math.Abs(approach - x) > accuracy)                 //until accuracy is achieved
            {
                x = approach;
                approach = (1 / exponent) * ((exponent - 1) * x + basis / Pow(x, (int)exponent - 1));  //new approach
            }

            return approach;
        }
    }
}
