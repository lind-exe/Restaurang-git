﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public List<Person> PeopleInRestaurant { get; set; }
       
        //public List<Person> Guests { get; set; }

        //public List<Person> StaffList { get; set; }           Tanke om man skulle ha en samlad lista med all personal. Fick det inte att fungera //J

        //public List<Person> Chefs { get; set; }


        public Restaurant(int guestAmount, int chefAmount, int waiterAmount, int duoTableAmount, int quadTableAmount)
        {
            GuestAmount = guestAmount;
            ChefAmount = chefAmount;
            WaiterAmount = waiterAmount;
            MakePeopleInRestaurant();
            MakeMenu();
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

        //skapa queue med gäster

        //ha en forloop som räknar från 0 - rnd. i loopen har vi en lista med sällskap och gör en dequeue på peopleinrest. rnd ggr.
        //Det sparar och addas till en lista av gäster, som stoppas in i en dictionary av bord

        //skapa en dictionary med bord

        private void MakePeopleInRestaurant()
        {
            PeopleInRestaurant = new List<Person>();
            Random rnd = new Random();
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
            foreach (Person p in PeopleInRestaurant)
                if (p is Guest)
                {                                           
                    Console.WriteLine(p.Name + " som har " + ((Guest)p).AmountOfMoney + " kr i plånboken");
                    //Console.WriteLine();
                }
            Console.WriteLine("\n**SERVERINGSPERSONAL**");
            foreach (Person p in PeopleInRestaurant)
                if (p is Waiter)
                {
                    Console.WriteLine(p.Name + " som har " + ((Waiter)p).ServiceLevel + " i servicenivå");
                    //Console.WriteLine();
                }
            Console.WriteLine("\n**KOCKAR**");
            foreach (Person p in PeopleInRestaurant)
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








