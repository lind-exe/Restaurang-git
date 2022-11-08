using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
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
        //TIMER TILL ALLA METODER?
        public int TotalGuests { get; set; }
        public int GuestAmount { get; set; }
        public int ChefAmount { get; set; }
        public int WaiterAmount { get; set; }
        public int DuoTableAmount { get; set; }
        public int QuadTableAmount { get; set; }
        public int TimeCounter { get; set; }
        public int GuestsInRestaurant { get; set; }
        public List<string> NewsFeed { get; set; }
        public static List<Food> Menu { get; set; }
        public List<Chef> Chefs { get; set; }
        public List<List<Guest>> Companies { get; set; }//ska vi använda Queue av listor
        public Queue Guests { get; set; }
        public Dictionary<string, Table> Tables { get; set; }

        public List<Waiter> Waiters { get; set; }



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

            while (true)
            {
                FetchAndPlaceCompany();
                TakeOrder();
                PlaceOrder();
                Console.Clear();
                PrintNews();
                PrintTables();
                Console.ReadLine();


            }


        }

        internal void PrintNews()
        {
            int i = 0;
            string[] graphics = new string[NewsFeed.Count];
            foreach (String s in NewsFeed)
            {
                graphics[i++] = s;
            }
            GUI.Window.Draw("Händelser", 80, 6, graphics);
        }

        internal void FetchAndPlaceCompany()
        {
            List<Guest> nextCompany = FindNextCompany(Companies);
            if (nextCompany != null)
            {
                Table freeTable = FindFreeTable(nextCompany);
                if (freeTable != null)
                {
                    Waiter freeWaiter = FindFreeWaiter(Waiters);
                    if (freeWaiter != null)
                    {
                        SeatCompanyAtTable(nextCompany, freeTable, freeWaiter);
                        Companies.Remove(nextCompany);
                        NewsFeed.Add("Sällskapet " + nextCompany[0].Name + " har fått " + freeTable.Name);
                    }
                    else
                    {
                        NewsFeed.Add("Ingen ledig kypare!");
                    }
                }
                else
                {
                    NewsFeed.Add("Inget ledigt bord!");
                }
            }
        }

        internal void SeatCompanyAtTable(List<Guest> company, Table table, Waiter waiter)
        {
            Table.SeatCompany(table, waiter, company, TimeCounter);
            GuestsInRestaurant += company.Count;

        }

        internal Waiter FindFreeWaiter(List<Waiter> waiters)
        {
            foreach (Waiter waiter in waiters)
            {
                if (waiter.Orders.Count == 0)
                {
                    return waiter;
                }
            }
            return null;
        }

        public Table FindFreeTable(List<Guest> company)
        {
            int companySize = company.Count;
            for (int i = 0; i < Tables.Count; i++)
            {
                if (Tables.ElementAt(i).Value.Empty && Tables.ElementAt(i).Value.Size >= companySize)
                {
                    return Tables.ElementAt(i).Value;
                }

            }
            return null;

        }

        public List<Guest> FindNextCompany(List<List<Guest>> companies)
        {
            if (companies.Count > 0)
            {
                return companies[0];
            }
            else
            {
                return null;
            }
        }

        public void MakeTables() // skapar alla tomma bord
        {
            Tables = new Dictionary<string, Table>();
            int tableCount = 1;
            int tableSize = 2;

            for (int i = 0; i < DuoTableAmount + QuadTableAmount; i++)
            {
                int tableNumber = tableCount++;
                string tableName = "Bord " + tableNumber;
                if (i >= DuoTableAmount) tableSize = 4;
                int tableXpos = (i % 3) * 18 + 2;  // (i%3) * 18 ger 0, 18, 36
                int tableYpos = (i % 5) * 5 + 12; // (i%5) * 10 ger 0, 5, 10, 15, 20

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

            while (Guests.Count > 0)
            {
                oneCompany.Clear();
                int companySize = rnd.Next(1, 5);
                if (Guests.Count >= 4)
                {

                    for (int i = 0; i < companySize; i++)
                    {
                        oneCompany.Add(Guests.Dequeue() as Guest);
                    }

                    Companies.Add(new List<Guest>(oneCompany));

                }
                else
                {
                    for (int i = 0; i <= Guests.Count; i++)
                    {
                        oneCompany.Add(Guests.Dequeue() as Guest);
                    }

                    Companies.Add(new List<Guest>(oneCompany));
                }
            }
        }
        private void MakeWaiters()
        {
            Waiters = new List<Waiter>();
            for (int i = 0; i < WaiterAmount; i++)
            {
                Waiter waiter = new Waiter();
                Waiters.Add(waiter);
            }
        }
        private void MakeChefs()
        {
            Chefs = new List<Chef>();
            for (int i = 0; i < ChefAmount; i++)
            {
                Chef chef = new Chef();
                Chefs.Add(chef);
            }

        }

        public void MakeMenu()
        {
            Menu = new List<Food>
            {
                new Meat("Plankstek", 339, 0),
                new Meat("Pasta Carbonara", 229.50, 0),
                new Meat("Fläskfilé", 289.50, 0),
                new Fish("Sushi", 198.90, 0),
                new Fish("Fiskgratäng", 209.50, 0),
                new Fish("Panerad rödspätta", 229, 0),
                new Vego("Vegoschnitzel med pommes", 199, 0),
                new Vego("Kronärtskockspizza", 179.50, 0),
                new Vego("Vegetarisk bolognese (linser)", 239, 0)
            };
        }

        internal void PrintPeople()
        {
            int gruppIndex = 1;
            int guestIndex = 1;
            Console.WriteLine("**GÄSTER**");
            foreach (List<Guest> c in Companies)
            {
                Console.WriteLine("Grupp nummer: " + gruppIndex);
                foreach (Guest g in c)
                {
                    Console.WriteLine("Guest nummer: " + guestIndex + ((Guest)g).Name + " som har " + ((Guest)g).AmountOfMoney + " kr i plånboken");
                    guestIndex++;
                }
                gruppIndex++;
                Console.WriteLine();

            }

            Console.WriteLine("\n**SERVERINGSPERSONAL**");
            foreach (Waiter p in Waiters)
                if (p is Waiter)
                {
                    Console.WriteLine(p.Name + " som har " + ((Waiter)p).ServiceLevel + " i servicenivå");
                    //Console.WriteLine();
                }
            Console.WriteLine("\n**KOCKAR**");
            foreach (Chef p in Chefs)
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
        internal bool PlaceCompanyAtTable(List<Guest> company, Waiter waiter)   //En waiter behövs sättas in här
        {

            int companySize = company.Count;
            for (int i = 0; i < Tables.Count; i++)
            {
                if (Tables.ElementAt(i).Value.Size >= companySize && Tables.ElementAt(i).Value.Empty)
                {
                    Table.SeatCompany(Tables.ElementAt(i).Value, waiter, company, TimeCounter);
                    return true;
                }

            }
            return false;
        }
        public static void ChooseFromMenu(List<Guest> company)
        {
            Table table = new Table();
            table.GuestsAtTable = company;
            Random rnd = new Random();

            foreach (Guest g in company)
            {
                g.FoodChoice = Menu[rnd.Next(1, Menu.Count)];
            }
            //Öka tid med ett?
        }



        public void TakeOrder()
        {
            Table waitingTable = FindTableWaitingToOrder();
            if (waitingTable != null)
            {
                waitingTable.OrderAt = TimeCounter;
                waitingTable.WaitingToOrder = false;
                waitingTable.WaitingForFood = true;


                foreach (Guest g in waitingTable.GuestsAtTable)
                {
                    waitingTable.Waiter.Orders.Add(g.FoodChoice);

                }
                NewsFeed.Add(waitingTable.Waiter.Name + " plockade upp order från " + waitingTable.Name);
            }
            //Öka tid med ett?
        }

        public Table FindTableWaitingToOrder()
        {
            for (int i = 0; i < Tables.Count; i++)
            {
                if (Tables.ElementAt(i).Value.WaitingToOrder && Tables.ElementAt(i).Value.OrderAt == 0)
                {
                    return Tables.ElementAt(i).Value;
                }
            }
            return null;
        }

        internal void PlaceOrder()
        {
            Waiter waiter = FindWaiterWithOrder(Waiters);
            if (waiter != null)
            {
                Chef chef = FindFreeChef(Chefs);
                if (chef != null)
                {
                    foreach (Food f in waiter.Orders)
                    {
                        chef.WorkOrder.Add(f);
                        f.Quality += (chef.Skills + waiter.ServiceLevel);
                    }
                    waiter.Orders.Clear();
                    NewsFeed.Add("Kocken " + chef.Name + " får order från " + waiter.Name);
                }

            }

            //Öka tid med ett?
        }

        internal Chef FindFreeChef(List<Chef> chefs)
        {
            foreach (Chef chef in chefs)
            {
                if (chef.WorkOrder.Count == 0)
                {
                    return chef;
                }
            }
            return null;
        }

        internal Waiter FindWaiterWithOrder(List<Waiter> waiters)
        {
            foreach (Waiter waiter in waiters)
            {
                if (waiter.Orders.Count > 0)
                {
                    return waiter;

                }

            }
            return null;
        }

        public static void GiveFoodFromChefToWaiter(Waiter waiter, Chef chef)
        {

            foreach (Food food in chef.WorkOrder)
            {
                food.Quality += (chef.Skills + waiter.ServiceLevel);
            }

            waiter.Orders.AddRange(chef.WorkOrder);
            chef.WorkOrder.Clear();



            //Öka tid med ett?
        }

        public void ServeFoodToGuests(Waiter waiter, Table table)
        {
            table.FoodOnTable.AddRange(waiter.Orders);
            waiter.Orders.Clear();

            table.Eating = true;
            //table.TimeToEat();//Ska detta vara en egen metod?

        }
        public void PayForFood()
        {
            //Villkor för dricks
            //Vem har ätit vad och vad kostade det
            //Har gästen pengar till enbart rätten?
            //Har gästen pengar till både rätt och dricks?
            //Har gästen inte pengar ens till rätten = diska

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








