using System;
using System.Globalization;
using NET.W._2019.Khadasevich.Task1;
using NUnit.Framework;

namespace NET.W._2019.Khadasevich._04.BookFormatTest
{
    [TestFixture]
    public class BooksTests
    {
        public static Book book = new Book(11, "Р. Брэдбери", "Вино из одуванчиков", "Эксмо", 2015, 320, 16);

        [TestCase("DEF", ExpectedResult = "ISBN: 11\nAuthor: Р. Брэдбери\nName: Вино из одуванчиков\nPublishing house: Эксмо\nYear publish: 2015\nPage Count: 320\nPrice: 16\n")]
        [TestCase("SH", ExpectedResult = "11 - Р. Брэдбери - Вино из одуванчиков")]
        [TestCase("COST", ExpectedResult = "11 - Вино из одуванчиков - 16")]
        [TestCase("PUB", ExpectedResult = "Р. Брэдбери - Вино из одуванчиков - Эксмо - 2015")]
        [TestCase(null, ExpectedResult = "ISBN: 11\nAuthor: Р. Брэдбери\nName: Вино из одуванчиков\nPublishing house: Эксмо\nYear publish: 2015\nPage Count: 320\nPrice: 16\n")]
        [TestCase("", ExpectedResult = "ISBN: 11\nAuthor: Р. Брэдбери\nName: Вино из одуванчиков\nPublishing house: Эксмо\nYear publish: 2015\nPage Count: 320\nPrice: 16\n")]
        public string ToString_ValidFormat_ValidResult(string format)
        {
            return book.ToString(format);
        }

        [TestCase("SH", "ru-RU", ExpectedResult = "11 - Р. Брэдбери - Вино из одуванчиков")]
        [TestCase("SH", "en-US", ExpectedResult = "11 - Р. Брэдбери - Вино из одуванчиков")]
        public string ToString_ValidFormat_ValidResult(string format, string culture)
        {
            return book.ToString(format, new CultureInfo(culture));
        }

        [TestCase("DEF", ExpectedResult = "ISBN: 11\nAuthor: Р. Брэдбери\nName: Вино из одуванчиков\nPublishing house: Эксмо\nYear publish: 2015\nPage Count: 320\nPrice: 16\n")]
        [TestCase("SH", ExpectedResult = "11 - Р. Брэдбери - Вино из одуванчиков")]
        [TestCase("COST", ExpectedResult = "11 - Вино из одуванчиков - 16")]
        [TestCase("PUB", ExpectedResult = "Р. Брэдбери - Вино из одуванчиков - Эксмо - 2015")]
        [TestCase(null, ExpectedResult = "ISBN: 11\nAuthor: Р. Брэдбери\nName: Вино из одуванчиков\nPublishing house: Эксмо\nYear publish: 2015\nPage Count: 320\nPrice: 16\n")]
        [TestCase("", ExpectedResult = "ISBN: 11\nAuthor: Р. Брэдбери\nName: Вино из одуванчиков\nPublishing house: Эксмо\nYear publish: 2015\nPage Count: 320\nPrice: 16\n")]
        public string Format_ValidFormat_ValidResult(string format)
        {
            return new BookFormat().Format(format, book, null);
        }

        [TestCase("SH", "ru-RU", ExpectedResult = "11 - Р. Брэдбери - Вино из одуванчиков")]
        [TestCase("SH", "en-US", ExpectedResult = "11 - Р. Брэдбери - Вино из одуванчиков")]
        public string Format_ValidFormat_ValidResult(string format, string culture)
        {
            return new BookFormat().Format(format, book, new CultureInfo(culture));
        }

    }
}