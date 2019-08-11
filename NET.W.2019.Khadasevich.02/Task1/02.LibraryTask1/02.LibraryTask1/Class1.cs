using System;

namespace MathTasks
{
    public class MathMetods1
    {

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
    }

}
