using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurang
{
    internal class Restaurant
    {
        public int GuestAmount { get; set; }


        public List<Person> Guests { get; set; }
        

        public Restaurant(int guestAmount)
        {
            GuestAmount = guestAmount;
            CreateGuests();
        }

        private void CreateGuests()
        {
            Guests = new List<Person>();

            for (int i = 0; i < GuestAmount; i++)
            {
                Person guest = new Guest();
                Guests.Add(guest);
            }

        }
    }
}
