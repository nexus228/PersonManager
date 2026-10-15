using System.Text.Json.Serialization;

namespace PersonManager_WEB_API.Model
{
    public class Address
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public required string ZipCode { get; set; }

        public required string City { get; set; }

        public required string Street { get; set; }

        public required string HouseNumber { get; set; }

        // Navigation Property
        public Person Person { get; set; }
    }
}
