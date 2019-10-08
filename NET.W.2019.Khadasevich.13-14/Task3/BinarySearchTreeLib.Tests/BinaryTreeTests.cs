using System;
using NUnit.Framework;
using BinarySearchTreeLib;
using System.Linq;
using static BinarySearchTreeLib.Tests.PointComparer;

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

        [Test]
        public void BookBinaryTree_DefaultComparer()
        {
            Book[] books = new Book[] { new Book("C# in Depth", "Jon Skeet"), new Book("Three Comrades", "Erich Maria Remarque"),
                                    new Book("War and Peace", "Leo Tolstoy"), new Book("A Song of Ice and Fire", "George R. R. Martin")};
            BinaryTree<Book> tree = new BinaryTree<Book>(books);

            Book[] expectedResult = new Book[] {books[0], books[3],books[1], books[2] };

            Book[] actualResult = tree.PreOrder().ToArray();

            CollectionAssert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void BookBinaryTree_PluginComparer()
        {
            Book[] books = new Book[] { new Book("C# in Depth", "Jon Skeet"), new Book("Three Comrades", "Erich Maria Remarque"),
                                    new Book("War and Peace", "Leo Tolstoy"), new Book("A Song of Ice and Fire", "George R. R. Martin")};

            IComparer<Book> comparer = new BookComparer();

            BinaryTree<Book> tree = new BinaryTree<Book>(books, comparer.Compare);

            Book[] expectedResult = new Book[] { books[0], books[3], books[1], books[2] };

            Book[] actualResult = tree.PreOrder().ToArray();

            CollectionAssert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void PointBinaryTree_DefaultComparer()
        {
            Point[] points = new Point[] { new Point(5,5), new Point(1, 3), new Point(2,8), new Point(0,3)};
            BinaryTree<Point> tree = new BinaryTree<Point>(points);

            Point[] expectedResult = new Point[] {points[0], points[2], points[1], points[3]  };

            Point[] actualResult = tree.PreOrder().ToArray();

            CollectionAssert.AreEqual(actualResult, expectedResult);
        }

        [Test]
        public void PointBinaryTree_PluginComparer()
        {
            Point[] points = new Point[] { new Point(5, 5), new Point(1, 3), new Point(2, 8), new Point(0, 3) };

            IComparer<Point> comparer = new PointComparer();
            BinaryTree<Point> tree = new BinaryTree<Point>(points, comparer.Compare);

            Point[] expectedResult = new Point[] { points[0], points[2], points[1], points[3] };

            Point[] actualResult = tree.PreOrder().ToArray();

            CollectionAssert.AreEqual(actualResult, expectedResult);
        }


    }
}
