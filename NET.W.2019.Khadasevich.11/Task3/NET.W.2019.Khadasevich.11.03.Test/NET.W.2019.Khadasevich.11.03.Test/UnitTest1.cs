using System;
using NUnit.Framework;

namespace NET.W._2019.Khadasevich._11._03.Test
{
    [TestFixture]
    public class BinarySearchTests
    {
        [TestCaseSource("ParametersCases")]
        public void BinarySearch_Valid<T, U>(U expectedResult, T[] array, T searchedValue)
        {
            Assert.AreEqual(expectedResult, BinarySearch.Search(array, searchedValue));
        }

        public static object[] ParametersCases =
        {
            new object[] { 6, new int[] { 1, 10, 2, 6 }, 6 },
            new object[] { "cat", new string[] {"cat", "dog", "cow", "pet"}, "cat" },
            new object[] { -1, new int[] { -1, 10, 2, 6 }, 3 },
            new object[] { -1, new string[] {"cat", "dog", "cow", "pet"}, "frog" },
    };
    }
}
