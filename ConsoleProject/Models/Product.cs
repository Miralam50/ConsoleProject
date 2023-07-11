using ConsoleProject.Base;
using ConsoleProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Models
{
    public class Product : BaseEntity
    {
        private static int _count = 0;

        public Product()
        {
            ProductCode = _count;
            _count++;
        }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int Count { get; set; }
        public int ProductCode { get; set; }

    }
}
