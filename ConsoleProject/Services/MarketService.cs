using ConsoleProject.Base;
using ConsoleProject.Enums;
using ConsoleProject.Models;

namespace ConsoleProject.Services
{
    public class MarketService : IMarketService
    {
        public List<Product> Products { get; set; } = new List<Product>
        {
            new Product()
            {
                Category = Category.A,
                Count = 10,
                Name = "Cola 1LT",
                Price = 1.4m
            },
            new Product()
            {
                Category = Category.A,
                Count = 10,
                Name = "Fanta 1LT",
                Price = 1.4m
            },
            new Product()
            {
                Category = Category.A,
                Count = 10,
                Name = "Sprite 1LT",
                Price = 1.4m
            }
        };
        public List<Sale> Sales { get; set; } = new List<Sale>();
        public List<SaleItem> SaleItems { get; set; } = new List<SaleItem>();

        public MarketService()
        {
            
        }

        public List<Product> GetProducts()
        {
            return this.Products;
        }

        /// <summary>
        /// Adding new products
        /// </summary>
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
            return newProduct.Id;
        }

        /// <summary>
        /// Deleting existing products
        /// </summary>
        public void DeleteProduct(int Id)
        {
            var currentProduct = Products.FirstOrDefault(e => e.Id == Id);

            if(currentProduct is not null)
            {
                Products.Remove(currentProduct);
            }
            else
            {
                //custom not found exception
            }
        }

        /// <summary>
        /// Cheking product quantity have or not have
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public bool CheckProductQuantity(int productId,int quantity)
        {
            var currentProduct = Products.FirstOrDefault(e => e.Id == productId);

            if(currentProduct is not null)
            {
                return currentProduct.Count > quantity;
            }
            else
            {
                //return custom exception - NotInStockException
                return false;
            }
        }

        /// <summary>
        /// Decreasing product quantity for sale
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        public void DecreaseProductQuantity(int productId, int quantity)
        {
            var currentProduct = Products.FirstOrDefault(e => e.Id == productId);

            if (currentProduct is not null)
            {
                currentProduct.Count -= quantity;
            }
            else
            {
                //return custom exception - NotInStockException
            }
        }

        /// <summary>
        /// Increasing product quantity for sale
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        public void IncreaseProductQuantity(int productId, int quantity)
        {
            var currentProduct = Products.FirstOrDefault(e => e.Id == productId);

            if (currentProduct is not null)
            {
                currentProduct.Count += quantity;
            }
            else
            {
                //return custom exception - NotInStockException
            }
        }

        /// <summary>
        /// Showing product according to its category
        /// </summary>
        /// <param name="selectedCategory"></param>
        /// <returns></returns>
        public List<Product> ShowProductAccordingToCategory(Category selectedCategory)
        {
            var data = Products.Where(x => x.Category == selectedCategory).ToList();
            return data;
        }

        /// <summary>
        /// Showing product according to its price
        /// </summary>
        /// <param name="lowest"></param>
        /// <param name="highest"></param>
        /// <returns></returns>
        public List<Product> ShowProductAccordingToPrice(int lowest, int highest)
        {
            var data = Products.Where(x => x.Price >= lowest && x.Price <= highest).ToList();
            return data;
        }

        /// <summary>
        /// Showing product according to its name
        /// </summary>
        /// <param name="inputname"></param>
        /// <returns></returns>
        public List<Product> ShowProductAccordingToName(string inputname)
        {
            var data = Products.Where(x => x.Name == inputname).ToList();
            return data;
        }

        /// <summary>
        /// This metod editing products properties
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="name"></param>
        /// <param name="count"></param>
        /// <param name="category"></param>
        /// <param name="price"></param>
        public void UpdateProduct(int Id, string name, int count, object category, decimal price)
        {
            // Find the product to update
            var update = Products.FirstOrDefault(x => x.Id == Id);
            if (update == null)
                throw new Exception($"{Id} is invalid");
            if (price < 0)
                throw new FormatException("Price is lower than 0!");
            if (count < 0)
                throw new FormatException("Invalid count!");
            update.Name = name;
            update.Price = price;
            update.Count = count;
            update.Category = (Category)category;

        }

        /// <summary>
        /// That metod adding new sales
        /// </summary>
        /// <param name="sale"></param>
        /// <exception cref="Exception"></exception>
        public void AddSale(Sale sale)
        {
            foreach (var saleItem in sale.SaleItems)
            {
                var tmp = CheckProductQuantity(saleItem.Product.Id, saleItem.Count);
                if (!tmp)
                {
                    //new custom exception - NotEnoughInStcokException
                    throw new Exception($"Not enough {saleItem.Count} {saleItem.Product.Name} in Stock");
                }
            }

            Sales.Add(sale);

            foreach (var saleItem in sale.SaleItems)
            {
                DecreaseProductQuantity(saleItem.Product.Id, saleItem.Count);
            }

        }

    }
}


