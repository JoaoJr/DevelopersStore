namespace Domain.ValueObjects
{
    public class Geolocation
    {
        public string Lat { get; set; }
        public string Long { get; set; }

        public Geolocation()
        {
        }

        public Geolocation(string lat, string @long)
        {
            Lat = lat;
            Long = @long;
        }
    }
}
