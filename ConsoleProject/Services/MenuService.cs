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
                if (Enum.TryParse<Category>(selectionCategory, out Category slnCategory))
                {
                    Console.WriteLine($"Selected category: {selectionCategory}");
                    var products = marketService.ShowProductAccordingToCategory(slnCategory);

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
                else
                {
                    Console.WriteLine("Invalid category selection.");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }   
        }

        public static void MenuProductAccordingToPriceInterval()
{
    try
    {
        Console.WriteLine("Enter lowest product's price:");
        int lowestPrice = int.Parse(Console.ReadLine());

       
        Console.WriteLine("Enter highest product's price:");
        int highestPrice = int.Parse(Console.ReadLine());

        if (lowestPrice < 0 && highestPrice<0)
        {
            throw new Exception("Price may not be negative...");
        }

        var products = marketService.ShowProductAccordingToPrice(lowestPrice, highestPrice);
        var table = new ConsoleTable("Name", "Price", "Category", "Count", "Product Code");

        if (products.Count == 0)
        {
            Console.WriteLine("No products yet.");
            return;
        }

        foreach (var product in products)
        {
            table.AddRow(product.Name, product.Price, product.Category, product.Count, product.ProductCode);
        }

        table.Write();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oops! Got an error!");
            Console.WriteLine(ex.Message);
        }
        }

        public static void MenuProductAccordingToName()
        {
            try
            {
                Console.WriteLine("Enter product's name:");
                var inputName = Console.ReadLine();
                var products = marketService.ShowProductAccordingToName(inputName);
                var table = new ConsoleTable("Name", "Price", "Category", "Count", "Product Code");

                if (products.Count == 0)
                {
                    Console.WriteLine("No products yet.");
                    return;
                }

                foreach (var product in products)
                {
                    table.AddRow(product.Name, product.Price, product.Category, product.Count, product.ProductCode);
                }

                table.Write();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void UpdateProduct()
        {
            try
            {
                Console.WriteLine("Enter the code:");
                int code = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the new name:");
                string newName = Console.ReadLine();

                Console.WriteLine("Enter the new quantity:");
                int newQuantity = int.Parse(Console.ReadLine());

                Console.WriteLine("Available categories:");
                foreach (Category category in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine($"{(int)category}. {category}");
                }
                Console.WriteLine("Enter the category (number) of the new product:");
                int categoryNumber = int.Parse(Console.ReadLine());

                if (!Enum.IsDefined(typeof(Category), categoryNumber))
                {
                    Console.WriteLine("Invalid category number!");
                    return;
                }
                Category newCategory = (Category)categoryNumber;

                Console.WriteLine("Enter the new price:");
                decimal newPrice = decimal.Parse(Console.ReadLine());
                marketService.UpdateProduct(code, newName, newQuantity, categoryNumber, newPrice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while processing.Error message : {ex.Message} ");

            }
        }
    }
    #endregion

    #region Sales
        
    #endregion
}

