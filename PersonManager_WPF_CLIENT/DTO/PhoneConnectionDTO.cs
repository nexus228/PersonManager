using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManager_WPF_CLIENT.DTO
{
    internal class PhoneConnectionDTO
    {
        public int Id { get; set; }

        public required string PhoneNumber { get; set; }
    }
}
