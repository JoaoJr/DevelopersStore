namespace Domain.ValueObjects
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
        public string Zipcode { get; set; }
        public Geolocation Geolocation { get; set; }

        public Address()
        {
        }

        public Address(string city, string street, int number, string zipcode, Geolocation geolocation)
        {
            City = city;
            Street = street;
            Number = number;
            Zipcode = zipcode;
            Geolocation = geolocation;
        }
    }
}
