using ConsoleProject.Base;
using ConsoleProject.Enums;

namespace ConsoleProject.Models
{
    public class Product : BaseEntity
    {
        private static int _count = 0;

        public Product()
        {
            Id = _count;
            _count++;
        }

        public Product(string name, decimal price, Category category, int count, int Id)
        {
            Name = name;
            Price = price;
            Category = category;
            Count = count;
            Id = Id;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public int Count { get; set; }
        public int Id { get; set; }

    }
}
