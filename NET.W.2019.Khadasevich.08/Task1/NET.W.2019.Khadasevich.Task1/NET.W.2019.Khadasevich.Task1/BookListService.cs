using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Khadasevich.Task1
{
    class BookListService
    {
        /// <summary>
        /// Provides work with book list
        /// </summary>

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
            books = GetBooks();
        }


        /// <summary>
        /// Adds book 
        /// </summary>
        public void AddBook()
        {
            FillBookInformation(out string author, out string name,
                                         out string house, out int year,
                                         out int pages, out decimal price);
            if (CheckBookInList(author, name, house, year))
                throw new Exception("Данная книга существует");

            // id is counted from the last book in the file
            FileInfo f = new FileInfo(pathToFile);
            int id = 1;
            using (BinaryWriter bw = new BinaryWriter(f.Open(FileMode.Append,
                        FileAccess.Write, FileShare.None)))
            {

                if (books.Count != 0)
                    id = books.LastOrDefault().ISBN + 1;
                bw.Write(id);
                bw.Write(author);
                bw.Write(name);
                bw.Write(house);
                bw.Write(year);
                bw.Write(pages);
                bw.Write(price);
            }
            Book book = new Book(id, author, name, house, year, pages, price);
            books.Add(book);
            Console.WriteLine("Книга добавлена");
        }


        /// <summary>
        /// Removes book 
        /// </summary>
        public void RemoveBook()
        {
            FillBookInformation(out string author, out string name,
                                         out string house, out int year,
                                         out int pages, out decimal price);

            if (CheckBookInList(author, name, house, year))
            {
                List<Book> bs = new List<Book>();

                foreach (var book in books)
                {
                    if (author == book.Author && name == book.Name &&
                       house == book.PublishingHouse && year == book.YearPublish &&
                       pages == book.PageCount && price == book.Price)
                    {
                        books.Remove(book);
                        Console.WriteLine("Книга удалена");
                        break;

                    }
                }
                FileInfo f = new FileInfo(pathToFile);
                using (BinaryWriter bw = new BinaryWriter(f.Open(FileMode.Truncate,
                       FileAccess.Write, FileShare.None)))
                {

                    foreach (var book in books)
                    {
                        bs.Add(book);


                        bw.Write(book.ISBN);
                        bw.Write(book.Author);
                        bw.Write(book.Name);
                        bw.Write(book.PublishingHouse);
                        bw.Write(book.YearPublish);
                        bw.Write(book.PageCount);
                        bw.Write(book.Price);
                    }
                }
                books = bs;
            }
            else
            {
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

        private bool CheckBookInList(string author, string name, string house, int year)
        {
            foreach (var book in books)
            {
                if (author == book.Author && name == book.Name &&
                   house == book.PublishingHouse && year == book.YearPublish)
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// checks for a book in the list
        /// </summary>
        /// <param name="author">Tags Author</param>
        /// <param name="name">Tags Name</param>
        /// <param name="house">Tags publishingHouse</param>
        /// <param name="year">Tags YearPublish</param>
        /// <param name="pages">Tags PageCount</param>
        /// <param name="price">Tags Price</param>

        private void FillBookInformation(out string author, out string name,
                                         out string house, out int year,
                                         out int pages, out decimal price)
        {
            Console.Write("Автор: ");
            author = Console.ReadLine();
            Console.Write("Название: ");
            name = Console.ReadLine();
            Console.Write("Издательство: ");
            house = Console.ReadLine();
            Console.Write("Год публикации: ");
            year = Convert.ToInt32(Console.ReadLine());
            Console.Write("Число страниц: ");
            pages = Convert.ToInt32(Console.ReadLine());
            Console.Write("Цена: ");
            price = Convert.ToDecimal(Console.ReadLine());
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
                    return book;
                }
            }

            throw new Exception("Книга не найдена");
        }


        /// <summary>
        /// find a book by ISNN
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
                    return book;
                }
            }

            throw new Exception("Книга не найдена");
        }

        /// <summary>
        /// find a book by ISNN
        /// </summary>
        /// <param name="name">Tags name</param>
        /// <param name="author">Tags author</param>
        /// <param name="year">Tags year Publish</param>
        /// <returns>book</returns>
        public Book FindBookByTag(string name, string author, int yearPublish)
        {
            foreach (var book in books)
            {
                if (book.Name == name && book.Author == author && book.YearPublish == yearPublish)
                {
                    Console.WriteLine(book);
                    return book;
                }
            }

            throw new Exception("Книга не найдена");
        }

        /// <summary>
        /// show list of books
        /// </summary>
        public void ShowList()
        {
            foreach (var b in books)
            {
                Console.WriteLine(b);
            }
            if (books.Count == 0)
                Console.WriteLine("Список пуст !");
        }

        /// <summary>
        /// sort a list of books by a given criterion
        /// </summary>
        public void SortByTag()
        {
            IEnumerable<Book> sortedBook = new List<Book>();
            Console.Write("Сортировать по: (1) ISBN, (2)Названию," +
                " (3) Автору, (4)Издательству," +
                " (5) Году публикации," +
                " (6) Числу страниц, (7) Цене:  ");
            int tag = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            switch (tag)
            {
                case 1:
                    sortedBook = from b in books
                                 orderby b.ISBN
                                 select b;
                    break;

                case 2:
                    sortedBook = from b in books
                                 orderby b.Name
                                 select b;
                    break;
                case 3:
                    sortedBook = from b in books
                                 orderby b.Author
                                 select b;
                    break;
                case 4:
                    sortedBook = from b in books
                                 orderby b.PublishingHouse
                                 select b;
                    break;
                case 5:
                    sortedBook = from b in books
                                 orderby b.YearPublish
                                 select b;
                    break;
                case 6:
                    sortedBook = from b in books
                                 orderby b.PageCount
                                 select b;
                    break;
                case 7:
                    sortedBook = from b in books
                                 orderby b.Price
                                 select b;
                    break;

            }

            books = sortedBook.ToList();
            Console.WriteLine("Книги отсортированы !");
        }

        /// <summary>
        /// write books from file to list Books
        /// </summary>
        /// <returns>Books</returns>
        public List<Book> GetBooks()
        {
            List<Book> Books = new List<Book>();
            FileInfo f = new FileInfo(pathToFile);
            using (BinaryReader br = new BinaryReader(f.OpenRead()))
            {

                while (br.PeekChar() > -1)
                {
                    int isbn = br.ReadInt32();
                    string author = br.ReadString();
                    string name = br.ReadString();
                    string publishingHouse = br.ReadString();
                    int yearPublish = br.ReadInt32();
                    int pages = br.ReadInt32();
                    decimal price = br.ReadDecimal();
                    Books.Add(new Book(isbn, author, name, publishingHouse, yearPublish, pages, price));
                }
            }
            return Books;
        }
    }
}

    