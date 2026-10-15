namespace PersonManager_WPF_CLIENT.Model
{
    internal class Person
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string FirstName { get; set; }

        public DateOnly DateOfBirth { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();

        public List<PhoneConnection> PhoneConnections { get; set; } = new List<PhoneConnection>();
    }
}
