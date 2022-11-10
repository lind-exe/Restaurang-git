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
    }
}
