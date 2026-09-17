using System.Text.Json.Serialization;

namespace PersonManager_WEB_API.Model
{
    public class Address
    {
        public int Id { get; set; }
        [JsonIgnore]
        public int PersonId { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
    }
}
