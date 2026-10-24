
using A1.data;
using A1.Models.Dtos;
using A1.Models.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SubjectController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Subject
        [HttpGet]
        public async Task<IActionResult> GetAllSubjectsAsync()
        {
            var subjects = await _context.Subjects
                .Select(s => s.ToSubjectDto())
                .ToListAsync();

            return Ok(subjects);
        }

        // GET: api/Subject/1
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetSubjectByIdAsync(int id)
        {
            var subject = await _context.Subjects
                .Where(s => s.Id == id)
                .Select(s => s.ToSubjectDto())
                .FirstOrDefaultAsync();

            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        // POST: api/Subject
        [HttpPost]
        public async Task<IActionResult> AddNewSubject(
            [FromBody] SubjectRequestDto subjectRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacherExists = await _context.Teachers
                .AnyAsync(t => t.Id == subjectRequestDto.TeacherId);

            if (!teacherExists)
            {
                return BadRequest("TeacherId does not exist.");
            }

            var subject =
                subjectRequestDto.ToSubjectFromRequestDto();

            await _context.Subjects.AddAsync(subject);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetSubjectByIdAsync),
                new { id = subject.Id },
                subject.ToSubjectDto());
        }

        // PUT: api/Subject/1
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateSubject(
            int id,
            [FromBody] SubjectRequestDto subjectRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var subject = await _context.Subjects.FindAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            var teacherExists = await _context.Teachers
                .AnyAsync(t => t.Id == subjectRequestDto.TeacherId);

            if (!teacherExists)
            {
                return BadRequest("TeacherId does not exist.");
            }

            subject.UpdateSubjectFromRequestDto(subjectRequestDto);

            await _context.SaveChangesAsync();

            return Ok(subject.ToSubjectDto());
        }

        // DELETE: api/Subject/1
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteSubject(int id)
        {
            var subject = await _context.Subjects.FindAsync(id);

            if (subject == null)
            {
                return NotFound();
            }

            _context.Subjects.Remove(subject);

            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
