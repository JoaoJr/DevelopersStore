namespace Domain.Entities
{
    public class Sale
    {
        public int SaleNumber { get; set; }
        public DateTime Date { get; set; }
        public User Customer { get; set; }
        public string Branch { get; set; }
        public List<SaleItem> Items { get; set; }
        public decimal TotalAmount => Items.Sum(item => item.Total);
        public bool IsCancelled { get; set; }

        public Sale()
        {
            Items = new List<SaleItem>();
        }

        public Sale(int saleNumber, DateTime date, User customer, string branch, List<SaleItem> items, bool isCancelled = false)
        {
            SaleNumber = saleNumber;
            Date = date;
            Customer = customer;
            Branch = branch;
            Items = items ?? new List<SaleItem>();
            IsCancelled = isCancelled;
        }
    }

}
