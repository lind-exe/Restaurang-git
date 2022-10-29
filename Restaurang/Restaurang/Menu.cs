using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurang
{
    internal class Menu
    {
        List<Dish> menus = new List<Dish>();
    }
    internal class Dish
    {
        internal string Name { get; set; }
        internal int Price { get; set; }
        internal Dish(string name, int price)
        {
            Name = name;
            Price = price;
        }
        internal class MeatDish : Dish
        {
            internal MeatDish(string name, int price) : base(name, price)
            {
            }
        }
        internal class FishDish : Dish
        {
            internal FishDish(string name, int price) : base(name, price)
            {
            }
        }
        internal class VegoDish : Dish
        {
            internal VegoDish(string name, int price) : base(name, price)
            {
            }
        }
    }
}

