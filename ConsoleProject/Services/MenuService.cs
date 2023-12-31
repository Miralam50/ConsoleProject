﻿using ConsoleProject.Base;
using ConsoleProject.Enums;
using ConsoleProject.Models;
using ConsoleTables;
using System.Linq.Expressions;

namespace ConsoleProject.Services
{

    public class MenuService
    {
        private static MarketService marketService = new();

        #region Product

        /// <summary>
        /// Showing products
        /// </summary>
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
                        product.Count, product.Id);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Adding new products
        /// </summary>
        public static void MenuAddProduct()
        {
            try
            {
                Console.WriteLine("Enter product's name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter product's price:");
                decimal price = decimal.Parse(Console.ReadLine());

                if (price <= 0)
                {
                    throw new Exception("Price must be positive");
                }

                Console.WriteLine("Enter product's category:");
                foreach (var item in Enum.GetNames(typeof(Category)))
                {
                    Console.WriteLine(item);
                }
                string category = Console.ReadLine().ToUpper();

                Console.WriteLine("Enter product's count:");
                int count = int.Parse(Console.ReadLine());

                if (count <= 0)
                {
                    throw new Exception("Count must be positive");
                }
                int Id = marketService.AddProduct(name, price, category, count);
                Console.WriteLine($"Added product with product code: {Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Deleting existing products
        /// </summary>
        public static void MenuDeleteProduct()
        {
            try
            {
                Console.WriteLine("Enter product's code:");
                int Id = int.Parse(Console.ReadLine());

                Console.WriteLine($"Successfully deleted product with Number: {Id}");
                marketService.DeleteProduct(Id);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Showing products for category
        /// </summary>
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
                            product.Count, product.Id);
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

        /// <summary>
        /// Showing products for prices
        /// </summary>
        public static void MenuProductAccordingToPriceInterval()
        {
            try
            {
                Console.WriteLine("Enter lowest product's price:");
                int lowestPrice = int.Parse(Console.ReadLine());


                Console.WriteLine("Enter highest product's price:");
                int highestPrice = int.Parse(Console.ReadLine());

                if (lowestPrice < 0 && highestPrice < 0)
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
                    table.AddRow(product.Name, product.Price, product.Category, product.Count, product.Id);
                }

                table.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Showing products for names
        /// </summary>
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
                    table.AddRow(product.Name, product.Price, product.Category, product.Count, product.Id);
                }

                table.Write();
            }
            catch (Exception ex)
            {

                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Editing products properties
        /// </summary>
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
                if (newQuantity < 0)
                {
                    throw new Exception("Please enter positive input");
                }

                Console.WriteLine("Available categories:");
                foreach (Category category in Enum.GetValues(typeof(Category)))
                {
                    Console.WriteLine($"{(int)category}. {category}");
                }
                Console.WriteLine("Enter the category (number) of the new product:");
                int categoryNumber = int.Parse(Console.ReadLine());
                if (categoryNumber < 0)
                {
                    throw new Exception("Please enter positive input");
                }

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


        #endregion

        #region Sales
        /// <summary>
        /// Adding new sales for user inputs
        /// </summary>
        public static void MenuAddSales()
        {
            bool showProductMenu = true;
            List<SaleItem> saleItems = new List<SaleItem>();

            while (showProductMenu)
            {
                Console.Clear();
                Console.WriteLine("Choose product by product code : ");
                MenuService.MenuProducts();
                var productCode = Int32.Parse(Console.ReadLine());

                if(productCode < 0)
                {
                    throw new Exception("Product code must be positive");
                }

                Console.WriteLine("Enter product quantity : ");

                var productQuantity = Int32.Parse(Console.ReadLine());

                if (productQuantity <= 0)
                {
                    throw new Exception("Product quantity must be positive");
                }

                var currentProduct = marketService.Products.FirstOrDefault(e => e.Id == productCode);

                var currentSaleItem = new SaleItem(currentProduct, productQuantity);

                saleItems.Add(currentSaleItem);

                Console.WriteLine("Do you want to continue? y/n");
                var option = Console.ReadLine();
                if (option.ToLower() != "y")
                {
                    showProductMenu = false;
                }
            }

            var amountOfCurrentSaleItems = saleItems.Select(e => e.Product.Price * e.Count).Sum();

            Sale sale = new Sale(amountOfCurrentSaleItems, saleItems);

            marketService.AddSale(sale);


            //Product product = new Product("kola", 4, Category.A, 3, 0);
            //List<SaleItem> saleItems = new List<SaleItem>();
            //SaleItem saleItem = new SaleItem(1, product, 2);
            //saleItems.Add(saleItem);

        }

        /// <summary>
        /// Showing all existing sales
        /// </summary>
        public static void MenuShowAllSales()
        {
            var table = new ConsoleTable("Number", "Amount",
                   "SaleTime");

            var sales = marketService.Sales;

            //if (sales.Count == 0)
            //{
            //    Console.WriteLine("No product's yet.");
            //    return;
            //}

            foreach (var sale in sales)
            {
                table.AddRow(sale.Number, sale.Amount, sale.SaleTime);
            }

            table.Write();
        }

        /// <summary>
        /// Showing existing sales for datetime
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        public static void MenuShowAllSalesByTimeInterval(DateTime fromDate, DateTime toDate)
        {
            var table = new ConsoleTable("Id", "Amount",
                   "SaleTime");

            var sales = marketService.Sales.Where(i => i.SaleTime >= fromDate && i.SaleTime <= toDate).ToList();

            if (sales.Count == 0)
            {
                Console.WriteLine("No sales found.");
                return;
            }

            foreach (var sale in sales)
            {
                table.AddRow(sale.Number, sale.Amount, sale.SaleTime);
            }

            table.Write();
        }

        /// <summary>
        /// Showing existing sales for amount
        /// </summary>
        /// <param name="fromPrice"></param>
        /// <param name="toPrice"></param>
        public static void MenuShowAllSalesByPriceInterval(decimal fromPrice, decimal toPrice)
        {
            var table = new ConsoleTable("Id", "Amount",
                   "SaleTime");
            var sales = marketService.Sales.Where(i => i.SaleItems.Select(e => e.Product.Price * e.Count).Sum() >= fromPrice && i.SaleItems.Select(e => e.Product.Price * e.Count).Sum() <= toPrice).ToList();

            if (sales.Count == 0)
            {
                Console.WriteLine("No sales found.");
                return;
            }

            foreach (var sale in sales)
            {
                table.AddRow(sale.Number, sale.Amount, sale.SaleTime);
            }

            table.Write();
        }

        /// <summary>
        /// Showing sales details for user
        /// </summary>
        /// <param name="saleId"></param>
        public static void ShowSaleDetailsById(int saleId)
        {

            var currentSale = marketService.Sales.FirstOrDefault(e => e.Number == saleId);

            var currentSaleProducts = currentSale.SaleItems;

            var table = new ConsoleTable("Id", "Name", "Price", "Category",
                   "Quantity");

            var sales = marketService.Sales;

            if (currentSaleProducts.Count == 0)
            {
                Console.WriteLine("No product's yet.");
                return;
            }

            foreach (var saleItem in currentSaleProducts)
            {
                table.AddRow(saleItem.Id, saleItem.Product.Name, saleItem.Product.Price, saleItem.Product.Category,
                    saleItem.Count);
            }

            table.Write();
        }

        /// <summary>
        /// Refunding products to stock and increasing products again
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void RefundProduct()
        {
            MenuShowAllSales();
            Console.WriteLine("Choose sale number for refund : ");
            var currentSaleNumber = Int32.Parse(Console.ReadLine());
            var currentSale = marketService.Sales.FirstOrDefault(e => e.Number == currentSaleNumber);

            if (currentSaleNumber < 0)
            {
                throw new Exception("Sale number must be positive");
            }
            if (currentSale is not null)
            {
                ShowSaleDetailsById(currentSaleNumber);
                Console.WriteLine("Choose Product Id for refund : ");
                var currentProductId = Int32.Parse(Console.ReadLine());
                if(currentProductId < 0)
                {
                    throw new Exception("Product Id must be positive");
                }
                var currentSaleItem = currentSale.SaleItems.FirstOrDefault(i => i.Id == currentProductId);
                var currentProductQuantityInSale = currentSale.SaleItems.FirstOrDefault(i => i.Id == currentProductId).Count;

                Console.WriteLine($"Choose Product Quantity for refund : max({currentProductQuantityInSale})");
                var currentProductQuantity = Int32.Parse(Console.ReadLine());
                if (currentProductQuantityInSale < currentProductQuantity)
                {
                    throw new Exception("Cannot");
                }
                else
                {
                    currentSaleItem.Count -= currentProductQuantity;
                    marketService.IncreaseProductQuantity(currentSaleItem.Product.Id, currentProductQuantity);
                }

            }


            //var currentSaleProducts = currentSale.SaleItems;

            //var table = new ConsoleTable("Name", "Price", "Category",
            //       "Quantity");

            //var sales = marketService.Sales;

            //if (currentSaleProducts.Count == 0)
            //{
            //    Console.WriteLine("No product's yet.");
            //    return;
            //}

            //foreach (var saleItem in currentSaleProducts)
            //{
            //    table.AddRow(saleItem.Product.Name, saleItem.Product.Price, saleItem.Product.Category,
            //        saleItem.Count);
            //}

            //table.Write();
        }

        /// <summary>
        /// Removing sale and saleitems 
        /// </summary>
        public static void RemoveSale()
        {
            try
            {
                MenuShowAllSales();
                Console.WriteLine("Choose sale number for remove : ");
                var currentSaleNumber = Int32.Parse(Console.ReadLine());
                if (currentSaleNumber < 0)
                {
                    throw new Exception("Sale number must be positive");
                }
                var currentSale = marketService.Sales.FirstOrDefault(e => e.Number == currentSaleNumber);

                marketService.Sales.Remove(currentSale);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while processing.Error message : {ex.Message} ");
            }
           
        }

        /// <summary>
        /// Showing sales for datetime
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void ShowSaleByTimeInterval()
        {
            try
            {
                Console.WriteLine("Enter from date : (dd/mm/yyyy)");
                var fromDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine("Enter to date : (dd/mm/yyyy)");
                var toDate = DateTime.Parse(Console.ReadLine());

                if (toDate <= fromDate)
                {
                    throw new Exception("FromDate cannot be lower from ToDate");
                }

                MenuShowAllSalesByTimeInterval(fromDate, toDate);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while processing.Error message : {ex.Message} ");
            }

        }

        /// <summary>
        /// Showing sales for price
        /// </summary>
        /// <exception cref="Exception"></exception>
        public static void ShowSaleByPriceInterval()
        {
            try
            {
                Console.WriteLine("Enter from price : ");
                var fromPrice = Decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter to price : ");
                var toPrice = Decimal.Parse(Console.ReadLine());

                if(fromPrice<=0 && toPrice <= 0)
                {
                    throw new Exception("Price must positive");
                }
                if (toPrice <= fromPrice)
                {
                    throw new Exception("FromPrice cannot be lower from ToPrice");
                }

                MenuShowAllSalesByPriceInterval(fromPrice, toPrice);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error while processing.Error message : {ex.Message} ");
            }

        }
        #endregion

    }
}



