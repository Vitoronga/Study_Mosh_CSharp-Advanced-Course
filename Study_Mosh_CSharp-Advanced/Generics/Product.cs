using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Study_Mosh_CSharp_Advanced.Generics
{
    public class Product
    {
        public int Price { get; set; }
        public string Title { get; set; }

        public Product(int price, string title)
        {
            Price = price;
            Title = title;
        }


    }
}
