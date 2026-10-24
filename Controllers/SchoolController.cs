using A1.data;
using A1.Models.Dtos;
using A1.Models.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SchoolController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchoolAsync()
        {
            var schools = await _context.Schools
                .Select(s => s.ToSchoolDto()).ToListAsync();
            return Ok(schools);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var school = await _context.Schools
                 .Where(s => s.Id == id)
                 .Select(s => s.ToSchoolDto())
                 .FirstOrDefaultAsync();

            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewSchool([FromBody]SchoolRequestDto schoolRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }
            var school = schoolRequestDto.ToSchoolFromRequestDto();
            await _context.Schools.AddAsync(school);

            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetByIdAsync),
                new { id = school.Id },
                school.ToSchoolDto()
            );
        }


        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateStock(int id, [FromBody] SchoolRequestDto schoolRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var school = await _context.Schools.FindAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            school.UpdateSchoolFromRequestDto(schoolRequestDto);

            await _context.SaveChangesAsync();

            return Ok(school.ToSchoolDto());
        }




        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            var school = await _context.Schools.FindAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            _context.Schools.Remove(school);

            await _context.SaveChangesAsync();

            return NoContent();
        }


    }

}
