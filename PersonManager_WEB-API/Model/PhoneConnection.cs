using System.Text.Json.Serialization;

namespace PersonManager_WEB_API.Model
{
    public class PhoneConnection
    {
        public int Id { get; set; }

        [JsonIgnore]
        public int PersonId { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
