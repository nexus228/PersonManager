namespace PersonManager_WEB_API.DTO
{
    public class AddressDTO
    {
        public int Id { get; set; }

        public required string ZipCode { get; set; }

        public required string City { get; set; }

        public required string Street { get; set; }

        public required string HouseNumber { get; set; }
    }
}
