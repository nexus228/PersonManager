namespace PersonManager_WPF_CLIENT.Model
{
    internal class Person
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? FirstName { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public List<Address>? Addresses { get; set; }

        public List<PhoneConnection>? PhoneConnections { get; set; }
    }
}
