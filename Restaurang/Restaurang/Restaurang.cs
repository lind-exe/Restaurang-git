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

        //public List<Person> StaffList { get; set; }           Tanke om man skulle ha en samlad lista med all personal. Fick det inte att fungera //J

        public List<Person> Waiters { get; set; }

        public List<Person> Chefs { get; set; }


        public Restaurant(int guestAmount)
        {
            GuestAmount = guestAmount;
            CreateGuests();
            CreateStaff();
        }

        public Restaurant()
        {

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

        private void CreateStaff()
        {
            //StaffList = new List<Person>();

            Chefs = new List<Person>();

            Waiters = new List<Person>();
            
            for (int i = 0; i < 3; i++)
            {
                Chef chef = new Chef();
                Chefs.Add(chef);
            }

            for (int i = 0; i < 5; i++)
            {
                Waiter waiter = new Waiter();
                Waiters.Add(waiter);
            }

            //foreach (Person waiter in Waiters)
            //{
            //    StaffList.Add(waiter);
            //}
            //foreach (Person chef in Chefs)
            //{
            //    StaffList.Add(chef);
            //}

        }

        

    }
}
