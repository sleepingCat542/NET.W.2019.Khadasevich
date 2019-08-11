using System;
using System.Diagnostics;

namespace MathTasks
{
    public class MathMetods
    {
        /// <summary>
        /// Inserts some bits of number2 to bits from i to j number1
        /// </summary>
        /// <param name="number1">First number</param>
        /// <param name="number2"></param>
        /// <param name="i">Start position for inset</param>
        /// <param name="j">End position for insert</param>
        /// <returns>Resul number</returns>
        /// <exception cref="ArgumentOutOfRangeException">Invalid input data</exception>
        public static long InsertNumber(int number1,int number2, int i, int j)
        {
            if (i > j)
            {
                throw new ArgumentOutOfRangeException($"{nameof(i)}");
            }

            CheckIndexes(i, j);

            // Number of bits to replace.
            int length = j - i + 1;

            // Cyclic shift to the right, so now number starts with bits to replace.
            number1 = ShiftRightSigned(number1, i) | (number1 << (32 - i));

            // Reset all bits of the secondNumber except the first, the number of which is equal to the number of bits to replace.
            number2 = ShiftRightSigned(number2 << (32 - length), (32 - length));

            // Reset the first bits of the firstNumber, the number of which is equal to the number of bits to replace.
            number1 = ShiftRightSigned(number1, length) << length;

            // Insert the bits of the secondNumber into the firstNumber
            number1 = number1 | number2;

            // Back doing a cyclic shift to the left.
            number1 = (number1 << i) | ShiftRightSigned(number1, 32 - i);

            return number1;
        }

        private static int ShiftRightSigned(int r, int s)
        {
            return s == 0 ? r : (r >> s) & ~(-1 << (32 - s));
        }

        /// <summary>
        /// Checks if passed indexes are valid.
        /// </summary>
        /// <param name="i">Starting index.</param>
        /// <param name="j">Ending index.</param>
        private static void CheckIndexes(int i, int j)
        {
            if (i < 0 || j < 0)
                throw new ArgumentException(i < 0 ? nameof(i) : nameof(j), "Индекс не может быть отрицательным.");

            if (i > j)
                throw new ArgumentException("Индекс начала должен быть меньше, чем индекс конца.");

            int numberOfBitsInByte = 8;
            if (j >= sizeof(int) * numberOfBitsInByte)
                throw new ArgumentException(nameof(j), "Индекс не должен превышать 32.");
        }


        public static long FindNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                throw new Exception($"Число {number} должно быть положительным");
            }

            bool isExist = false;
            var numberArray = number.ToString().ToCharArray();

            //Number consists of more than 1 digit
            if (numberArray.Length > 1)
            {
                for (int i = numberArray.Length - 1; i > 0; i--)
                {
                    if (numberArray[i] > numberArray[i - 1])
                    {
                        isExist = true;
                        int temp = numberArray[i];
                        numberArray[i] = numberArray[i - 1];
                        numberArray[i - 1] = numberArray[i];
                        break;
                    }
                }
            }

            return isExist == false ? -1 : Convert.ToInt32(numberArray.ToString());
        }


            public static double CalculateTimeStopWatch(int num)
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                FindNextBiggerNumber(num);
                stopwatch.Stop();
                return stopwatch.Elapsed.TotalMilliseconds;
            }


            public static double CalculateTimeDateTime(int number)
            {
                long ellapledTicks = DateTime.Now.Millisecond;
                FindNextBiggerNumber(number);
                ellapledTicks = DateTime.Now.Millisecond - ellapledTicks;
                return ellapledTicks;               
            }
           


        public static int[] FilterDigit(int[] array, int number)
        {
            string resultString=string.Empty;

            foreach(int element in array)
            {
                if(element.ToString().Contains(number.ToString()))
                {
                    resultString += $"{number.ToString()},";
                }
            }

            string[] resultArray = resultString.Split(',');
            int[] resultIntArray=new int[resultArray.Length];

            for(int i=0; i<resultArray.Length; i++)
            {
                resultIntArray[i]= int.Parse(resultArray[i]);
            }
            return resultIntArray;

        }



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
