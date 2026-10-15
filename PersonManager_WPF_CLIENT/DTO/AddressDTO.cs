using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManager_WPF_CLIENT.DTO
{
    internal class AddressDTO
    {
        public int Id { get; set; }

        public required string ZipCode { get; set; }

        public required string City { get; set; }

        public required string Street { get; set; }

        public required string HouseNumber { get; set; }
    }
}
