using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurang
{
    internal class Menu
    {
        List<Dish> dishes = new List<Dish>
        {
            new MeatDish("Korv och mos", 20, new string[]{"gluten"}),
            new FishDish("Sushi", 80, new string[]{"gluten","fisk"}),
            new VegoDish("Vegoschnitzel med pommes", 50, new string[]{}),
            new FishDish("Fiskgratäng", 50, new string[]{"laktos","fisk"})
        };
    } // Slut Menu
    internal class Dish
    {
        internal string Name { get; set; }
        internal int Price { get; set; }
        internal string[] Allergenes { get; set; }
        internal Dish(string name, int price, string[] allergenes)
        {
            Name = name;
            Price = price;
            Allergenes = allergenes;
        }
    } // Slut Dish

    internal class MeatDish : Dish
    {
        internal MeatDish(string name, int price, string[] allergenes) : base(name, price, allergenes)
        {
        }
    } // Slut MeatDish

    internal class FishDish : Dish
    {
        internal FishDish(string name, int price, string[] allergenes) : base(name, price, allergenes)
        {
        }
    } // Slut FishDish

    internal class VegoDish : Dish
    {
        internal VegoDish(string name, int price, string[] allergenes) : base(name, price, allergenes)
        {
        }
    } // Slut VegoDish
}

