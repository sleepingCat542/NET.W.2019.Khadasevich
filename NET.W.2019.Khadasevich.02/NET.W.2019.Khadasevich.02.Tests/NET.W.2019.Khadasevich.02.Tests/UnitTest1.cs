using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NET.W._2019.Khadasevich._02.Tests
{
    [TestClass]
    public class MsUnitTest
    {

        //Task1

        [TestMethod]
        public void InsertNumber_ValidData_Test()
        {
            Assert.AreEqual(MathTasks.MathMetods1.InsertNumber(8, 15, 3, 8), 120);
            Assert.AreEqual(MathTasks.MathMetods1.InsertNumber(8, 15, 0, 0), 9);
            Assert.AreEqual(MathTasks.MathMetods1.InsertNumber(15, 15, 0, 0), 15);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void InsertNumber_InvalidData_Test()
        {
            MathTasks.MathMetods1.InsertNumber(8, 15, 8, 3);
        }


        //Task2

        [TestMethod]
        public void FindNextBiggerNumber_ValidData_Test()
        {
            Assert.AreEqual(MathTasks.MathMetods2.FindNextBiggerNumber(12), 21);
            Assert.AreEqual(MathTasks.MathMetods2.FindNextBiggerNumber(513), 531);
            Assert.AreEqual(MathTasks.MathMetods2.FindNextBiggerNumber(2017), 2071);
            Assert.AreEqual(MathTasks.MathMetods2.FindNextBiggerNumber(414), 441);
            Assert.AreEqual(MathTasks.MathMetods2.FindNextBiggerNumber(144), 414);
            Assert.AreEqual(MathTasks.MathMetods2.FindNextBiggerNumber(1234321), 1241233);
            Assert.AreEqual(MathTasks.MathMetods2.FindNextBiggerNumber(1234126), 1234162);
            Assert.AreEqual(MathTasks.MathMetods2.FindNextBiggerNumber(3456432), 3462345);
            Assert.AreEqual(MathTasks.MathMetods2.FindNextBiggerNumber(10), -1);
            Assert.AreEqual(MathTasks.MathMetods2.FindNextBiggerNumber(20), -1);
        }


        //Task4

        private int[] inputArr1 = { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
        private int[] resultArr1 = { 7, 70, 17 };

        [TestMethod]
        public void MathOperations_FilterDigit_ValidData_Test()
        {
            CollectionAssert.AreEqual(MathTasks.MathMetods4.FilterDigit(inputArr1, 7), resultArr1);
        }

        //Task5

        [TestMethod]
        public void FindNthRootTest()
        {
            Assert.AreEqual(MathTasks.MathMetods5.FindNthRoot(1, 5, 0.0001), 1);
            Assert.AreEqual(MathTasks.MathMetods5.FindNthRoot(8, 3, 0.0001), 2);
            Assert.AreEqual(MathTasks.MathMetods5.FindNthRoot(0.001, 3, 0.0001), 0.1);
            Assert.AreEqual(MathTasks.MathMetods5.FindNthRoot(0.04100625, 4, 0.0001), 0.45);
            Assert.AreEqual(MathTasks.MathMetods5.FindNthRoot(8, 3, 0.0001), 2);
            Assert.AreEqual(MathTasks.MathMetods5.FindNthRoot(0.0279936, 7, 0.0001), 0.6);
            Assert.AreEqual(MathTasks.MathMetods5.FindNthRoot(0.0081, 4, 0.1), 0.4);
            Assert.AreEqual(MathTasks.MathMetods5.FindNthRoot(-0.008, 3, 0.1), -0.2);
            Assert.AreEqual(MathTasks.MathMetods5.FindNthRoot(0.004241979, 9, 0.00000001), 0.545);
        }
    }
}
