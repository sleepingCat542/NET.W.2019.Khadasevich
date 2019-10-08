using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeLib.Tests
{
    /// <summary>
    /// Class that represents book entity
    /// </summary>
    public class Book : IComparable<Book>
    {
        /// <summary>
        /// A field to hold author name
        /// </summary>
        private string author;

        /// <summary>
        /// A field to hold title of the book
        /// </summary>
        private string title;

        /// <summary>
        /// Initializes a new instanceof the <see cref="Book"/> with specified parametres
        /// </summary>
        /// <param name="author">Author's name</param>
        /// <param name="title">Title</param>
        public Book(string title, string author)
        {
            Author = author;
            Title = title;
        }

        /// <summary>
        /// Gets or sets author's name
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when author's name is null or empty</exception>
        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Author string is empty.");
                }
                else
                {
                    author = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets title of the book
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown when title string is null or empty</exception>
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Title string is empty.");
                }
                else
                {
                    title = value;
                }
            }
        }

        /// <summary>
        /// Compares this book to the specified book by titles
        /// </summary>
        /// <param name="other">Specified book to compare</param>
        /// <returns>1 if this book title comes before other book title alphabetically.
        /// 0 if the books titles are equal. -1 if this book title comes after other
        /// book title alphabetically.</returns>
        /// <exception cref="ArgumentNullException">Thrown when book to compare is not initialized.</exception>
        public int CompareTo(Book other)
        {
            if (other == null)
            {
                throw new ArgumentNullException("The book is not initialized.");
            }

            return title.CompareTo(other.Title);
        }
    }
}
