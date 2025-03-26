namespace Domain.Entities
{
    public class Cart
    {
        public List<CartItem> Data { get; set; }
        public int TotalItems { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }

        public Cart()
        {
            Data = new List<CartItem>();
        }

        public Cart(List<CartItem> data, int totalItems, int currentPage, int totalPages)
        {
            Data = data;
            TotalItems = totalItems;
            CurrentPage = currentPage;
            TotalPages = totalPages;
        }
    }
}
