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

            return Ok(persons);
        }

    }
}
