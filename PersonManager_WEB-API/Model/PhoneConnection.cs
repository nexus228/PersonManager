using System.Text.Json.Serialization;

namespace PersonManager_WEB_API.Model
{
    public class PhoneConnection
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public required string PhoneNumber { get; set; }

        // Navigation Property
        public Person Person { get; set; }
    }
}
