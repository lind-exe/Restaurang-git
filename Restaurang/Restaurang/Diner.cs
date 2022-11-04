using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Restaurant.Food;
using static Restaurant.Person;

namespace Restaurant
{
    internal class Diner
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
        public List<Person> Chefs { get; set; }
        public List<List<Guest>> Companies { get; set; }//ska vi använda Queue av listor
        public Queue Guests { get; set; }
        public Dictionary<string, Table> Tables { get; set; }

        public List<Person> Waiters { get; set; }



        public Diner(int guestAmount, int chefAmount, int waiterAmount, int duoTableAmount, int quadTableAmount)
        {
            GuestAmount = guestAmount;
            ChefAmount = chefAmount;
            WaiterAmount = waiterAmount;
            DuoTableAmount = duoTableAmount;
            QuadTableAmount = quadTableAmount;

            MakeWaiters();
            MakeChefs();
            MakeMenu();
            MakeTables();
            MakeCompanies();

            TimeCounter = 0;
            TotalGuests = 0; //Counter. När 80 gäster kommit in så serveras inga fler gäster för kvällen.
            GuestsInRestaurant = 0; //Får vara max 30 i restaurangen samtidigt.
            NewsFeed = new List<string>();

        }
        public Diner()
        {

        }
        public void Run()
        {
            //DrawAnyList<Person>("Chefs", 2, 1, Chefs);
            //DrawAnyList<Person>("Waiters", 2, 8, Waiters);
            //DrawAnyList<Guest>("Bord 1", 2, 20, Companies[0]);
            //DrawAnyList<Guest>("Bord 2", 20, 20, Companies[1]);
            //DrawAnyList<Guest>("Bord 3", 38, 20, Companies[2]);
            //DrawAnyList<Guest>("Bord 4", 2, 30, Companies[3]);
            //DrawAnyList<Guest>("Bord 5", 20, 30, Companies[4]);
            //DrawAnyList<Guest>("Bord 6", 38, 30, Companies[5]);
            //DrawAnyList<Guest>("Bord 7", 2, 40, Companies[6]);
            //DrawAnyList<Guest>("Bord 8", 20, 40, Companies[7]);
            //DrawAnyList<Guest>("Bord 9", 38, 40, Companies[8]);
            //DrawAnyList<Guest>("Bord 10", 2, 50, Companies[9]);

            for (int i = 0; i < 11; i++)
            {
                if (PlaceCompanyAtTable(Companies[0]))
                {
                    GuestsInRestaurant += Companies[0].Count;
                }
               // Console.ReadLine();
                Companies.Remove(Companies[0]);
            PrintTables();
            }
            

            
            //Console.SetCursorPosition(50, 1);
            //Console.WriteLine(Companies.Count);

        }
        //Stoppas in sällskapen från Companies i en dictionary av bord


        public void MakeTables() // skapar alla tomma bord
        {
            Tables = new Dictionary<string, Table>();
            int tableCount = 1;
            int tableSize = 2;

            for (int i = 0; i < DuoTableAmount + QuadTableAmount; i++)
            {
                int tableNumber = tableCount++;
                string tableName = "Bord " + tableNumber;
                if (i >= QuadTableAmount) tableSize = 4;
                int tableXpos = (i % 3) * 18 + 2;  // (i%3) * 18 ger 0, 18, 36
                int tableYpos = (i % 5) * 5 + 10; // (i%5) * 10 ger 0, 5, 10, 15, 20

                // Lägg in bordet i stora listan med namnet som nyckel
                Tables.Add(tableName, new Table(tableName, tableSize, tableXpos, tableYpos, tableNumber));
            }

        }

        public void MakeCompanies()
        {
            Guests = new Queue();
            List<Guest> oneCompany = new List<Guest>();
            Companies = new List<List<Guest>>();

            Random rnd = new Random();

            for (int i = 0; i < GuestAmount; i++)
            {

                Guests.Enqueue(new Guest());

            }

            while (Guests.Count > 4)
            {
                oneCompany.Clear();
                //if (Guests.Count > 4)
                //{
                int companySize = rnd.Next(1, 5);

                for (int i = 0; i < companySize; i++)
                {
                    oneCompany.Add(Guests.Dequeue() as Guest);
                }

                Companies.Add(new List<Guest>(oneCompany));

                int companyIndex = 0;

            }
        }
        private void MakeWaiters()
        {
            Waiters = new List<Person>();
            for (int i = 0; i < WaiterAmount; i++)
            {
                Person waiter = new Waiter();
                Waiters.Add(waiter);
            }
        }
        private void MakeChefs()
        {
            Chefs = new List<Person>();
            for (int i = 0; i < ChefAmount; i++)
            {
                Person chef = new Chef();
                Chefs.Add(chef);
            }

        }

        public void MakeMenu()
        {
            Menu = new List<Food>
            {
                new Meat("Plankstek", 339),
                new Meat("Pasta Carbonara", 229.50),
                new Meat("Fläskfilé", 289.50),
                new Fish("Sushi", 198.90),
                new Fish("Fiskgratäng", 209.50),
                new Fish("Panerad rödspätta", 229),
                new Vego("Vegoschnitzel med pommes", 199),
                new Vego("Kronärtskockspizza", 179.50),
                new Vego("Vegetarisk bolognese (linser)", 239)
            };
        }

        internal void PrintPeople()
        {
            Console.WriteLine("**GÄSTER**");
            foreach (object o in Guests)
                if (o is Guest)
                {
                    Console.WriteLine(((Guest)o).Name + " som har " + ((Guest)o).AmountOfMoney + " kr i plånboken");
                    //Console.WriteLine();
                }
            Console.WriteLine("\n**SERVERINGSPERSONAL**");
            foreach (Person p in Waiters)
                if (p is Waiter)
                {
                    Console.WriteLine(p.Name + " som har " + ((Waiter)p).ServiceLevel + " i servicenivå");
                    //Console.WriteLine();
                }
            Console.WriteLine("\n**KOCKAR**");
            foreach (Person p in Chefs)
                if (p is Chef)
                {
                    Console.WriteLine(p.Name + " som har " + ((Chef)p).Skills + " i kompetens");
                    //Console.WriteLine();
                }
        }
        internal void PrintTables()
        {
            for (int i = 0; i < Tables.Count; i++)
            {
                Table.DrawMe(Tables.ElementAt(i).Value);
            }
        }
        internal bool PlaceCompanyAtTable(List<Guest> company)
        {

            int companySize = company.Count;
            for (int i = 0; i < Tables.Count; i++)
            {
                if (Tables.ElementAt(i).Value.Empty && Tables.ElementAt(i).Value.Size <= companySize)
                {
                    Table.SeatCompany(Tables.ElementAt(i).Value, company);
                    return true;
                }

            }
            return false;
        }

        //public static void DrawAnyList<T>(string header, int fromLeft, int fromTop, List<T> anyList)
        //{
        //    string[] graphics = new string[anyList.Count];

        //    for (int i = 0; i < anyList.Count; i++)
        //    {

        //        if (anyList[i] is Person)
        //        {
        //            graphics[i] = (anyList[i] as Person).Name;
        //        }



        //    }
        //    GUI.Window.Draw(header, fromLeft, fromTop, graphics);
        //}

        internal void PrintFood()
        {
            Console.WriteLine("**KÖTTRÄTTER**");
            foreach (Food d in Menu)
                if (d is Meat)
                {
                    Console.WriteLine(d.Name + " " + d.Price + " kr");
                    //Console.WriteLine();
                }
            Console.WriteLine("\n**FISKRÄTTER**");
            foreach (Food d in Menu)
                if (d is Fish)
                {
                    Console.WriteLine(d.Name + " " + d.Price + " kr");
                    //Console.WriteLine();
                }
            Console.WriteLine("\n**VEGETARISKA RÄTTER**");
            foreach (Food d in Menu)
                if (d is Vego)
                {
                    Console.WriteLine(d.Name + " " + d.Price + " kr");
                    //Console.WriteLine();
                }


            Console.WriteLine();

            //foreach (Food food in Menu)
            //{
            //    Console.WriteLine(food.Name + " - " + food.Price + " kr");
            //}

            //Console.WriteLine();

            //foreach (Food food in Menu)
            //{
            //    if (food is Meat)
            //    {
            //        Console.Write("Kötträtter: ");
            //        Console.WriteLine(food.Name + " " + food.Price);
            //    }

            //    if (food is Fish)
            //    {
            //        Console.Write("Fiskrätter: ");
            //        Console.WriteLine(food.Name + " " + food.Price);
            //    }

            //    if (food is Vego)
            //    {
            //        Console.Write("Vegetariska rätter: ");
            //        Console.WriteLine(food.Name + " " + food.Price);
            //    }
            //    Console.WriteLine();
            //}

        }



    }
}








