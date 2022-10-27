namespace Restaurang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Utskrift();
            

            
            //person.Groups();
        }
        public static void Utskrift()
        {
            Restaurant restaurant = new Restaurant(5);
            //Guest person = new Guest();

            Console.WriteLine(":GUESTS:");
            Console.WriteLine();

            foreach (Guest person in restaurant.Guests)
            {
                Console.WriteLine($" {person.Name} med {person.Id} med {person.AmountOfMoney} kr. ");
                Console.WriteLine("--------------------------------------------------");
            }
            Console.WriteLine(":CHEFS:");
            Console.WriteLine();

            foreach (Chef person in restaurant.Chefs)
            {
                Console.WriteLine($" {person.Name} med {person.Id} med {person.Skills} i skicklighet.  ");
                Console.WriteLine("---------------------------------------------------");
            }
            Console.WriteLine(" :WAITERS:");
            Console.WriteLine();

            foreach (Waiter person in restaurant.Waiters)
            {
                Console.WriteLine($" {person.Name} med {person.Id} med {person.ServiceLevel} i skicklighet.  ");
                Console.WriteLine("---------------------------------------------------");
            }
        }
    }
}