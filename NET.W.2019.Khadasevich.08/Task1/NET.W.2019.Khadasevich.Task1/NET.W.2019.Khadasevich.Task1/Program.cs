using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.W._2019.Khadasevich.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            BookListService service = new BookListService("storage.dat");
            while (true)
            {
                try
                {
                    int number = 0;
                    Console.Write(" (1)Добавить книгу,\n (2) Удалить книгу,\n (3)Показать книги,\n (4)Найти книгу,\n (5)Отсортировать по критерию:    ");
                    number = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    switch (number)
                    {
                        case 1:
                            service.AddBook();
                            break;
                        case 2:
                            service.RemoveBook();
                            break;
                        case 3:
                            service.ShowList();
                            break;
                        case 4:
                            Console.Write(" (1)Поиск по ISBN,\n (2) Поиск по названию и автору,\n" +
                            " (3)  Поиск по названию, автору и году публикации:   ");
                            number = Convert.ToInt32(Console.ReadLine());
                            if (number == 1)
                            {
                                Console.Write("Введите ISBN: ");
                                int id = Convert.ToInt32(Console.ReadLine());
                                service.FindBookByTag(id);
                            }
                            if (number == 2)
                            {
                                Console.Write("Введите название: ");
                                string name = Console.ReadLine();
                                Console.Write("Введите автора: ");
                                string author = Console.ReadLine();
                                service.FindBookByTag(name, author);
                            }
                            if (number == 3)
                            {
                                Console.Write("Введите название: ");
                                string name = Console.ReadLine();
                                Console.Write("Введите автора: ");
                                string author = Console.ReadLine();
                                Console.Write("Введите год публикации: ");
                                int year = Convert.ToInt32(Console.ReadLine());
                                service.FindBookByTag(name, author, year);
                            }
                            break;
                        case 5:
                            service.SortByTag();
                            break;
                    }
                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
