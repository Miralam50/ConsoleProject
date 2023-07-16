using ConsoleProject.Models;

namespace ConsoleProject.Base
{
    public interface IMenuService
    {
        void MenuProducts();
        void MenuAddProduct();

        void MenuDeleteProduct();
        void MenuShowProductAccordingToCategory();
        void MenuProductAccordingToPriceInterval();
        void MenuProductAccordingToName();
        void UpdateProduct();
        void MenuAddSales();
        void MenuShowAllSales();
        void MenuShowAllSalesByTimeInterval(DateTime fromDate, DateTime toDate);
        void MenuShowAllSalesByPriceInterval(decimal fromPrice, decimal toPrice);
        void ShowSaleDetailsById(int saleId);
        void RefundProduct();
        void RemoveSale();
        void ShowSaleByTimeInterval();
        void ShowSaleByPriceInterval();
    }
}
