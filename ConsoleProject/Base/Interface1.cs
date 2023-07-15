using ConsoleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleProject.Base
{
    internal interface IMarketable
    {
        int Products { get; set; }
        int Sales { get; set; }
        void AddNewSale();
        void RemoveSale();
        void AllSaleRemove();
        List<Sale> ShowSaleByDate();
        List<Sale> ShowSaleByCustomDate();
        List<Sale> ShowSaleByPrice();
        List<Sale> ShowSaleByNumber();
        void AddNewProduct();
        List<Product> EditingProducts();
        List<Product> ShowProductAccordingToCategory();
        List<Product> ShowProductByPrice();
        List <Product> ShowProductByName();

    }
}
