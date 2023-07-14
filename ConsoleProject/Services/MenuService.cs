using ConsoleProject.Enums;
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Services
{

    public class MenuService
    {
        private static MarketService marketService = new();

        #region Product

        public static void MenuProducts()
        {
            try
            {
                var products = marketService.GetProducts();

                var table = new ConsoleTable("Name", "Price", "Category",
                    "Count", "Product Code");

                if (products.Count == 0)
                {
                    Console.WriteLine("No product's yet.");
                    return;
                }

                foreach (var product in products)
                {
                    table.AddRow(product.Name, product.Price, product.Category,
                        product.Count, product.ProductCode);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuAddProduct()
        {
            try
            {
                Console.WriteLine("Enter product's name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter product's price:");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.WriteLine("Enter product's category:");
                string category = Console.ReadLine();

                Console.WriteLine("Enter product's count:");
                int count = int.Parse(Console.ReadLine());

                int productCode = marketService.AddProduct(name, price, category, count);
                Console.WriteLine($"Added product with product code: {productCode}");
            }
            catch (Exception ex)
            {
                
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuDeleteProduct()
        {
            try
            {
                Console.WriteLine("Enter product's code:");
                int productCode = int.Parse(Console.ReadLine());

                marketService.DeleteProduct(productCode);

                Console.WriteLine($"Successfully deleted product with Number: {productCode}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }  
        }

        public static void MenuShowProductAccordingToCategory()
        {
            try
            {
                Console.WriteLine("Please, select category: ");
                foreach (Category category in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine(category);
                }

                string selectionCategory = Console.ReadLine();
                Console.WriteLine($"Selected category:{selectionCategory}");
                marketService.ShowProductAccordingToCategory(selectionCategory);
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
            
               
        }
        #endregion
    }
}
