using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
namespace MidTerm_3312
{
        
    public class AppDbContext: DbContext
    {
        
    
        //The connection string is used to connect
        private const string ConnectionString = @"Data Source=MidTermDb.db";

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            //Using the SQLite database 
            optionsBuilder.UseSqlite(ConnectionString);  

        }    
        public DbSet<Author> Author { get; set; } //adding classes to DB
        public DbSet<Book> Book { get; set; }   

    }
}