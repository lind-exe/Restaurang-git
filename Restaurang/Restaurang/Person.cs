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

    internal class Guest : Person
    {
        //public int AmountOfCompany { get; set; }
        public double AmountOfMoney { get; set; }
        public int Satisfaction { get; set; }

        public bool Eating { get; set; }

        public int EatingTime { get; set; }
        public bool FinishedEating { get; set; }
        public List<Person> Company { get; set; }


        public Guest()
        {
            Company = new List<Person>();

        }

        public void Groups()
        {
            List<string> lastNames = new List<string>();

            string[] lastNames2 =
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

            lastNames.AddRange(lastNames2.ToList());



            //for (int i = 0; i <= lastNames.Count; i++)
            //{
            //    Random rnd = new Random();
            //    int g = rnd.Next(0, 4);

            //    foreach (var person in lastNames)
            //    {
            //        for (int j = 0; j < g; j++)
            //        {
            //            Company.Add(person);
            //        }

            //    }

            //    Console.WriteLine("Grupp " + (i + 1) + ":");
            //    for (int j = 0; j < group.Length; j++)
            //    {
            //        Console.WriteLine(group[j]);
            //    }
            //    Console.WriteLine();
            //}

            int amountOfGroups = (lastNames.Count / 2);

            for (int i = 0; i < amountOfGroups; i++) //loopa så länge i är mindre än antalet grupper
            {

                Random rnd = new Random();
                int g = rnd.Next(0, 4); //g var antal gruppmedlemmar

                string[] group = new string[g];


                for (int j = 0; j < group.Length; j++)
                {
                    group[j] = lastNames[(j * amountOfGroups) + i];
                }

                Console.WriteLine("Grupp " + (i + 1) + ":");
                for (int j = 0; j < group.Length; j++)
                {
                    Console.WriteLine(group[j]);
                }
                Console.WriteLine();

            }

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
