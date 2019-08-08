using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace testing
{
    //testing of quick sorting
    [TestClass]
    public class TaskQuickSort
    {
        [TestMethod]
        public void TestFirst()
        {
            int[] array = { 18, 20, 5, 12, 17, 29, 3, 1};
            int[] arrayTrue = { 1, 3, 5, 12, 17, 18, 20, 29 };
            int index = 3;
            Assert.AreEqual(sorting.ClassLib.QuickSorting(array, 0, array.Length - 1)[index], arrayTrue[index]);
        }
    }

    //testing of merge sorting
    [TestClass]
    public class TaskMergeSort
    {
        [TestMethod]
        public void TestFirst()
        {
            int[] array = { 22, 19, 44, 15, 42, 11, 3 };
            int[] arrayTrue = { 3, 11, 15, 19, 22, 42, 44 };
            int index = 2;
            Assert.AreEqual(sorting.ClassLib.MergeSorting(array)[index], arrayTrue[index]);
        }

    }
}
