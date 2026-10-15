using PersonManager_WPF_CLIENT.DTO;
using PersonManager_WPF_CLIENT.Model;

namespace PersonManager_WPF_CLIENT.Utils
{
    /// <summary>
    /// maps Person-Model-Data to DTOs
    /// maps DTOs to Person-Model-Data
    /// </summary>
    internal static class PersonMapper
    {
        public static PersonDTO PersonToDTO(Person person)
        {
            PersonDTO personDTO = new PersonDTO
            {
                Id = person.Id,
                Name = person.Name,
                FirstName = person.FirstName,
                DateOfBirth = person.DateOfBirth
            };

            List<AddressDTO> addressDTOs = new List<AddressDTO>();

            foreach (Address address in person.Addresses)
            {
                AddressDTO addressDTO = AddressToDTO(address);
                addressDTOs.Add(addressDTO);
            }

            personDTO.Addresses = addressDTOs;


            List<PhoneConnectionDTO> phoneConnectionDTOs = new List<PhoneConnectionDTO>();

            foreach (PhoneConnection phoneConnection in person.PhoneConnections)
            {
                PhoneConnectionDTO phoneConnectionDTO = PhoneConnectionToDTO(phoneConnection);
                phoneConnectionDTOs.Add(phoneConnectionDTO);
            }

            personDTO.PhoneConnections = phoneConnectionDTOs;

            return personDTO;
        }


        private static PhoneConnectionDTO PhoneConnectionToDTO(PhoneConnection phoneConnection)
        {
            PhoneConnectionDTO phoneConnectionDTO = new PhoneConnectionDTO
            {
                Id = phoneConnection.Id,
                PhoneNumber = phoneConnection.PhoneNumber
            };

            return phoneConnectionDTO;
        }

        private static AddressDTO AddressToDTO(Address address)
        {
            AddressDTO addressDTO = new AddressDTO
            {
                Id = address.Id,
                Street = address.Street,
                HouseNumber = address.HouseNumber,
                City = address.City,
                ZipCode = address.ZipCode
            };
            return addressDTO;
        }


        public static Person DTOToPerson(PersonDTO personDTO)
        {
            Person person = new Person
            {
                Id = personDTO.Id,
                Name = personDTO.Name,
                FirstName = personDTO.FirstName,
                DateOfBirth = personDTO.DateOfBirth
            };

            List<Address> addresses = new List<Address>();
            foreach (AddressDTO addressDTO in personDTO.Addresses)
            {
                Address address = DTOToAddress(addressDTO);
                addresses.Add(address);
            }
            person.Addresses = addresses;

            List<PhoneConnection> phoneConnections = new List<PhoneConnection>();

            foreach (PhoneConnectionDTO phoneConnectionDTO in personDTO.PhoneConnections)
            {
                PhoneConnection phoneConnection = DTOToPhoneConnection(phoneConnectionDTO);
                phoneConnections.Add(phoneConnection);
            }

            person.PhoneConnections = phoneConnections;

            return person;

        }

        private static PhoneConnection DTOToPhoneConnection(PhoneConnectionDTO phoneConnectionDTO)
        {
            PhoneConnection phoneConnection = new PhoneConnection
            {
                Id = phoneConnectionDTO.Id,
                PhoneNumber = phoneConnectionDTO.PhoneNumber
            };
            return phoneConnection;
        }

        private static Address DTOToAddress(AddressDTO addressDTO)
        {
            Address address = new Address
            {
                Id = addressDTO.Id,
                City = addressDTO.City,
                HouseNumber = addressDTO.HouseNumber,
                ZipCode = addressDTO.ZipCode,
                Street = addressDTO.Street
            };

            return address;
        }
    }
}
