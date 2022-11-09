using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Restaurant
{
    internal class Waiter : Person
    {
        public Order Order { get; set; }
        public int Busy { get; set; }

        public int ServiceLevel { get; set; }
        public int CleaningTime { get; set; }
        public int IdlePosFromLeft { get; set; }

        public Waiter()
        {
            Random rnd = new Random();
            ServiceLevel = rnd.Next(1, 6);
            CleaningTime = 3;
        }
        public void Position()
        {
            IdlePosFromLeft = 
        }
        //public static void DrawWaiter(Waiter waiter)
        //{
        //    if (waiter.Order != null)
        //    {
        //        int orderSize = waiter.Order.FoodOrder.Count;
        //        string[] graphics = new string[orderSize + 1];
        //        for (int i = 0; i < orderSize; i++)
        //        {
        //            graphics[i] = (waiter.Order.FoodOrder.ElementAt(i) as Food).Name;
        //        }
        //        graphics[orderSize] = waiter.Name +" är upptagen i " + waiter.Busy + " tick ";
        //        GUI.Window.Draw(waiter.Name, waiter.IdlePosFromLeft, 40, graphics);
        //    }
        //    else
        //    {
        //        string[] graphics = new string[1];
        //        graphics[0] = "";
        //        GUI.Window.Draw(waiter.Name, waiter.IdlePosFromLeft, 40, graphics);

        //    }
        //}
    }
}
