namespace Domain.ValueObjects
{
    public class Rating
    {
        public decimal Rate { get; set; }
        public int Count { get; set; }

        public Rating()
        {
        }

        public Rating(decimal rate, int count)
        {
            Rate = rate;
            Count = count;
        }
    }
}
