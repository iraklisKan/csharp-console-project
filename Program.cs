using System;
using RetailAnalytics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Retail Sales Statistics Calculator");
        Console.WriteLine("----------------------------------\n");

        var analyzer = new RetailAnalyzer();
        var menuHandler = new MenuHandler(analyzer);

        // Load sample data
        analyzer.LoadSampleData();

        bool running = true;
        while (running)
        {
            menuHandler.ShowMenu();
            string choice = Console.ReadLine();

            if (choice == "5")
            {
                running = false;
            }

            menuHandler.HandleOption(choice);
        }
    }
}
