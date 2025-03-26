namespace Domain.Entities
{
    public class ProductItem
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public ProductItem()
        {
        }

        public ProductItem(int productId, int quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }
    }
}
