
using System.ComponentModel.DataAnnotations;

namespace A1.Models.Dtos
{
    public class TeacherRequestDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public DateTime HireDate { get; set; }

        [Range(typeof(decimal), "0.01", "1000000000")]
        public decimal Salary { get; set; }

        [Range(1, int.MaxValue)]
        public int SchoolId { get; set; }
    }
}
