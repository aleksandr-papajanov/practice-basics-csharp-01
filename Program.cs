namespace PracticeBasicsCSharp01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmployeeRegistry registry = new EmployeeRegistry();
            ConsoleUI ui = new ConsoleUI(registry);

            ui.Start();
        }

    }
}
