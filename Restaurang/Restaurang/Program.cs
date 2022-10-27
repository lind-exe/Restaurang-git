namespace Restaurang
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restaurant restaurant = new Restaurant(80);
            Guest person = new Guest();

            

            //foreach (Person person in restaurant.Guests)
            //{
            //    Console.WriteLine(person.Name);


            //}
            person.Groups();
        }
    }
}