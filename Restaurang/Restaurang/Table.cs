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
        public int TipCounter { get; set; }
        public List<Guest> GuestsAtTable { get; set; }

        //osäkert vart denna ska ligga.

        //Dictionary med personer som sitter vid det

        //public List<string> ThingsOnTable { get; set; }  //inväntar onsdagens lektion innan vi går vidare med detta.




        public Table(int size)
        {
            Size = size;
        }

        //public static void DrawAnyList<T>(string header, int fromLeft, int fromTop, List<T> anyList)
        //{
        //    string[] graphics = new string[anyList.Count];

        //    for (int i = 0; i < anyList.Count; i++)
        //    {

        //        if (anyList[i] is Chef)
        //        {
        //            graphics[i] = (anyList[i] as Chef).Name;
        //        }



        //        GUI.Window.Draw(header, fromLeft, fromTop, graphics);
        //    }
        //}
    }
}
