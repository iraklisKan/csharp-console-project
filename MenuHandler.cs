using System;
using RetailAnalytics;

namespace RetailAnalytics
{
    public class MenuHandler
    {
        private readonly RetailAnalyzer analyzer;

        public MenuHandler(RetailAnalyzer analyzer)
        {
            this.analyzer = analyzer;
        }

        public void ShowMenu()
        {
            Console.WriteLine("\nAvailable Statistics:");
            Console.WriteLine("1. Average of earnings for a range of years");
            Console.WriteLine("2. Standard deviation of earnings within a specific year");
            Console.WriteLine("3. Standard deviation of earnings for a range of years");
            Console.WriteLine("4. Show all data");
            Console.WriteLine("5. Exit");
            Console.Write("Select option (1-5): ");
        }

        public void HandleOption(string option)
        {
            switch (option)
            {
                case "1":
                    CalculateAverageForYearRange();
                    break;
                case "2":
                    CalculateStandardDeviationForYear();
                    break;
                case "3":
                    CalculateStandardDeviationForYearRange();
                    break;
                case "4":
                    ShowAllData();
                    break;
                case "5":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select 1-5.");
                    break;
            }
        }

        private void CalculateAverageForYearRange()
        {
            Console.Write("Enter start year: ");
            int startYear = int.Parse(Console.ReadLine());
            Console.Write("Enter end year: ");
            int endYear = int.Parse(Console.ReadLine());

            double average = analyzer.CalculateAverageEarnings(startYear, endYear);
            if (average >= 0)
                Console.WriteLine($"Average earnings for {startYear}-{endYear}: ${average:F2}");
            else
                Console.WriteLine($"No data found for years {startYear}-{endYear}");
        }

        private void CalculateStandardDeviationForYear()
        {
            Console.Write("Enter year: ");
            int year = int.Parse(Console.ReadLine());

            double stdDev = analyzer.CalculateStandardDeviationForYear(year);
            if (stdDev >= 0)
                Console.WriteLine($"Standard deviation for {year}: {stdDev:F2}");
            else
                Console.WriteLine($"No data found for year {year}");
        }

        private void CalculateStandardDeviationForYearRange()
        {
            Console.Write("Enter start year: ");
            int startYear = int.Parse(Console.ReadLine());
            Console.Write("Enter end year: ");
            int endYear = int.Parse(Console.ReadLine());

            double stdDev = analyzer.CalculateStandardDeviationForYearRange(startYear, endYear);
            if (stdDev >= 0)
                Console.WriteLine($"Standard deviation for {startYear}-{endYear}: {stdDev:F2}");
            else
                Console.WriteLine($"No data found for years {startYear}-{endYear}");
        }

        private void ShowAllData()
        {
            analyzer.ShowAllData();
        }
    }
}
