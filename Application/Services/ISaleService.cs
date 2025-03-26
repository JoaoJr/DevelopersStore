using Domain.Entities;

namespace Application.Services
{
    public interface ISaleService
    {
        void AddSale(Sale sale);
        Sale GetSaleByNumber(int saleNumber);
        List<Sale> GetAllSales();
        void UpdateSale(int saleNumber, Sale updatedSale);
        void CancelSale(int saleNumber);
    }
}
