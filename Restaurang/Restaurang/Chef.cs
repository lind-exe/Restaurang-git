using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Chef : Person
    {
        public List<Menu> WorkOrder = new List<Menu>();

        public int Skills { get; set; }

        public Chef()
        {
            Random rnd = new Random();
            Skills = rnd.Next(0, 6);
        }
    }
}
