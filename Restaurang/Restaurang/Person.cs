using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurang
{
    internal class Person
    {
        public string Name { get; set; }
        public int Id { get; set; }

        

        public Person()
        {
            Name = LastName();
        }
        private static string LastName()
        {
            string[] lastnames =
            {
                "Andersson",
                "Johansson",
                "Karlsson",
                "Nilsson",
                "Eriksson",
                "Larsson",
                "Olsson",
                "Persson",
                "Svensson",
                "Gustafsson",
                "Pettersson",
                "Jonsson",
                "Jansson",
                "Hansson",
                "Bengtsson",
                "Jönsson",
                "Lindberg",
                "Jakobsson",
                "Magnusson",
                "Olofsson",
                "Lindström",
                "Lindqvist",
                "Lindgren",
                "Axelsson",
                "Berg",
                "Bergström",
                "Lundberg",
                "Lind",
                "Lundgren",
                "Lundqvist",
                "Mattsson",
                "Berglund",
                "Fredriksson",
                "Sandberg",
                "Henriksson",
                "Forsberg",
                "Sjöberg",
                "Wallin",
                "Ali",
                "Engström",
                "Mohamed",
                "Eklund",
                "Danielsson",
                "Lundin",
                "Håkansson",
                "Björk",
                "Bergman",
                "Gunnarsson",
                "Holm",
                "Wikström",
                "Samuelsson",
                "Isaksson",
                "Fransson",
                "Bergqvist",
                "Nyström",
                "Holmberg",
                "Arvidsson",
                "Löfgren",
                "Söderberg",
                "Nyberg",
                "Blomqvist",
                "Claesson",
                "Nordström",
                "Mårtensson",
                "Lundström",
                "Ahmed",
                "Viklund",
                "Björklund",
                "Eliasson",
                "Pålsson",
                "Hassan",
                "Berggren",
                "Sandström",
                "Lund",
                "Nordin",
                "Ström",
                "Åberg",
                "Hermansson",
                "Ekström",
                "Falk",
                "Holmgren",
                "Dahlberg",
                "Hellström",
                "Hedlund",
                "Sundberg",
                "Sjögren",
                "Ek",
                "Blom",
                "Abrahamsson",
                "Martinsson",
                "Öberg",
                "Andreasson",
                "Strömberg",
                "Månsson",
                "Åkesson",
                "Hansen",
                "Norberg",
                "Lindholm",
                "Dahl",
                "Jonasson"
            };
            Random rnd = new Random();
            int index = rnd.Next(0, lastnames.Length - 1);

            return lastnames[index];
        }
    }

    internal class Guest : Person
    {
        //public int AmountOfCompany { get; set; }
        public double AmountOfMoney { get; set; }
        public int Satisfaction { get; set; }

        public bool Eating { get; set; }

        public int EatingTime { get; set; }


        public Guest()
        {

        }

    }

    internal class Chef : Person
    {
        public int Skills { get; set; }

        public Chef()
        {

        }

    }

    internal class Waiter : Person
    {
        public int ServiceLevel { get; set; }
        public Waiter()
        {

        }

    }
}
