using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort.NUnitTests
{
	/// <summary>
	/// Class that contains comparers for sorting jagged arrays.
	/// </summary>
	public class Comparers
	{
		/// <summary>
		/// Comparer for sorting by ascending max sums of rows.
		/// </summary>
		public class ByAscendingRowElementsSums : IComparer<int[]>
		{
			public int Compare(int[] num1, int[] num2)
			{
				CheckParameters(num1, num2);

				int num1Sum = num1.Sum(),
					num2Sum = num2.Sum();

				if (num1Sum == num2Sum)
					return 0;

				return num1Sum > num2Sum ? 1 : -1;
			}
		}

		/// <summary>
		/// Comparer for sorting by descending max sums of rows.
		/// </summary>
		public class ByDescendingRowElementsSums : IComparer<int[]>
		{
			public int Compare(int[] num1, int[] num2)
			{
				CheckParameters(num1, num2);

				int num1Sum = num1.Sum(),
					num2Sum = num2.Sum();

				if (num1Sum == num2Sum)
					return 0;

				return num1Sum > num2Sum ? -1 : 1;
			}
		}

		/// <summary>
		/// Comparer for sorting by ascendibg max element of the row.
		/// </summary>
		public class ByAscendingMaxElements : IComparer<int[]>
		{
			public int Compare(int[] num1, int[] num2)
			{
				CheckParameters(num1, num2);

				int num1Max = num1.Max(),
					num2Max = num2.Max();

				if (num1Max == num2Max)
					return 0;

				return num1Max > num2Max ? 1 : -1;
			}
		}

		/// <summary>
		/// Comparer for sorting by descending max element of the row.
		/// </summary>
		public class ByDescendingMaxElements : IComparer<int[]>
		{
			public int Compare(int[] num1, int[] num2)
			{
				CheckParameters(num1, num2);

				int num1Max = num1.Max(),
					num2Max = num2.Max();

				if (num1Max == num2Max)
					return 0;

				return num1Max > num2Max ? -1 : 1;
			}
		}

		/// <summary>
		/// Comparer for sorting by ascendibg min element of the row.
		/// </summary>
		public class ByAscendingMinElements : IComparer<int[]>
		{
			public int Compare(int[] num1, int[] num2)
			{
				CheckParameters(num1, num2);

				int num1Min = num1.Min(),
					num2Min = num2.Min();

				if (num1Min == num2Min)
					return 0;

				return num1Min > num2Min ? 1 : -1;
			}
		}

		/// <summary>
		/// Comparer for sorting by descending max element of the row.
		/// </summary>
		public class ByDescendingMinElements : IComparer<int[]>
		{
			public int Compare(int[] num1, int[] num2)
			{
				CheckParameters(num1, num2);

				int num1Min = num1.Min(),
					num2Min = num2.Min();

				if (num1Min == num2Min)
					return 0;

				return num1Min > num2Min ? -1 : 1;
			}
		}

		/// <summary>
		/// Chacks if passed arrays are not null.
		/// </summary>
		/// <param name="num1">The num1 array.</param>
		/// <param name="num2">The num2 array.</param>
		/// <exception cref="ArgumentNullException">Throws when array is null.</exception>
		private static void CheckParameters(int[] num1, int[] num2)
		{
			if (num1 == null || num2 == null)
				throw new ArgumentNullException(num1 == null ? nameof(num1) : nameof(num2), "Value can not be undefined.");
		}

	}
}
