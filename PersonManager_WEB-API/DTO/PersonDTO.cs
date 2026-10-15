namespace PersonManager_WEB_API.DTO
{
    public class PersonDTO
    {

        public int Id { get; set; }

        public required string FirstName { get; set; }

        public required string Name { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public List<AddressDTO> Addresses { get; set; } = new();

        public List<PhoneConnectionDTO> PhoneConnections { get; set; } = new();

    }
}
