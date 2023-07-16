using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Models
{
    public class Sale
    {
        private static int _count = 0;

        public Sale()
        {
            Number = _count;
            _count++;
        }

        public Sale(decimal amount, List<SaleItem> saleItems)
        {
            Number = _count;
            Amount = amount;
            SaleItems = saleItems;
            _count++;
        }

        public int Number { get; set; }
        public decimal Amount { get; set; }
        public List<SaleItem> SaleItems { get; set; }
        public DateTime SaleTime { get; set; } = DateTime.Now;
    }
}
