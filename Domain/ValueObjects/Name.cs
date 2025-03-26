namespace Domain.ValueObjects
{
    public class Name
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }

        public Name()
        {
        }

        public Name(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }
    }
}
