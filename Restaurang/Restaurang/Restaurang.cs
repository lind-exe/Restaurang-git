﻿using System;
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
            Table.DrawAnyList<Table>("Table", 15, 20, Chefs);
        }
        //Stoppas in sällskapen från Companies i en dictionary av bord


        //public void MakeTables() // skapar alla tomma bord
        //{
        //    Tables = new Dictionary<string, Table>();
        //    for (int i = 0; i < 10; i++)
        //    {
        //        if (i < 5)
        //        {
        //            Tables.Add("Table " +i , new Table(2));
        //        }
        //        else
        //        {
        //            Tables.Add("Table " +i, new Table(4));
        //        }
        //    }

        //}

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
                //if (Guests.Count > 4)
                //{
                int companySize = rnd.Next(1, 4);

                for (int i = 0; i < companySize; i++)
                {
                    oneCompany.Add(Guests.Dequeue() as Guest);
                }

                Companies.Add(new List<Guest>(oneCompany));

                int companyIndex = 0;
                foreach (List<Guest> c in Companies)
                {
                    companyIndex++;
                    Console.WriteLine("Sällskap nummer: " + companyIndex);
                    foreach (Guest g in c)
                    {
                        Console.WriteLine(g.Name + " som har " + g.AmountOfMoney + " kr i plånboken.");
                    }
                    Console.WriteLine();
                }
                Console.ReadKey();
                Console.Clear();
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
            Table.DrawAnyList<>("Table", 15, 20, Chefs);
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








