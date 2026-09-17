using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
