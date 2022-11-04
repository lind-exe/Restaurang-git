using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Restaurant.Food;
using static Restaurant.Person;

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
        public List<Person> Chefs { get; set; }
        public List<List<Guest>> Companies { get; set; }//ska vi använda Queue av listor
        public Queue Guests { get; set; }
        public Dictionary<string, Table> Tables { get; set; }

        public List<Person> Waiters { get; set; }

        

        public Restaurant(int guestAmount, int chefAmount, int waiterAmount, int duoTableAmount, int quadTableAmount)
        {
            GuestAmount = guestAmount;
            ChefAmount = chefAmount;
            WaiterAmount = waiterAmount;
            MakeWaiters();
            MakeChefs();
            MakeMenu();
            MakeCompanies();
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
        public void Run()
        {
            //DrawAnyList<Person>("Chefs", 2, 1, Chefs);
            //DrawAnyList<Person>("Waiters", 2, 8, Waiters);
            //DrawAnyList<Table>(Tables[bord 1].Name, 2, 20, Companies[0]);
            DrawAnyList<Guest>("Bord 2", 20, 20, Companies[1]);
            DrawAnyList<Guest>("Bord 3", 38, 20, Companies[2]);
            DrawAnyList<Guest>("Bord 4", 2, 30, Companies[3]);
            DrawAnyList<Guest>("Bord 5", 20, 30, Companies[4]);
            DrawAnyList<Guest>("Bord 6", 38, 30, Companies[5]);
            DrawAnyList<Guest>("Bord 7", 2, 40, Companies[6]);
            DrawAnyList<Guest>("Bord 8", 20, 40, Companies[7]);
            DrawAnyList<Guest>("Bord 9", 38, 40, Companies[8]);
            DrawAnyList<Guest>("Bord 10", 2, 50, Companies[9]);

        }
        //Stoppas in sällskapen från Companies i en dictionary av bord

        //public void MakeTablesOneByOne()
        //{
        //    Tables = new Dictionary<string, Table>();

        //    Tables.Add("Bord 1", new Table(2));
        //    Tables.Add("Bord 2", new Table(2));
        //    Tables.Add("Bord 3", new Table(2));
        //    Tables.Add("Bord 4", new Table(2));
        //    Tables.Add("Bord 5", new Table(2));
        //    Tables.Add("Bord 6", new Table(4));
        //    Tables.Add("Bord 7", new Table(4));
        //    Tables.Add("Bord 8", new Table(4));
        //    Tables.Add("Bord 9", new Table(4));
        //    Tables.Add("Bord 10", new Table(4));

        //    Console.WriteLine("Bord 1's kvalitet är: " + Tables["Bord 1"].Quality);
        //}

        //public void SeatAtTable(List<Guest>oneCompany) 
        //{
        //    List<Guest> guestsAtTable = new List<Guest>();

        //    foreach (KeyValuePair<string, Table> kvp in Tables)
        //    {
        //        if (kvp.Value.Empty && kvp.Value.IsClean)
        //        {
        //            if((guestsAtTable.Count >2) & (kvp.Value.Size == 4))
        //            {
        //                guestsAtTable.Add(oneCompany);
        //            }
        //        }
        //    }
        //}

        public void MakeTablesWithLoops() // skapar alla tomma bord
        {
            Tables = new Dictionary<string, Table>();
            for (int i = 0; i < 10; i++)
            {
                if (i < 5)
                {
                    Tables.Add($"Table {i + 1}", new Table(2));
                }
                else
                {
                    Tables.Add($"Table {i + 1}", new Table(4));
                }
            }

            Console.WriteLine("Bord 1's kvalitet är: " + Tables["Table 1"].Quality);
            Console.WriteLine("Bord 6's bordsstorlek är: " + Tables["Table 6"].Size);
            Console.WriteLine("Bord 5 är rent: " + Tables["Table 5"].IsClean);
            Console.WriteLine("Bord 10 är tomt: " + Tables["Table 10"].Empty);
            Console.WriteLine("Bord 1's kvalitet är: " + Tables["Table 1"].Quality);
            Console.WriteLine("Bord 3's bordsstorlek är: " + Tables["Table 3"].Size);
            Console.WriteLine("Bord 7's bordsgäster är: " + Tables["Table 7"].GuestsAtTable);
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
                int companySize = rnd.Next(1, 4);

                for (int i = 0; i < companySize; i++)
                {
                    oneCompany.Add(Guests.Dequeue() as Guest);
                }

                Companies.Add(new List<Guest>(oneCompany));

                //int companyIndex = 0;
                //foreach (List<Guest> c in Companies)
                //{
                //    companyIndex++;
                //    Console.WriteLine("Sällskap nummer: " + companyIndex);
                //    foreach (Guest g in c)
                //    {
                //        Console.WriteLine(g.Name + " som har " + g.AmountOfMoney + " kr i plånboken.");
                //    }
                //    Console.WriteLine();
                //}
                //Console.ReadKey();
                //Console.Clear();
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

        public static void DrawAnyList<T>(string header, int fromLeft, int fromTop, List<T> anyList)
        {
            string[] graphics = new string[anyList.Count];

            for (int i = 0; i < anyList.Count; i++)
            {

                if (anyList[i] is Person)
                {
                    graphics[i] = (anyList[i] as Person).Name;
                }



            }
            GUI.Window.Draw(header, fromLeft, fromTop, graphics);
        }

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








