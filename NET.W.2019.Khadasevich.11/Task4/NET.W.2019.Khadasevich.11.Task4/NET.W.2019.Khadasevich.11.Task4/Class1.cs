using System;

namespace NET.W._2019.Khadasevich._11.Task4
{
    class FibonachiClass
    {
        /// <summary>
		/// Recursive method for fibonacci numbers
		/// </summary>
		/// <param name="n">count of fibonacci numbers</param>
        static int FibonachiRecursion(int n)
        {
            if (n == 0)
            {
                return 0;
            }
            if (n == 1)
            {
                return 1;
            }
            else
            {
                return FibonachiRecursion(n - 1) + FibonachiRecursion(n - 2);
            }
        }

        /// <summary>
		/// Method searches and prints fibonacci numbers
		/// </summary>
        static void Fibonachi()
        {
            Console.WriteLine("Enter count of numbers:");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
                Console.WriteLine($"{FibonachiRecursion(i)}");
        }
    }
}
