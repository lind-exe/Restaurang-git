using System;
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
        
        public int SeatedAt { get; set; }
        public int OrderAt { get; set; }
        public int ServedAt { get; set; }
        public int FinishedAt { get; set; }
        public bool WaitingToOrder { get; set; }
        public bool WaitingForFood { get; set; }
        public bool Eating { get; set; }

        public bool FinishedEating { get; set; }
        public Waiter Waiter { get; set; }
        public List<Guest> GuestsAtTable { get; set; }
        public Order Order { get; set; }

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
                graphics[0] = "Ledigt";
                GUI.Window.Draw(table.Name, table.Xpos, table.Ypos, graphics);
            }
        }
        public static void SeatCompany(Table table, Waiter waiter, List<Guest> company, int timeCounter)
        {
            table.GuestsAtTable = company;
            table.Empty = false;
            table.SeatedAt = timeCounter;
            table.Waiter = waiter;
            table.WaitingToOrder = true;
            //Diner.ChooseFromMenu(company);
            //Diner.TakeFoodOrderFromGuest(table, waiter, company);
           
        }

        public void CompanyEating()
        {
            if (Eating == false && FinishedEating == false)
            {
                Eating = true;
            }
        }

        internal static void TakeOrder(Table table, List<Food> food, int timeCounter)
        {
            table.Order = new Order(food, table, table.Waiter, timeCounter);
            table.OrderAt = timeCounter;
            table.WaitingToOrder = false;
            table.WaitingForFood = true;
            table.Waiter.Busy = 0; // me.Waiter.ServiceLevel;
            table.Waiter.Order = table.Order;
        }

        //public void TimeToEat()
        //{
        //    if (Eating == true)
        //    {

        //        EatingTime--;
        //    }
        //    if (EatingTime == 0)
        //    {
        //        FinishedEating = true;
        //        Eating = false;
        //    }
        //}

    }
}
