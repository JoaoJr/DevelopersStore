namespace Domain.Entities
{
    public class SaleItem
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice => Product.Price;
        public decimal Discount { get; set; }
        public decimal Total => (UnitPrice * Quantity) - Discount;

        public SaleItem()
        {
        }

        public SaleItem(Product product, int quantity, decimal discount)
        {
            Product = product;
            Quantity = quantity;
            Discount = discount;
        }
    }

}
