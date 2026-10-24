
namespace A1.Models.Dtos
{
    public class TeacherDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public int SchoolId { get; set; }
    }
}
