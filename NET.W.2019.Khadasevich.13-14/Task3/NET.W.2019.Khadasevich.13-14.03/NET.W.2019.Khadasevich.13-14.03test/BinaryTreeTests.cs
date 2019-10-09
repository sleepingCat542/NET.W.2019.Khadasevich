using System;
using NUnit.Framework;
using BinarySearchTreeLib;
using System.Linq;

namespace BinarySearchTreeLib.Tests
{
    [TestFixture]
    public class BinaryTreeTests
    {
        [Test]
        public void IntBinaryTree_InOrder()
        {
            BinaryTree<int> tree = new BinaryTree<int>(new int[] { 6, 3, 8, 2, 5, 7, 12 });

            int[] expectedResult = new int[] {2, 3, 5, 6, 7, 8, 12 };

            int[] actualResult = tree.InOrder().ToArray();

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void IntBinaryTree_PreOrder()
        {
            BinaryTree<int> tree = new BinaryTree<int>(new int[] { 6, 3, 8, 2, 5, 7, 12 });

            int[] expectedResult = new int[] { 6, 3, 2, 5, 8, 7, 12 };

            int[] actualResult = tree.PreOrder().ToArray();

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void IntBinaryTree_PostOrder()
        {
            BinaryTree<int> tree = new BinaryTree<int>(new int[] { 6, 3, 8, 2, 5, 7, 12 });

            int[] expectedResult = new int[] {2, 5, 3, 7, 12, 8, 6 };

            int[] actualResult = tree.PostOrder().ToArray();

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void IntBinaryTree_PluginComparer()
        {
            BinaryTree<int> tree = new BinaryTree<int>(new int[] {1, 2, 3, 4, 5 }, (i, j) => j - i);

            int[] expectedResult = new int[] { 5, 4, 3, 2, 1 };

            int[] actualResult = tree.InOrder().ToArray();

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void StringBinaryTree_DefaultComparer()
        {
            BinaryTree<string> tree = new BinaryTree<string>(new string[] { "one", "two", "three", "four" });

            string[] expectedResult = new string[] {"one", "four", "two", "three" };

            string[] actualResult = tree.PreOrder().ToArray();

            Assert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void StringBinaryTree_PluginComparer()
        {
            BinaryTree<string> tree = new BinaryTree<string>(new string[] { "one", "two", "three", "four" }, (i, j) => i.CompareTo(j));

            string[] expectedResult = new string[] { "one", "four", "two", "three" };

            string[] actualResult = tree.PreOrder().ToArray();

            Assert.AreEqual(actualResult, expectedResult);
        }

    }
}
