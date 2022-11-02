using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Waiter : Person
    {
        public List<Food> Orders = new List<Food>();

        public int ServiceLevel { get; set; }
        public Waiter()
        {
            Random rnd = new Random();
            ServiceLevel = rnd.Next(1, 6);
        }

        //public string TakeOrder(Guest guest)
        //{
        //    Random rnd = new Random();

        //    //if (guest.FoodChoice.Count > 0 && guest.Eating == false)
        //    //{
        //    int randomFoodChoice = rnd.Next(0, guest.FoeodChoi.Count); // Slumpmässigt index
        //    Thing stolenThing = victim.Belongings[randomThingIndex];

        //    Orders.AddRange(guest.FoodChoice); // Servitören tar allt från gästens menu

        //    guest.FoodChoice.Clear(); // Rensar gästens beställningslista

        //    // Console.WriteLine("Sällskapet beställde " + Menu.GetType().Name);

        //    //return guest.FoodChoice.Name;
        //    //}
        //    return "";
        //}
    }
}
