using Domain.Entities;
using Infrastructure.Repositories;

namespace Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }

        public void AddSale(Sale sale)
        {
            if (sale == null || sale.Items == null || sale.Items.Count == 0)
                throw new ArgumentException("A venda deve conter pelo menos um item válido.");

            foreach (var item in sale.Items)
            {
                if (item.Product == null)
                    throw new ArgumentException($"O item com quantidade {item.Quantity} não possui um produto associado.");

                if (item.Quantity <= 0)
                    throw new ArgumentException("A quantidade de um item deve ser maior que zero.");
            }

            sale.Date = DateTime.Now;
            _saleRepository.AddSale(sale);
        }

        public Sale GetSaleByNumber(int saleNumber)
        {
            var sale = _saleRepository.GetSaleByNumber(saleNumber);
            if (sale == null)
                throw new KeyNotFoundException($"Venda com número {saleNumber} não encontrada.");
            return sale;
        }

        public List<Sale> GetAllSales()
        {
            return _saleRepository.GetAllSales();
        }

        public void UpdateSale(int saleNumber, Sale updatedSale)
        {
            var existingSale = _saleRepository.GetSaleByNumber(saleNumber);
            if (existingSale == null)
                throw new KeyNotFoundException($"Venda com número {saleNumber} não encontrada.");

            existingSale.Date = updatedSale.Date;
            existingSale.Customer = updatedSale.Customer;
            existingSale.Branch = updatedSale.Branch;
            existingSale.Items = updatedSale.Items;

            if (existingSale.Items == null || existingSale.Items.Count == 0)
                throw new ArgumentException("A venda atualizada deve conter pelo menos um item válido.");

            existingSale.IsCancelled = updatedSale.IsCancelled;

            _saleRepository.UpdateSale(existingSale);
        }

        public void CancelSale(int saleNumber)
        {
            var sale = _saleRepository.GetSaleByNumber(saleNumber);
            if (sale == null)
                throw new KeyNotFoundException($"Venda com número {saleNumber} não encontrada.");

            if (sale.IsCancelled)
                throw new InvalidOperationException("A venda já está cancelada.");

            sale.IsCancelled = true;
            _saleRepository.UpdateSale(sale);
        }
    }
}
