using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueLib
{
    /// <summary>
    /// Represents a class providing queue iterator
    /// </summary>
    /// <typeparam name="T">Type of queue elements</typeparam>
    public class QueueIterator<T>
    {
        /// <summary>
        /// A field to hold reference to the queue container
        /// </summary>
        private readonly Queue<T> collection;

        /// <summary>
        /// A field to hold current index
        /// </summary>
        private int currentIndex;


        /// <summary>
        /// Initializes a new instance of the <see cref="QueueIterator{T}"/> with specified container
        /// </summary>
        /// <param name="collection">Queue container</param>
        public QueueIterator(Queue<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Collection is null.");
            }

            currentIndex = -1;
            this.collection = collection;
        }


        /// <summary>
        /// Gets current queue element
        /// </summary>
        public T Current
        {
            get
            {
                if (currentIndex == -1 || currentIndex > collection.Size)
                {
                    throw new ArgumentOutOfRangeException("Index is out of range.");
                }
                return collection[currentIndex];
            }
        }



        /// <summary>
        /// Resets current queue index
        /// </summary>
        public void Reset()
        {
            currentIndex = -1;
        }

        /// <summary>
        /// Increases current queue index
        /// </summary>
        /// <returns>False if the current element is the last element in the queue. True otherwise</returns>
        public bool MoveNext()
        {
            if (currentIndex < collection.Size)
            {
                currentIndex++;
                return currentIndex < collection.Size;
            }

            return false;
        }

    }
}
