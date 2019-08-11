using System;

namespace MathTasks
{
    public class MathMetods
    {
        public static int[] FilterDigit(int[] array, int number)
        {
            string resultString = string.Empty;

            //create string with desired numbers
            foreach (int element in array)
            {
                if (element.ToString().Contains(number.ToString()))
                {
                    resultString += $"{number.ToString()},";
                }
            }

            string[] resultArray = resultString.Split(',');
            int[] resultIntArray = new int[resultArray.Length];

            for (int i = 0; i < resultArray.Length; i++)
            {
                resultIntArray[i] = int.Parse(resultArray[i]);
            }
            return resultIntArray;
        }
    }
}
