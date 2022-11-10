using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Restaurant
{
    internal class Food
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quality { get; set; }



        public Food(string name, double price, int quality)

        {
            Name = name;
            Price = price;
            Quality = quality;  
        }
 
        internal class Meat : Food
        {
            internal Meat(string name, double price, int quality) : base(name, price, quality)
            {
            }
        }

        internal class Fish : Food
        {
            internal Fish(string name, double price, int quality) : base(name, price, quality)
            { 
            }
        }

        internal class Vego : Food
        {
            internal Vego(string name, double price, int quality) : base(name, price, quality)
            {
            }
        }
    }
}