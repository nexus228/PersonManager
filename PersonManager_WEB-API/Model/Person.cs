using System.ComponentModel.DataAnnotations;

namespace PersonManager_WEB_API.Model
{
    public class Person
    {
        public int Id { get; set; }

        public required string FirstName { get; set; }

        public required string Name { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public List<Address> Addresses { get; set; } = new();

        public List<PhoneConnection> PhoneConnections { get; set; } = new();

    }
}
