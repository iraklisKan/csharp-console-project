using System;

namespace RetailAnalytics.Models
{
    public class SaleRecord
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }

        public SaleRecord(DateTime date, decimal amount)
        {
            Date = date;
            Amount = amount;
        }
    }
}
