namespace GUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] todoList = new string[4];
            todoList[0] = "Diska";
            todoList[1] = "Mata katten";
            todoList[2] = "Städa";
            todoList[3] = "Äta";

            Window.Draw("Att göra", 5, 5, todoList);

        }
    }
}