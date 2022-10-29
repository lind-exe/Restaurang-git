using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurang
{
    internal class Menu
    {
        List<Dish> menu = new List<Dish>
        {
            new MeatDish("Korv och mos", 20),
            new FishDish("Sushi", 80),
            new VegoDish("Vegoschnitzel med pommes", 50)
        };
    } // Slut Menu
    internal class Dish
    {
        internal string Name { get; set; }
        internal int Price { get; set; }
        internal Dish(string name, int price)
        {
            Name = name;
            Price = price;
        }
    } // Slut Dish

    internal class MeatDish : Dish
    {
        internal MeatDish(string name, int price) : base(name, price)
        {
        }
    } // Slut MeatDish

    internal class FishDish : Dish
    {
        internal FishDish(string name, int price) : base(name, price)
        {
        }
    } // Slut FishDish

    internal class VegoDish : Dish
    {
        internal VegoDish(string name, int price) : base(name, price)
        {
        }
    } // Slut VegoDish
}

