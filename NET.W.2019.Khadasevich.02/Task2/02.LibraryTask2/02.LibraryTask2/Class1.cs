using System;
using System.Diagnostics;

namespace MathTasks
{
    public class MathMetods
    {
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
                        isExist = true;                             //The required number exists.
                        int temp = numberArray[i];
                        numberArray[i] = numberArray[i - 1];
                        numberArray[i - 1] = numberArray[i];
                        break;
                    }
                }
            }

            return isExist == false ? -1 : Convert.ToInt32(numberArray.ToString());
        }


        //Time measurement with stopwatch
        public static double CalculateTimeStopWatch(int num)        
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FindNextBiggerNumber(num);
            stopwatch.Stop();
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        //Time measurement with DateTime
        public static double CalculateTimeDateTime(int number)
        {
            long ellapledTicks = DateTime.Now.Millisecond;
            FindNextBiggerNumber(number);
            ellapledTicks = DateTime.Now.Millisecond - ellapledTicks;
            return ellapledTicks;
        }

    }
}
