using System;

namespace sorting
{
    public class ClassLib
    {
        public static int[] QuickSorting(int[] arr, int left, int right)
        {
            int i = left;
            int j = right;
            int x = arr[(left + right) / 2];   //reference number
            while (i <= j)
            {
                while (arr[i] < x) i++;
                while (arr[j] > x) j--;
                if (i <= j)
                {
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }
            if (left < j) QuickSorting(arr, left, j);       //sort the left side
            if (i < right) QuickSorting(arr, i, right);     //sort the right side

            return arr;
        }



        public static int[] MergeSorting(int[] arr)
        {
            if (arr.Length == 1)
                return arr;

            int middle = arr.Length / 2;

            int[] left = new int[middle];
            for (int i = 0; i < middle; i++)
            {
                left[i] = arr[i];
            }

            int[] right = new int[arr.Length - middle];
            for (int i = 0; i < arr.Length - middle; i++)
            {
                right[i] = arr[i + middle];
            }
            left = MergeSorting(left);
            right = MergeSorting(right);

            int leftptr = 0;
            int rightptr = 0;

            int[] sorted = new int[arr.Length];
            for (int k = 0; k < arr.Length; k++)
            {
                if (rightptr == right.Length ||
                      ((leftptr < left.Length) && (left[leftptr] <= right[rightptr])))
                {
                    sorted[k] = left[leftptr];
                    leftptr++;
                }
                else if (leftptr == left.Length ||
                          ((rightptr < right.Length) && (right[rightptr] <= left[leftptr])))
                {
                    sorted[k] = right[rightptr];
                    rightptr++;
                }
            }
            return sorted;

        }
    }
}
