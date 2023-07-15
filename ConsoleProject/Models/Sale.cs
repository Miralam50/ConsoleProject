using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Models
{
    public class Sale
    {
        public int Number { get; set; }
        public decimal Amount { get; set; }
        public SaleItem SaleItem { get; set; }
        public DateTime SaleTime { get; set; }
        public List<Product> Products { get; set; }
        public DateTime Date { get; internal set; }
    }
}
