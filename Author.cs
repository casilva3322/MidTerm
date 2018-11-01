
using System.Collections.Generic;
namespace MidTerm_3312
{
    public class Author
    {
        public  int AuthorID{get;set;}//Properties
        public string AuthorFName{get;set;}
        public string AuthorLName{get;set;}
        

        public override string ToString()
        {
            string output = "";
            output = "AuthorID: " + this.AuthorID + "\n";
            output +="Author First Name: " + this.AuthorFName + "\n";
            output +="Author Last Name: " + this.AuthorFName + "\n";
            return output;


        }
    }
}