using System.Collections.Generic;
namespace MidTerm_3312
{
    public class Book 
    {   public int BookID{get;set;}
        public string Title{get;set;}//Properties
        public string Publisher{get;set;}
        public string PublishDate{get;set;}
        public int Pages{get;set;}
        public Author Author { get; set; }
       
        public int AuthorID {get;set;}
         //Foreign Key
        //public Author Author{get;set;}

        public override string ToString()//Prints out Book info minus AuthorID
        {
            string output = "";
            output ="Title: " + this.Title + "\n";
            output +="Publisher: " + this.Publisher + "\n";
            output +="Publish Date: " + this.PublishDate + "\n";
            output +="Author ID: " + this.AuthorID + "\n";
            output +="Pages: " + this.Pages + "\n";
            return output;
        }
    }
}