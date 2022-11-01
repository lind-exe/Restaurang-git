using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Restaurant
    {
        public int TotalGuests { get; set; }
        public int GuestAmount { get; set; }
        public int ChefAmount { get; set; }
        public int WaiterAmount { get; set; }
        public int DuoTableAmount { get; set; }
        public int QuadTableAmount { get; set; }
        public int TimeCounter { get; set; }
        public int GuestsInRestaurant { get; set; }
        public List<string> NewsFeed { get; set; }
        public List<Food> Menu { get; set; }

        public  int MeatAmount { get; set; }

        public int FishAmount { get; set; }

        public int VegoAmount { get; set; }

        //public List<Person> Guests { get; set; }

        //public List<Person> StaffList { get; set; }           Tanke om man skulle ha en samlad lista med all personal. Fick det inte att fungera //J

        public List<Person> PeopleInRestaurant { get; set; }

        //public List<Person> Chefs { get; set; }


        public Restaurant(int guestAmount, int chefAmount, int waiterAmount, int duoTableAmount, int quadTableAmount)
        {
            GuestAmount = guestAmount;
            ChefAmount = chefAmount;
            WaiterAmount = waiterAmount;
            MakePeopleInRestaurant();
            DuoTableAmount = duoTableAmount;
            QuadTableAmount = quadTableAmount;
            TimeCounter = 0;
            TotalGuests = 0; //Counter. När 80 gäster kommit in så serveras inga fler gäster för kvällen.
            GuestsInRestaurant = 0; //Får vara max 30 i restaurangen samtidigt.
            NewsFeed = new List<string>();

        }
        public Restaurant()
        {

        }


        private void MakePeopleInRestaurant()
        {
            PeopleInRestaurant = new List<Person>();

            for (int i = 0; i < GuestAmount; i++)
            {
                Person guest = new Guest();
                PeopleInRestaurant.Add(guest);
            }

            for (int i = 0; i < WaiterAmount; i++)
            {
                Person waiter = new Waiter();
                PeopleInRestaurant.Add(waiter);
            }

            for (int i = 0; i < ChefAmount; i++)
            {
                Person chef = new Chef();
                PeopleInRestaurant.Add(chef);
            }
        }


        private void MakeMenu()
        {
            Menu = new List<Food>

        {
            new Food.Meat("Plankstek", 339),
            new Food.Meat("Pasta Carbonara", 229.50),
            new Food.Meat("Fläskfilé", 289.50),
            new Food.Fish("Sushi", 198.90),
            new Food.Fish("Fiskgratäng", 209.50),
            new Food.Fish("Panerad rödspätta", 229),
            new Food.Vego("Vegoschnitzel med pommes", 199),
            new Food.Vego("Kronärtskockspizza", 179.50),
            new Food.Vego("Vegetarisk bolognese (linser)", 239)

        };
        }

        internal void PrintFood()
        {
            Console.WriteLine("Kötträtter:");
            foreach (Food m in Menu)
                if (m is Food.Meat)
                {
                    Console.WriteLine(m.Name + " " +  m.Price);
                }
            Console.WriteLine("\nFiskrätter:");
            foreach (Food f in Menu)
                if (f is Food.Fish)
                {
                    Console.WriteLine(f.Name + " " + f.Price);
                }
            Console.WriteLine("\nVegorätter:");
            foreach (Food v in Menu)
                if (v is Food.Vego)
                {
                    Console.WriteLine(v.Name + " " + v.Price);
                }

        }


    }
}

        
        

        



