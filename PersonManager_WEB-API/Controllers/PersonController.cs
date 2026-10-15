using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PersonManager_WEB_API.DTO;
using PersonManager_WEB_API.Model;

namespace PersonManager_WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly PersonManagerDbContext _context;

        public PersonController(PersonManagerDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IList<PersonDTO>>> GetPersons()
        {
            var persons = await _context.Persons
            .AsNoTracking()
            .Include(p => p.Addresses)
            .Include(p => p.PhoneConnections)
            .ToListAsync();

            if (persons == null)
                return NotFound();

            var result = new List<PersonDTO>();

            foreach (var person in persons)
            {
                PersonDTO dto = _personToDTO(person);
                result.Add(dto);
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PersonDTO>> CreatePerson(PersonDTO personDTOToCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            Person personToCreate = _dtoToPerson(personDTOToCreate);

            _context.Persons.Add(personToCreate);
            await _context.SaveChangesAsync();

            PersonDTO createdPersonDto = _personToDTO(personToCreate);

            return Ok(createdPersonDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonDTO>> UpdatePerson(int id, PersonDTO personDTOToUpdate)
        {

            if (id != personDTOToUpdate.Id)
            {
                return BadRequest();
            }

            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            person.FirstName = personDTOToUpdate.FirstName;
            person.Name = personDTOToUpdate.Name;
            person.DateOfBirth = personDTOToUpdate.DateOfBirth;


            try
            {
                await _context.SaveChangesAsync();

                PersonDTO dto = _personToDTO(person);
                return Ok(dto);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the person.");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            { return NotFound(); }


            person.Addresses = await _context.Addresses.Where(address => address.PersonId == id).ToListAsync();
            person.PhoneConnections = await _context.PhoneConnections.Where(phoneConnection => phoneConnection.PersonId == id).ToListAsync();

            if (person.Addresses != null)
            {
                foreach (var addressToDelete in person.Addresses)
                {
                    _context.Addresses.Remove(addressToDelete);
                }
                await _context.SaveChangesAsync();
            }

            if (person.PhoneConnections != null)
            {
                foreach (var phoneConnectionToDelete in person.PhoneConnections)
                {
                    _context.PhoneConnections.Remove(phoneConnectionToDelete);
                }
                await _context.SaveChangesAsync();
            }
            _context.Persons.Remove(person);

            await _context.SaveChangesAsync();
            return Ok(person);
        }


        private Person _dtoToPerson(PersonDTO personDTO)
        {
            return new Person
            {
                
                FirstName = personDTO.FirstName,
                Name = personDTO.Name,
                DateOfBirth = personDTO.DateOfBirth,

                Addresses = personDTO.Addresses.Select(a =>
                    new Address
                    {               
                        ZipCode = a.ZipCode,
                        City = a.City,
                        Street = a.Street,
                        HouseNumber = a.HouseNumber
                    }).ToList(),

                PhoneConnections = personDTO.PhoneConnections.Select(p =>
                    new PhoneConnection
                    {
                        PhoneNumber = p.PhoneNumber
                    }).ToList()
            };
        }

        private PersonDTO _personToDTO(Person person)
        {
            return new PersonDTO
            {
                Id = person.Id,
                FirstName = person.FirstName,
                Name = person.Name,
                DateOfBirth = person.DateOfBirth,

                Addresses = person.Addresses.Select(a =>
                    new AddressDTO
                    {
                        Id = a.Id,
                        ZipCode = a.ZipCode,
                        City = a.City,
                        Street = a.Street,
                        HouseNumber = a.HouseNumber
                    }).ToList(),

                PhoneConnections = person.PhoneConnections.Select(p =>
                    new PhoneConnectionDTO
                    {
                        Id = p.Id,
                        PhoneNumber = p.PhoneNumber
                    }).ToList()
            };
        }
    }
}



  
