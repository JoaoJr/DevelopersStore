using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface ISaleRepository
    {
        void AddSale(Sale sale);
        Sale GetSaleByNumber(int saleNumber);
        List<Sale> GetAllSales();
        void UpdateSale(Sale sale);
        void CancelSale(int saleNumber);
    }
}
