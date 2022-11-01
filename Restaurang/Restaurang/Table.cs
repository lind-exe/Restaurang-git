using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class Table : Restaurant
    {
        public int Size { get; set; }
        public int Number { get; set; }
        public int Quality { get; set; }
        public bool Empty { get; set; } = true;
        public bool IsClean { get; set; }
        public int TipCounter { get; set; }     //osäkert vart denna ska ligga.

        //public List<string> ThingsOnTable { get; set; }  //inväntar onsdagens lektion innan vi går vidare med detta.




        public Table()
        {           
            Size = 0;
        }

        //public static void DrawAnyList<T>(string header, int fromLeft, int fromTop, List<T> anyList)
        //{
        //    string[] graphics = new string[anyList.Count];

        //    for (int i = 0; i < anyList.Count; i++)
        //    {

        //        if (anyList[i] is Table)
        //        {
        //            graphics[i] = (anyList[i] as Table).Size;
        //        }

        //        if (anyList[i] is Movie)
        //        {
        //            graphics[i] = (anyList[i] as Movie).Title + "(" + (anyList[i] as Movie).PlayingTime + " min)";
        //        }
        //    }

        //    GUI.Window.Draw(header, fromLeft, fromTop, graphics);
        //}
    }
}
