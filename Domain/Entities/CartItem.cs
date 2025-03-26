namespace Domain.Entities
{
    public class CartItem
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public List<ProductItem> Products { get; set; }

        public CartItem()
        {
            Products = new List<ProductItem>();
        }

        public CartItem(int id, int userId, DateTime date, List<ProductItem> products)
        {
            Id = id;
            UserId = userId;
            Date = date;
            Products = products;
        }
    }
}
