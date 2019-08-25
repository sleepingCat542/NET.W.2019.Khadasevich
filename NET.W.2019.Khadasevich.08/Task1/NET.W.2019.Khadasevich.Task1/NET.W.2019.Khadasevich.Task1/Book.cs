using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Khadasevich.Task1
{
    public class Book : IEquatable<Book>, IComparer<Book>
    {
        public int ISBN { get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public string PublishingHouse { get; set; }

        private int yearPublish;
        /// <summary>
        /// Year of publishing
        /// </summary>
        public int YearPublish
        {
            get { return yearPublish; }
            set
            {
                if (value > DateTime.Now.Year)
                    throw new Exception("Неверная дата " + DateTime.Now.Year);  //The book can't be in the future
                yearPublish = value;
            }
        }

        private int pageCount;
        /// <summary>
        /// Page count
        /// </summary>
        public int PageCount
        {
            get { return pageCount; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException($"количество страниц должно быть больше 0!");
                }

                pageCount = value;
            }
        }

        private decimal price;
        /// <summary>
        /// Price
        /// </summary>
        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Цена должна быть положительным числом");
                }

                price = value;
            }
        }


        /// <summary>
        /// Create new instance of book
        /// </summary>
        /// <param name="isbn">Book id</param>
        /// <param name="author">Author</param>
        /// <param name="name">Book name</param>
        /// <param name="publishingHouse">Publishing House</param>
        /// <param name="yearPublish">Year of publishing</param>
        /// <param name="pageCount">Page count</param>
        /// <param name="price">Price of book</param>
        public Book(int isbn, string author, string name, string publishingHouse, int yearPublish, int pageCount, decimal price)
        {
            this.ISBN = isbn;
            this.Author = author;
            this.Name = name;
            this.PublishingHouse = publishingHouse;
            this.YearPublish = yearPublish;
            this.PageCount = pageCount;
            this.Price = price;
        }


        #region ToString

        public override string ToString()
        {
            string str = "ISBN: " + this.ISBN +
                 "\nAuthor: " + this.Author +
                 "\nName: " + this.Name +
                 "\nPublishing house: " + this.PublishingHouse +
                 "\nYear publish: " + this.YearPublish +
                 "\nNumber of pages: " + this.PageCount +
                 "\nPrice: " + this.Price + '\n';
            return str;
        }

        #endregion

        #region Equals

        public override int GetHashCode()
        {
            return ISBN.GetHashCode() + Author.GetHashCode() +
                Name.GetHashCode() + PublishingHouse.GetHashCode()
                + YearPublish.GetHashCode() + PageCount.GetHashCode() + Price.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            else
            {
                Book book = (Book)obj;
                if (this.ISBN != book.ISBN) return false;
                else
                {
                    if (this.Name != book.Name) return false;
                    else
                    {
                        if (this.Author != book.Author) return false;
                        else
                        {
                            if (this.YearPublish != book.YearPublish) return false;
                            else
                            {
                                if (this.PageCount != book.PageCount) return false;
                                else return true;
                            }
                        }
                    }
                }
            }
        }

        public bool Equals(Book other)
        {
            if (!(other is Book))
                return false;
            return this.Equals((object)other);
        }
        #endregion

        public int Compare(Book b1, Book b2)
        {
            if (b1.ISBN > b2.ISBN)
                return 1;
            if (b1.ISBN < b2.ISBN)
                return -1;
            else
                return 0;
        }


        public static bool operator ==(Book b1, Book b2)
        {
            return b1.Equals((object)b2);
        }


        public static bool operator !=(Book b1, Book b2)
        {
            return !b1.Equals((object)b2);
        }

    }
}


