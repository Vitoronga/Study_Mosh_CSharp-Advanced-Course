using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Mosh_CSharp_Advanced.Generics
{
    public class Book
    {
        public string Isbn { get; set; }

        public Book(string isbn)
        {
            Isbn = isbn;
        }
    }
}
