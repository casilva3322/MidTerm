using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace MidTerm_3312
{
    class Program
    {   
        public static void ReadBookFromDB()
        {   //1) In your program, connect to the database and show all records in the Books table, 
            //print this to the Console
            Console.WriteLine("Printing the records in the Book table:\n");
            using(var db = new AppDbContext())
            {
                var bookTable = from b in db.Book
                                select b;
                foreach(var b in bookTable)
                {
                    Console.WriteLine(b);
                }                
                
            }
        }
    
        //2)In your program, connect to the database and 
        //show all records of Books Published by "APress"
    
        public static void FindPublisher()
        {
            Console.WriteLine("Printing all Books published by Apress:\n");
            using(var db = new AppDbContext())
            {
                var bookTable = from b in db.Book
                                where b.Publisher == "Apress"
                                select b;
                foreach(var b in bookTable)
                {
                    Console.WriteLine(b);
                }    
            }
        }
    

         //3) In your program, connect to the database and show all records of Books 
         //whose author's first name is the shortest 
        //Join statement to get records from both tables
    
    
        public static void FindShortName()
        {
            Console.WriteLine("Printing all Books with the shortest Author First Name:\n");
            using(var db = new AppDbContext())
            {
                var bookTable = db.Book.Join(db.Author, 
                a => a.AuthorID,
                 d => d.AuthorID,
                 (a,d) => new{
                 
                                Title = a.Title,
                                Publisher = a.Publisher,
                                PublishDate = a.PublishDate,
                                Pages = a.Pages,
                                AuthorFName = d.AuthorFName,
                                AuthorLName = d.AuthorFName
                                });
            
        
                                
                var sName = bookTable.Min(d => d.AuthorFName);      
                var s = bookTable.Where(a => a.AuthorFName == sName);
                foreach(var b in s) 
                {
                Console.WriteLine(b);
                }  
            }
        }
        //1.In your program, onnect to the database and find the first book by an author named 
        //"Adam" and print that record to the screen
        public static void FindBookWrittenBy()
        {
            using (var db = new AppDbContext()) 
            {
                var bookTable = db.Book.Join(
                                            db.Author, 
                                            a => a.AuthorID, 
                                            b => b.AuthorID, 
                                            (a, b) => new {
                                            Title = a.Title,
                                            Publisher = a.Publisher,
                                            PublishDate = a.PublishDate,
                                            Pages = a.Pages,
                                            AuthorFName = b.AuthorFName,
                                            AuthorLName = b.AuthorLName
                                            }).ToList();
                Console.WriteLine(bookTable.Find(b => b.AuthorFName == "Adam"));        
             } 
              
        }
        

        //2.In your program, onnect to the database and find the first book by an author named "Adam" 
        //and print that record to the screen

        public static void BookfromAuthor()
        {
            Console.WriteLine("Printing book with the author name Adam: \n");
            using(var db = new AppDbContext())
            {
                var book1 = db.Author.ToList();
                var byAuthor = book1.Where(b => b.AuthorFName == "Adam"); 
                foreach(var b in byAuthor)
                {
                    Console.WriteLine(b);
                }
            }
        }
        //1) Connect to the database and show all Books 
        //sorted by Author's last name
        public static void BooksByAuthorLName()
        {
            using(var db  = new AppDbContext())
            {
                var bookTable = db.Book.Join(
                            db.Author,
                            a => a.AuthorID,
                            b => b.AuthorID,
                            (a,b) => new
                            {
                                Title = a.Title,
                                Publisher = a.Publisher,
                                PublishDate = a.PublishDate,
                                Pages = a.Pages,
                                AuthorFName = b.AuthorFName,
                                AuthorLName = b.AuthorLName
                            });
                    var nameList = bookTable.OrderBy(b => b.AuthorFName);
                    foreach(var b in nameList)
                    {
                        Console.WriteLine(b);
                    }
            
            }
        }
    

    

        //2) In your program, onnect to the database and find the first book 
        //whose page count is greater than 1000
        public static void FindPageCount()
        {
            Console.WriteLine("Printing the first book with over 1000 pages:\n");
            using (var db = new AppDbContext())
            {
                
                var firstBook = from b in db.Book
                                where b.Pages > 1000
                                select b;
                foreach(var b in firstBook)
                {
                    Console.WriteLine(b);
                }
            }
        }
        //Using the LINQ order by Method
        //2) Connect to the database and show all Books 
        //sorted by book title descending
        public static void SortByBookTitle()
        {
            Console.WriteLine("Printing books from Book table in descdending order:\n");
            using(var db = new AppDbContext())
            {
                var bk = from i in db.Book
                orderby i.Title descending
                select i;
                foreach(var b in bk)
                {
                    Console.WriteLine(b);
                }
            }

        }
        //Groupby
        //1) Connect to the database and show all Books Grouped by publisher
        public static void GroupByPublisher()
        {
            Console.WriteLine("Printing books grouped by Publisher:\n");
            using(var db =new AppDbContext())
            {
                var booksGrouped = from b in db.Book
                                   group b by b.Publisher;
                foreach(var g in booksGrouped)
                {
                    foreach(var r in g)
                    {
                        Console.WriteLine(r);
                    }
                }
            }
        }    

        static void Main(string[] args)
        {
            SeedDatabase.CreateSeedDatabase();
            
            ReadBookFromDB();

            FindPublisher();

            FindPageCount();

            SortByBookTitle();

            GroupByPublisher();

            BookfromAuthor();
            FindShortName();
           FindBookWrittenBy();
        }
    }             
} 
 
          
    




