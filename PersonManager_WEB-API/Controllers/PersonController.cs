using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> GetPersons()
        {
            var persons = await _context.Persons.ToListAsync();

            if (persons == null)
            {
                return NotFound();
            }

            var addresses = await _context.Addresses.ToListAsync();
            var phoneConnections = await _context.PhoneConnections.ToListAsync();

            for (int i = 0; i < persons.Count; i++)
            {
                if (addresses != null)
                {
                    persons[i].Addresses = addresses.Where(a => a.PersonId == persons[i].Id).ToList();
                }

                if (phoneConnections != null)
                {
                    persons[i].PhoneConnections = phoneConnections.Where(p => p.PersonId == persons[i].Id).ToList();
                }
            }

            return Ok(persons);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, Person personToUpdate)
        {
            if (personToUpdate != null)
            {
                if (id != personToUpdate.Id)
                {
                    return BadRequest();
                }

                var person = await _context.Persons.FindAsync(id);

                if (person == null)
                {
                    return NotFound();
                }

                person.FirstName = personToUpdate.FirstName;
                person.Name = personToUpdate.Name;
                person.DateOfBirth = personToUpdate.DateOfBirth;
                

                try 
                {
                    await _context.SaveChangesAsync();
                    return Ok(person);
                }
                catch(Exception)
                {
                    return StatusCode(500, "An error occurred while updating the person.");
                }
            }
            return BadRequest();

        }
    }
}
