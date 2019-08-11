using System;

namespace MathTasks
{
    public class MathMetods4
    {
        public static int[] FilterDigit(int[] array, int number)
        {
            string resultString = string.Empty;

            //create string with desired numbers
            foreach (int element in array)
            {
                if (element.ToString().Contains(number.ToString()))
                {
                    resultString += $"{element.ToString()},";
                }
            }

            string[] resultArray = resultString.Split(',');
            int[] resultIntArray = new int[resultArray.Length-1];

            for (int i = 0; i < resultArray.Length-1; i++)
            {
                resultIntArray[i] = Convert.ToInt32(resultArray[i]);
            }
            return resultIntArray;
        }
    }
}
