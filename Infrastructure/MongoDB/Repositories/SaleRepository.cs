using Domain.Entities;
using Infrastructure.Repositories;
using MongoDB.Driver;

namespace Infrastructure.MongoDB.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly IMongoCollection<Sale> _salesCollection;

        public SaleRepository(IMongoDatabase database)
        {
            _salesCollection = database.GetCollection<Sale>("sales");
        }

        public void AddSale(Sale sale)
        {
            _salesCollection.InsertOne(sale);
        }

        public Sale GetSaleByNumber(int saleNumber)
        {
            return _salesCollection.Find(sale => sale.SaleNumber == saleNumber).FirstOrDefault();
        }

        public List<Sale> GetAllSales()
        {
            return _salesCollection.Find(_ => true).ToList();
        }

        public void UpdateSale(Sale sale)
        {
            var filter = Builders<Sale>.Filter.Eq(s => s.SaleNumber, sale.SaleNumber);
            _salesCollection.ReplaceOne(filter, sale);
        }

        public void CancelSale(int saleNumber)
        {
            var filter = Builders<Sale>.Filter.Eq(s => s.SaleNumber, saleNumber);
            var update = Builders<Sale>.Update.Set(s => s.IsCancelled, true);
            _salesCollection.UpdateOne(filter, update);
        }
    }
}
