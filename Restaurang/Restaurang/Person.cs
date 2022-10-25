using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurang
{
    internal class Person
    {
        public string Name { get; set; }
        public int AmountOfPeople { get; set; }

        

        public Person()
        {

        }
    }

    internal class Guest : Person
    {
        public int AmountOfCompany { get; set; }
        public double AmountOfMoney { get; set; }
        public int Satisfaction { get; set; }
        public bool Allergic { get; set; }

        public Guest()
        {

        }

    }

    internal class Chef : Person
    {
        public int Skills { get; set; }

        public Chef()
        {

        }

    }

    internal class Waiter : Person
    {
        public int ServiceLevel { get; set; }
        public Waiter()
        {

        }

    }
}
