using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeLib.Tests
{
    class BookComparer : IComparer<Book>
    {
        public int Compare(Book firstBook, Book secondBook)
        {
            if (firstBook == null)
            {
                throw new ArgumentNullException("The book is not initialized.");
            }

            return firstBook.Title.CompareTo(secondBook.Title);
        }
    }
}
