using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurang
{
    internal class TableGraphics
    {
        public void DrawFrame()
        {
            Draw4Table();
            Console.WriteLine();
            Draw2Table();

        }
        public void Draw4Table()
        {
            //Console.Clear();
            string[,] quadTableGraphic = new string[8, 5];

            for (int line = 0; line < 1; line++)
            {
                for (int tablePerLine = 0; tablePerLine < 3; tablePerLine++)
                {
                    //Sätt tablenumber till en property så det inte blir hårdkodat!
                    string tableNumber = (tablePerLine + 1 + ""/*+ "" + tablePerLine*/);

                    //Här ska gästerna in   /*+ occupant.PadRight(9, '.')*/
                    //string occupant = (occupants[line, tablePerLine] == null) ? "Tomt" : occupants[line, tablePerLine];

                    quadTableGraphic[0, tablePerLine] = "-----------";
                    quadTableGraphic[1, tablePerLine] = "|" + tableNumber + "        |";
                    quadTableGraphic[2, tablePerLine] = "|         |";
                    quadTableGraphic[3, tablePerLine] = "|         |";
                    quadTableGraphic[4, tablePerLine] = "|         |";
                    quadTableGraphic[5, tablePerLine] = "|         |";
                    quadTableGraphic[6, tablePerLine] = "|         |";
                    quadTableGraphic[7, tablePerLine] = "-----------";
                }
                Console.WriteLine();
                Console.WriteLine();
                // Rita ut grafiken
                for (int j = 0; j < quadTableGraphic.GetLength(0); j++)
                {

                    for (int k = 0; k < quadTableGraphic.GetLength(1); k++)
                    {
                        Console.Write(quadTableGraphic[j, k] + "\t\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();

            }

        }
        public void Draw2Table()
        {

            //Console.Clear();
            string[,] quadTableGraphic = new string[5, 5];

            for (int line = 0; line < 1; line++)
            {
                for (int tablePerLine = 0; tablePerLine < 3; tablePerLine++)
                {
                    //Sätt tablenumber till en property så det inte blir hårdkodat!
                    string tableNumber = (tablePerLine + 1 + ""/*+ "" + tablePerLine*/);

                    //Här ska gästerna in   /*+ occupant.PadRight(9, '.')*/
                    //string occupant = (occupants[line, tablePerLine] == null) ? "Tomt" : occupants[line, tablePerLine];

                    quadTableGraphic[0, tablePerLine] = "-----------";
                    quadTableGraphic[1, tablePerLine] = "|" + tableNumber + "        |";
                    quadTableGraphic[2, tablePerLine] = "|         |";
                    quadTableGraphic[3, tablePerLine] = "|         |";
                    quadTableGraphic[4, tablePerLine] = "-----------";
                }
                Console.WriteLine();
                Console.WriteLine();
                // Rita ut grafiken
                for (int j = 0; j < quadTableGraphic.GetLength(0); j++)
                {

                    for (int k = 0; k < quadTableGraphic.GetLength(1); k++)
                    {
                        Console.Write(quadTableGraphic[j, k] + "\t\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine();

            }

        }
    }
}
