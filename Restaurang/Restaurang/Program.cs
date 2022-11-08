namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Diner diner = new Diner(80, 5, 3, 5, 5); //Gäster, kockar, servitörer, 2bord, 4bord

            diner.Run();
            
            //diner.PrintPeople();

        }
    }
}