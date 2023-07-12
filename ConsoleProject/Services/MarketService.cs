using ConsoleProject.Enums;
using ConsoleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Services
{
    public class MarketService
    {
        public List<Product> Products { get; set; }
        public List<Sale> Sales { get; set; }
        public List<SaleItem> SaleItems { get; set; }
        public MarketService()
        {
            Products = new List<Product>();
            Sales = new List<Sale>();
            SaleItems = new List<SaleItem>();
        }

        public List<Product> GetProducts()
        {
            return Products;
        }

        public int AddProduct(string name, decimal price, string category, int count)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new FormatException("Name is empty!");

            if (price <= 0)
                throw new FormatException("Price is lower than 0!");

            if (string.IsNullOrWhiteSpace(category))
                throw new FormatException("Category is empty!");

            if (count < 0)
                throw new FormatException("Count is lower than 0!");


            bool isSuccessful
                = Enum.TryParse(typeof(Category), category, true, out object parsedCategory);

            if (!isSuccessful)
            {
                throw new InvalidDataException("Category not found!");
            }

            var newProduct = new Product
            {
                Name = name,
                Price = price,
                Category = (Category)parsedCategory,
                Count = count,
            };

            Products.Add(newProduct);
            return newProduct.ProductCode;
        }

        public void DeleteProduct(int productCode)
        {
            var existingProduct = Products.FirstOrDefault(x => x.ProductCode == productCode);

            if (existingProduct == null)
                throw new Exception($"Product with code {productCode} not found!");

            Products = Products.Where(x => x.ProductCode != productCode).ToList();
        }

        public List<Product> GetProductsAccordigToCategory(string categoryName)
        {
            Category selectedCategory;
            if (Enum.TryParse(categoryName,out selectedCategory))
            {

            }
           return Products = Products.Where(x => x.Category == categoryName).ToList();

        }
       
    }
}
