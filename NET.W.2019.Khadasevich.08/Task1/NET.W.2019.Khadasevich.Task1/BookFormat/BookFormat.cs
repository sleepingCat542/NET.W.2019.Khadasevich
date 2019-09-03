using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Khadasevich.Task1
{
    /// <summary>
    /// Inialize class of custom format <see cref="Book"/>
    /// </summary>
    public class BookFormat : IFormatProvider, ICustomFormatter
    {
        private IFormatProvider root;

        public BookFormat() : this(CultureInfo.CurrentCulture) { }

        public BookFormat(IFormatProvider provider)
        {
            this.root = provider;
        }

        /// <summary>
        /// Method that supports custom formating of the value of a book.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="arg">The vslue for format (Book)</param>
        /// <param name="formatProvider">The fprmat provider.</param>
        /// <returns>Formating string.</returns>
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (string.IsNullOrEmpty(format))
                format = "DEF";
            
            if (arg == null)
                throw new ArgumentNullException(nameof(arg), "Value can not be undefined");

            if (formatProvider == null)
                formatProvider = CultureInfo.CurrentCulture;


            Book book = arg as Book;
            if (ReferenceEquals(book, null))
            {
                throw new Exception("Value must be of type Book.");
            }

            switch (format.ToUpperInvariant())
            {
                case "DEF":
                    return book.ToString();
                case "SH":
                    return $"{book.ISBN} - {book.Author} - {book.Name}";
                case "COST":
                    return $"{book.ISBN} - {book.Name} - {book.Price}";
                case "PUB":
                    return $"{book.Author} - {book.Name} - {book.PublishingHouse} - {book.YearPublish}";
                default:
                    throw new FormatException($"Incorrect string format {format}");
            }
        }

        /// <summary>
        /// Returns current format provider.
        /// </summary>
        /// <param name="formatType">The format type.</param>
        /// <returns>Current format provider.</returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
    }
}
