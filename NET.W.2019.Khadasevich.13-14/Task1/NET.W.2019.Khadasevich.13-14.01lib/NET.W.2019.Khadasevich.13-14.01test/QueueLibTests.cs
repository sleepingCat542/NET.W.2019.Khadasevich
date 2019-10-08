using System;
using NUnit.Framework;

namespace QueueLib.Tests
{
    [TestFixture]
    public class QueueLibTests
    {
        [TestCase(new int[] { 1, 3, 8, 12, 15}, ExpectedResult = 5)]
        [TestCase(new int[] { 1, 3}, ExpectedResult = 2)]
        [TestCase(new int[] { 1 }, ExpectedResult = 1)]
        public int Queue_Constructor_Test(params int[] elements)
        { 
            Queue<int> queue = new Queue<int>(elements);
            return queue.Size;
        }

        [TestCase( 6, new int[] { 1, 3, 8, 12, 15 }, ExpectedResult = 6)]
        [TestCase(11, new int[] { 1 }, ExpectedResult = 2)]
        [TestCase(0, new int[] { 1, 3, 8, 12, 15 }, ExpectedResult = 6)]
        public int Queue_Enqueue_Test(int newElement, params int[] elements)
        {
            Queue<int> queue = new Queue<int>(elements);
            queue.Enqueue(newElement);
            return queue.Size;
        }

        [TestCase(new int[] { 1, 3, 8, 12, 15 }, ExpectedResult = 1)]
        [TestCase(new int[] { 2, 10, 12 }, ExpectedResult = 2)]
        [TestCase(new int[] { 8, 12, 14, 13 }, ExpectedResult = 8)]
        public int Queue_Dequeue_Test(params int[] elements)
        {
            Queue<int> queue = new Queue<int>(elements);
            return queue.Dequeue();
        }

        [TestCase(new int[] { 3, 8, 12, 15 }, ExpectedResult = 3)]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = 1)]
        [TestCase(new int[] { 5, 89, 12 }, ExpectedResult = 5)]
        public int Queue_Peek_Test(params int[] elements)
        {
            Queue<int> queue = new Queue<int>(elements);
            return queue.Peek();
        }

        [TestCase(new int[] { 3, 8, 12, 15 }, ExpectedResult = new int[] { 3, 8, 12, 15 })]
        [TestCase(new int[] { 1, 2 }, ExpectedResult = new int[] { 1, 2 })]
        [TestCase(new int[] { 5, 89, 12 }, ExpectedResult = new int[] { 5, 89, 12 })]
        public int[] Queue_Iterator_Test(params int[] elements)
        {
            Queue<int> queue = new Queue<int>(elements);

            int[] resultArray = new int[elements.Length];
            int i = 0;
            QueueIterator<int> iterator = new QueueIterator<int>(queue);
            while(iterator.MoveNext())
            {
                resultArray[i] = iterator.Current;
                i++;
            }

            return resultArray;
        }

        [Test]
        public void Queue_Constructor_ArgumentOutOfRangeExceptionExpected()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new Queue<int>(0));
        }

        [Test]
        public void Queue_Constructor_ArgumentNullExceptionExpected()
        {
            int[] array = null;
            Assert.Throws<ArgumentNullException>(() => new Queue<int>(array));
        }

        [Test]
        public void Queue_Constructor_ArgumentExceptionExpected()
        {
            int[] array = { };
            Assert.Throws<ArgumentException>(() => new Queue<int>(array));
        }
    }
}
