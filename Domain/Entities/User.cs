using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public class User
    {
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Name Name { get; set; }
        public Address Address { get; set; }
        public string Phone { get; set; }
        public UserStatus Status { get; set; }
        public UserRole Role { get; set; }

        public User()
        {
        }

        public User(string email, string username, string password, Name name, Address address, string phone, UserStatus status, UserRole role)
        {
            Email = email;
            Username = username;
            Password = password;
            Name = name;
            Address = address;
            Phone = phone;
            Status = status;
            Role = role;
        }
    }
}
