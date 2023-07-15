using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Models
{
    public class SaleItem
    {
        public int Number { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }

        public static implicit operator SaleItem(List<SaleItem> v)
        {
            throw new NotImplementedException();
        }
    }
}
