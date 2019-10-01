using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NET.W._2019.Khadasevich._24._01.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "The Girl in Room 105", Author = "Chetan Bhagat", Price = 30 });
            db.Books.Add(new Book { Name = "The Alchemist", Author = "Paulo Coelho", Price = 20 });
            db.Books.Add(new Book { Name = "The Great Gatsby", Author = "F. Scott Fitzgerald", Price = 15 });

            base.Seed(db);
        }
    }
}