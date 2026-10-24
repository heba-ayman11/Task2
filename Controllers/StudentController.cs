using A1.data;
using A1.Models;
using A1.Models.Dtos;
using A1.Models.Mappers;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.EntityFrameworkCore;


namespace A1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentsAsync()
        {
            var students = await _context.Students
                .Select(s => s.ToStudentDto()).ToListAsync();
            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students
                .Where(s => s.Id == id)
                .Select(s => s.ToStudentDto())
                .FirstOrDefaultAsync();

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewStudent(
            [FromBody] StudentRequestDto studentRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var schoolExists = await _context.Schools
                .AnyAsync(s => s.Id == studentRequestDto.SchoolId);

            if (!schoolExists)
            {
                return BadRequest("SchoolId does not exist.");
            }

            var student =
                studentRequestDto.ToStudentFromRequestDto();

            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetStudentByIdAsync),
                new { id = student.Id },
                student.ToStudentDto());
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateStudent(
            int id,
            [FromBody] StudentRequestDto studentRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            var schoolExists = await _context.Schools
                .AnyAsync(s => s.Id == studentRequestDto.SchoolId);

            if (!schoolExists)
            {
                return BadRequest("SchoolId does not exist.");
            }

            student.UpdateStudentFromRequestDto(studentRequestDto);

            await _context.SaveChangesAsync();

            return Ok(student.ToStudentDto());
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }




    }
}
