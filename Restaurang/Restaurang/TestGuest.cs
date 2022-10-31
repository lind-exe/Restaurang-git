using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    internal class TestGuest : Person
    {
        public int AmountOfCompany { get; set; }
        public double AmountOfMoney { get; set; }
        public string NameofGuest { get; set; }
        public int AmountOfGuests { get; set; }
        public List<TestGuest> GuestList { get; set; }



        //public int Satisfaction { get; set; }

        //public bool Eating { get; set; }

        //public int EatingTime { get; set; }
        //public bool FinishedEating { get; set; }
        //public List<Person> Company { get; set; }

        public TestGuest(string name, int amountOfCompany, double amountOfMoney)
        {
            Random random = new Random();
            AmountOfMoney = random.Next(0, 5000);
            AmountOfCompany = random.Next(0, 4);
            NameofGuest = LastNames();
        }

        public TestGuest()
        {

        }

        public void PrintMe()
        {
            int totalGuests = 0;
            while (true)
            {
                foreach (var guest in MakeGuest())
                {
                    int company = guest.AmountOfCompany + 1;

                    Console.WriteLine("Sällskapet " + guest.Name + " + " + guest.AmountOfCompany + " beställde " + company +
                        " maträtter. " + guest.Name + " har " + guest.AmountOfMoney + " kronor i plånboken.");

                    totalGuests += company;


                    Console.WriteLine("Totalt är det " + totalGuests + " gäster i restaurangen.");
                    Console.ReadKey();
                    Console.WriteLine();
                }

                Console.WriteLine();
            }
        }


        public List<TestGuest> MakeGuest()
        {
            List<TestGuest> guests = new List<TestGuest>();

            for (int i = 0; i < 30; i++)
            {
                guests.Add(new TestGuest(NameofGuest, AmountOfCompany, AmountOfMoney));
            }

            return guests;
        }


        private static string LastNames()
        {
            string[] lastNames =
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

            int index = rnd.Next(0, lastNames.Length - 1);

            return lastNames[index];
        }
    }
}
