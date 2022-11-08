﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Table
    {
        public string Name { get; set; } = "Template";
        public int Xpos { get; set; }
        public int Ypos { get; set; }
        public int Size { get; set; }
        public int Number { get; set; }
        public int Quality { get; set; }
        public bool Empty { get; set; } = true;
        public bool IsClean { get; set; } = true;
        public int TipCounter { get; set; }
        public List<Guest> GuestsAtTable { get; set; }
        
        public bool Eating { get; set; }

        public int EatingTime { get; set; }
        public bool FinishedEating { get; set; }
        public List<Food> FoodOnTable { get; set; }  
        public Table()
        {

        }



        public Table(string name, int size, int xPos, int yPos, int number)
        {
            Name = name;
            Size = size;
            Xpos = xPos;
            Ypos = yPos;
            Number = number;
            EatingTime = 20;
        }
        public static void DrawMe(Table table)      // Ritar upp alla bord
        {
            if (!table.Empty)
            {
                int companySize = table.GuestsAtTable.Count;
                string[] graphics = new string[companySize];

                for (int i = 0; i < companySize; i++)
                {
                    if (table.GuestsAtTable[i] is Person)
                    {
                        graphics[i] = (table.GuestsAtTable[i] as Person).Name;
                    }
                }
                GUI.Window.Draw(table.Name, table.Xpos, table.Ypos, graphics);
            }
            else
            {
                string[] graphics = new string[1];
                graphics[0] = "Empty";
                GUI.Window.Draw(table.Name, table.Xpos, table.Ypos, graphics);
            }
        }
        public static void SeatCompany(Table table, Waiter waiter, List<Guest> company)
        {
            table.GuestsAtTable = company;
            table.Empty = false;
            Diner.ChooseFromMenu(company);
            Diner.TakeFoodOrderFromGuest(table, waiter, company);
            foreach (Guest guest in company)
            {
               // Console.SetCursorPosition(40, 1);
                Console.WriteLine(guest.FoodChoice.Name + " " + guest.FoodChoice.Price);
            }
        }

        public void CompanyEating()
        {
            if (Eating == false && FinishedEating == false)
            {
                Eating = true;
            }
        }

        public void TimeToEat()
        {
            if (Eating == true)
            {

                EatingTime--;
            }
            if (EatingTime == 0)
            {
                FinishedEating = true;
                Eating = false;
            }
        }
       
    }
}
