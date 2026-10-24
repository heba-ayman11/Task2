using System.ComponentModel.DataAnnotations;

namespace A1.Models.Dtos
{
    public class StudentRequestDto
    {
        [Required]
        [MaxLength(100 , ErrorMessage = "Student Name Must Be At Most 100 Char ")]
        public string Name { get; set; } = string.Empty;

        [Range(1, 30 , ErrorMessage = "Age Must Be Between 1 and 30")]
        public int Age { get; set; }

        [Required]
        [MaxLength(50 , ErrorMessage = "Grade Level Must Be At Most 50 Char")]
        public string GradeLevel { get; set; } = string.Empty;

        [Required]
        [Range(1, int.MaxValue)]
        public int SchoolId { get; set; }
        
    }
}
