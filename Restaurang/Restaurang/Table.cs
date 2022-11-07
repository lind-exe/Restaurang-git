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
        public List<Guest> GuestsAtTable { get; set; }
        public bool Eating { get; set; }

        public int EatingTime { get; set; }
        public bool FinishedEating { get; set; }

        //osäkert vart denna ska ligga.

        //Dictionary med personer som sitter vid det

        //public List<string> ThingsOnTable { get; set; }  //inväntar onsdagens lektion innan vi går vidare med detta.
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
        public static void DrawMe(Table table)
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
        public static void SeatCompany(Table table, List<Guest> company)
        {
            table.GuestsAtTable = company;
            table.Empty = false;
        }

        public void EatingGuest()
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

                EatingTime++;
            }
            if (EatingTime == 20)
            {
                FinishedEating = true;
                Eating = false;
            }
        }
    }
}
