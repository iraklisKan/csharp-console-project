using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using RetailAnalytics.Models;

namespace RetailAnalytics
{
    public class RetailAnalyzer
    {
        private List<SaleRecord> salesRecords;

        public RetailAnalyzer()
        {
            salesRecords = new List<SaleRecord>();
        }

        public void LoadSampleData()
        {
            LoadDataFromFile("sample_data.txt");
        }

        public void LoadDataFromFile(string filePath)
        {
            salesRecords.Clear();
            
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"File {filePath} not found.");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);
            int successCount = 0;
            int errorCount = 0;

            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                try
                {
                    string[] parts = line.Split("##");
                    if (parts.Length == 2)
                    {
                        DateTime date = DateTime.ParseExact(parts[0], "dd/MM/yyyy", null);
                        decimal amount = decimal.Parse(parts[1]);
                        
                        var sale = new SaleRecord(date, amount);
                        salesRecords.Add(sale);
                        successCount++;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"Skipped invalid line: {line}");
                    errorCount++;
                }
            }

            Console.WriteLine($"\nLoaded {successCount} sales records");
            if (errorCount > 0)
                Console.WriteLine($"Skipped {errorCount} invalid records");
        }

        public double CalculateAverageEarnings(int startYear, int endYear)
        {
            var filteredRecords = salesRecords.Where(r => r.Date.Year >= startYear && r.Date.Year <= endYear).ToList();
            
            if (!filteredRecords.Any())
                return -1;

            return (double)filteredRecords.Average(r => r.Amount);
        }

        public double CalculateStandardDeviationForYear(int year)
        {
            var yearRecords = salesRecords.Where(r => r.Date.Year == year).ToList();
            
            if (!yearRecords.Any())
                return -1;

            return CalculateStandardDeviation(yearRecords);
        }

        public double CalculateStandardDeviationForYearRange(int startYear, int endYear)
        {
            var filteredRecords = salesRecords.Where(r => r.Date.Year >= startYear && r.Date.Year <= endYear).ToList();
            
            if (!filteredRecords.Any())
                return -1;

            return CalculateStandardDeviation(filteredRecords);
        }

        private double CalculateStandardDeviation(List<SaleRecord> records)
        {
            if (records.Count <= 1)
                return 0;

            double mean = (double)records.Average(r => r.Amount);
            double sumOfSquares = records.Sum(r => Math.Pow((double)r.Amount - mean, 2));
            double variance = sumOfSquares / (records.Count - 1);

            return Math.Sqrt(variance);
        }

        public void ShowAllData()
        {
            Console.WriteLine("\nAll Sales Data:");
            Console.WriteLine("----------------");
            
            if (salesRecords.Count == 0)
            {
                Console.WriteLine("No data available.");
                return;
            }

            foreach (var record in salesRecords.OrderBy(r => r.Date))
            {
                Console.WriteLine($"{record.Date:dd/MM/yyyy}##{record.Amount:F2}");
            }
            
            Console.WriteLine($"\nTotal records: {salesRecords.Count}");
        }
    }
}
