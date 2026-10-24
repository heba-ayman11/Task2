
using A1.data;
using A1.Models.Dtos;
using A1.Models.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Teacher
        [HttpGet]
        public async Task<IActionResult> GetAllTeachersAsync()
        {
            var teachers = await _context.Teachers
                .Select(t => t.ToTeacherDto())
                .ToListAsync();

            return Ok(teachers);
        }

        // GET: api/Teacher/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTeacherByIdAsync(int id)
        {
            var teacher = await _context.Teachers
                .Where(t => t.Id == id)
                .Select(t => t.ToTeacherDto())
                .FirstOrDefaultAsync();

            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        // POST: api/Teacher
        [HttpPost]
        public async Task<IActionResult> AddNewTeacher(
            [FromBody] TeacherRequestDto teacherRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var schoolExists = await _context.Schools
                .AnyAsync(s => s.Id == teacherRequestDto.SchoolId);

            if (!schoolExists)
            {
                return BadRequest("SchoolId does not exist.");
            }

            var teacher =
                teacherRequestDto.ToTeacherFromRequestDto();

            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTeacherByIdAsync),
                new { id = teacher.Id },
                teacher.ToTeacherDto());
        }

        // PUT: api/Teacher/1
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateTeacher(
            int id,
            [FromBody] TeacherRequestDto teacherRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            var schoolExists = await _context.Schools
                .AnyAsync(s => s.Id == teacherRequestDto.SchoolId);

            if (!schoolExists)
            {
                return BadRequest("SchoolId does not exist.");
            }

            teacher.UpdateTeacherFromRequestDto(teacherRequestDto);

            await _context.SaveChangesAsync();

            return Ok(teacher.ToTeacherDto());
        }

        // DELETE: api/Teacher/1
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.FindAsync(id);

            if (teacher == null)
            {
                return NotFound();
            }

            var hasSubjects = await _context.Subjects
                .AnyAsync(s => s.TeacherId == id);

            if (hasSubjects)
            {
                return Conflict(
                    "Cannot delete teacher because subjects are assigned to this teacher.");
            }

            _context.Teachers.Remove(teacher);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
