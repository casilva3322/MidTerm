using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using System.Linq;

namespace MidTerm_3312
{
    public  class SeedDatabase
    {
        public static void CreateSeedDatabase()
        {
            using(var db = new AppDbContext())
            {
                db.Database.EnsureCreated();

                if(!db.Author.Any())
                {
                    List<Author> authors = new List<Author>()
                    {
                        new Author()
                        {   
                            AuthorID = 1,
                            AuthorFName = "Adam",
                            AuthorLName = "Freeman"
                        },
                        new Author()
                        {   
                            AuthorID = 2,
                            AuthorFName = "Haishi",
                            AuthorLName = "Bai"
                        }
                        
                    };
                    db.Author.AddRange(authors);
                    db.SaveChanges(); 
                   
                }    

                if(!db.Book.Any())
                {
                    List<Book> books = new List<Book>()
                    {
                        new Book()
                        {   BookID = 1,
                            Title = "Pro ASP.NET Core MVC 2 7th ed. Edition",
                            Publisher = "Apress",
                            PublishDate = "October 25,2017",
                            AuthorID = 1,
                            Pages = 1017
                        },
                        new Book()
                        {   BookID = 2,
                            Title = "Pro Angular 6 3rd Edition",
                            Publisher = "Apress",
                            PublishDate = "October 10, 2018",
                            AuthorID = 1,
                            Pages = 776
                        },
                        new Book()
                        {   BookID = 3,
                            Title = "Programming Microsoft Azure Service Fabric (Developer Reference) 2nd Edition",
                            Publisher = "Microsoft Press",
                            PublishDate = "May 25, 2018",
                            AuthorID = 2,
                            Pages = 528
                        },
                    };
                    db.Book.AddRange(books);
                    db.SaveChanges();
                }
            }
        }
    }
}