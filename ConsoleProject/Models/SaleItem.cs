using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Models
{
    public class SaleItem
    {
        private static int _count = 0;
        public SaleItem(Product product, int count)
        {
            Id = _count;
            Product = product;
            Count = count;
            _count++;
        }

        //public int Number { get; set; }
        public Product Product { get; set; }
        public int Id { get; set; }
        public int Count { get; set; }

    }
}
