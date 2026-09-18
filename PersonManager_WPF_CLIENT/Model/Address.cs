using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManager_WPF_CLIENT.Model
{
    internal class Address
    {
        public int Id { get; set; }
        public string? Street { get; set; }
        public string? HouseNumber { get; set; }
        public string? ZipCode { get; set; }
        public string? City { get; set; }
    }
}
