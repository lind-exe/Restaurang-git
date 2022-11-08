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
        public List<Food> Orders = new List<Food>();

        public int ServiceLevel { get; set; }
        public int CleaningTime { get; set; }
        public int IdlePosFromLeft { get; set; }

        public Waiter()
        {
            Random rnd = new Random();
            ServiceLevel = rnd.Next(1, 6);
            CleaningTime = 3;
        }

        public static void DrawWaiter(Waiter waiter)
        {
            int orderSize = waiter.Orders.Count;
            if (orderSize > 0)
            {
                string[] graphics = new string[orderSize + 1];
                for (int i = 0; i < orderSize; i++)
                {
                    graphics[i] = waiter.Orders.ElementAt(i).Name;
                }
                graphics[orderSize] = "Upptagen ";
                GUI.Window.Draw(waiter.Name, waiter.IdlePosFromLeft, 40, graphics);
            }
            else
            {
                string[] graphics = new string[1];
                graphics[0] = "";
                GUI.Window.Draw(waiter.Name, waiter.IdlePosFromLeft, 40, graphics);
                
            }
        }
    }
}
