using ConsoleProject.Enums;
using ConsoleProject.Models;

namespace ConsoleProject.Base
{
    public interface IMarketService
    {
        int AddProduct(string name, decimal price, string category, int count);
        void DeleteProduct(int Id);
        bool CheckProductQuantity(int productId, int quantity);
        void DecreaseProductQuantity(int productId, int quantity);
        void IncreaseProductQuantity(int productId, int quantity);
        List<Product> ShowProductAccordingToCategory(Category selectedCategory);
        List<Product> ShowProductAccordingToPrice(int lowest, int highest);
        List<Product> ShowProductAccordingToName(string inputname);
        void UpdateProduct(int Id, string name, int count, object category, decimal price);
        void AddSale(Sale sale);
    }
}
