using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Khadasevich.Task1
{
    /// <summary>
    /// Provides work with book list
    /// </summary>
    class BookListService
    {
        Logger logger = LogManager.GetCurrentClassLogger();

        string pathToFile;
        List<Book> books;

        /// <summary>
        /// Initialize a new instance of BookListService
        /// </summary>
        /// <param name="path">path of Book Storage</param>
        public BookListService(string path)
        {
            pathToFile = path;
            FileInfo f = new FileInfo(pathToFile);
            using (BinaryWriter bw = new BinaryWriter(f.Open(FileMode.OpenOrCreate,
                FileAccess.ReadWrite, FileShare.None))) { }
            books = GetList();
        }


        /// <summary>
        /// Adds book 
        /// </summary>
        public void AddBook()
        {
            logger.Info("Add book");
            logger.Debug("Add book information");

            Console.Write("Автор: ");
            string author = Console.ReadLine();
            Console.Write("Название: ");
            string name = Console.ReadLine();
            Console.Write("Издательство: ");
            string pubHouse = Console.ReadLine();
            Console.Write("Год публикации: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Число страниц: ");
            int pages = Convert.ToInt32(Console.ReadLine());
            Console.Write("Цена: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());


            logger.Debug("Сheck the existence of the book");

            if (CheckBook(author, name, pubHouse, year))
                throw new Exception("Данная книга существует");


            logger.Debug("Write a book in the file");

            FileInfo file = new FileInfo(pathToFile);
            int isbn = 0;
            using (BinaryWriter writer = new BinaryWriter(file.Open(FileMode.Append,
                        FileAccess.Write, FileShare.None)))
            {
                if (books.Count != 0)
                    isbn = books.LastOrDefault().ISBN + 6;
                writer.Write(isbn);
                writer.Write(author);
                writer.Write(name);
                writer.Write(pubHouse);
                writer.Write(year);
                writer.Write(pages);
                writer.Write(price);
            }


            logger.Debug("Write a book in list");

            Book book = new Book(isbn, author, name, pubHouse, year, pages, price);
            books.Add(book);

            logger.Info("Book added successfully");
            Console.WriteLine("Книга добавлена");
        }

        /// <summary>
        /// Adds book 
        /// </summary>
        /// <param name="author">Tags Author</param>
        /// <param name="name">Tags Name</param>
        /// <param name="pubHouse">Tags publishingHouse</param>
        /// <param name="year">Tags YearPublish</param>
        /// /// <param name="pages">Tags pages</param>
        /// <param name="price">Tags Price</param>
        public void AddBook(string author, string name, string pubHouse,int year, int pages, decimal price)
        {
            logger.Info("Add book");
            logger.Debug("Сheck the existence of the book");

            if (CheckBook(author, name, pubHouse, year))
                throw new Exception("Данная книга существует");


            logger.Debug("Write a book in the file");

            FileInfo file = new FileInfo(pathToFile);
            int isbn = 0;
            using (BinaryWriter writer = new BinaryWriter(file.Open(FileMode.Append,
                        FileAccess.Write, FileShare.None)))
            {
                if (books.Count != 0)
                    isbn = books.LastOrDefault().ISBN + 6;
                writer.Write(isbn);
                writer.Write(author);
                writer.Write(name);
                writer.Write(pubHouse);
                writer.Write(year);
                writer.Write(pages);
                writer.Write(price);
            }

            logger.Debug("Write a book in list");

            Book book = new Book(isbn, author, name, pubHouse, year, pages, price);
            books.Add(book);

            logger.Info("Book added successfully");
            Console.WriteLine("Книга добавлена");
        }



        /// <summary>
        /// Removes book 
        /// </summary>
        public void RemoveBook()
        {
            logger.Info("Remove book");
            logger.Debug("Add book information");

            Console.Write("Автор: ");
            string author = Console.ReadLine();
            Console.Write("Название: ");
            string name = Console.ReadLine();
            Console.Write("Издательство: ");
            string pubHouse = Console.ReadLine();
            Console.Write("Год публикации: ");
            int year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Число страниц: ");
            int pages = Convert.ToInt32(Console.ReadLine());
            Console.Write("Цена: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());

            logger.Debug("Сheck the existence of the book");
            if (CheckBook(author, name, pubHouse, year))
            {
                logger.Debug("Remove book from list");
                foreach (var book in books)
                {
                    if (author == book.Author && name == book.Name &&
                       pubHouse == book.PublishingHouse && year == book.YearPublish &&
                       pages == book.PageCount && price == book.Price)
                    {
                        books.Remove(book);
                        Console.WriteLine("Книга удалена");
                        break;
                    }
                }

                logger.Debug("Overwrite file");
                FileInfo file = new FileInfo(pathToFile);
                using (BinaryWriter writer = new BinaryWriter(file.Open(FileMode.Truncate,
                       FileAccess.Write, FileShare.None)))
                {
                    foreach (var book in books)
                    {
                        writer.Write(book.ISBN);
                        writer.Write(book.Author);
                        writer.Write(book.Name);
                        writer.Write(book.PublishingHouse);
                        writer.Write(book.YearPublish);
                        writer.Write(book.PageCount);
                        writer.Write(book.Price);
                    }
                }
            }
            else
            {
                logger.Error($"Book with this name ({name}) is not found.");
                throw new Exception("Такая книга не найдена");
            }
        }

        /// <summary>
        /// checks for a book in the list
        /// </summary>
        /// <param name="author">Tags Author</param>
        /// <param name="name">Tags Name</param>
        /// <param name="house">Tags publishingHouse</param>
        /// <param name="year">Tags YearPublish</param>
        /// <returns>true if the book is listed</returns>    
        private bool CheckBook(string author, string name, string house, int year)
        {
            foreach (var book in books)
            {
                if (author == book.Author && name == book.Name &&
                   house == book.PublishingHouse && year == book.YearPublish)
                {
                    logger.Info("Book exists");
                    return true;
                }
            }
            logger.Info("Book doesn't exist");
            return false;
        }

        /// <summary>
        /// find a book by ISNN
        /// </summary>
        /// <param name="isbn">Tags ISBN</param>
        /// <returns>book</returns>
        public Book FindBookByTag(int isbn)
        {
            foreach (var book in books)
            {
                if (book.ISBN == isbn)
                {
                    Console.WriteLine(book);
                    logger.Info("Book found");
                    return book;
                }
            }
            logger.Error("Book doesn't find");
            throw new Exception("Книга не найдена");
        }


        /// <summary>
        /// find a book by name and author
        /// </summary>
        /// <param name="name">Tags name</param>
        /// <param name="author">Tags author</param>
        /// <returns>book</returns>
        public Book FindBookByTag(string name, string author)
        {
            foreach (var book in books)
            {
                if (book.Name == name && book.Author == author)
                {
                    Console.WriteLine(book);
                    logger.Info("Book found");
                    return book;
                }
            }
            logger.Error("Book doesn't find");
            throw new Exception("Книга не найдена");
        }
   
        /// <summary>
        /// show list of books
        /// </summary>
        public void ShowList()
        {
            BookFormat f=new BookFormat();
            foreach (var b in books)
            {
                Console.WriteLine(f.Format("SH", b, null));
            }
            if (books.Count == 0)
            {
                logger.Error("List is empty");
                Console.WriteLine("Список пуст !");
            }
        }

        /// <summary>
        /// sort a list of books by a given criterion
        /// </summary>
        public void SortByTag()
        {
            logger.Info("Sort menu");
            IEnumerable<Book> sortedBook = new List<Book>();
            Console.Write("Сортировать по: \n(1) ISBN, \n(2)Названию," +
                " \n(3) Автору, \n(4)Издательству," +
                " \n(5) Году публикации," +
                " \n(6) Числу страниц, \n(7) Цене:  ");
            int tag = Convert.ToInt32(Console.ReadLine());
            logger.Debug($"Chose {tag} item");
            Console.WriteLine();
            switch (tag)
            {
                case 1:
                    sortedBook=books.OrderBy(x => x.ISBN).ToList();
                    break;

                case 2:
                    books = books.OrderBy(x => x.Name).ToList();
                    break;
                case 3:
                    books = books.OrderBy(x => x.Author).ToList();
                    break;
                case 4:
                    books = books.OrderBy(x => x.PublishingHouse).ToList();
                    break;
                case 5:
                    books = books.OrderBy(x => x.YearPublish).ToList();
                    break;
                case 6:
                    books = books.OrderBy(x => x.PageCount).ToList();
                    break;
                case 7:
                    books = books.OrderBy(x => x.Price).ToList();
                    break;

            }

            logger.Info(" Books sorted");
            Console.WriteLine("Книги отсортированы !");
        }

        /// <summary>
        /// write books from file to list Books
        /// </summary>
        /// <returns>Books</returns>
        public List<Book> GetList()
        {
            logger.Info("Get list");
            List<Book> Books = new List<Book>();
            FileInfo file = new FileInfo(pathToFile);
            using (BinaryReader reader = new BinaryReader(file.OpenRead()))
            {
                while (reader.PeekChar() > -1)
                {
                    int isbn = reader.ReadInt32();
                    string author = reader.ReadString();
                    string name = reader.ReadString();
                    string publishingHouse = reader.ReadString();
                    int yearPublish = reader.ReadInt32();
                    int countPages = reader.ReadInt32();
                    decimal price = reader.ReadDecimal();
                    Books.Add(new Book(isbn, author, name, publishingHouse, yearPublish, countPages, price));
                }
            }
            return Books;
        }
    }
}

    