using System.ComponentModel.DataAnnotations;

namespace A1.Models.Dtos
{
    public class SubjectRequestDto
    {
        [Required]
        [MaxLength(100 , ErrorMessage ="Student Name Must Be At Most 100 Char")]
        public string Name { get; set; } = string.Empty;

        [Range(1, 10  , ErrorMessage = "Credits Must Be between 1 and 10")]
        public int Credits { get; set; }

        [Required]
        [MaxLength(20  , ErrorMessage = "Code Must Be At Most 20 Char")]
        public string Code { get; set; } = string.Empty;

        [Range(1, int.MaxValue  , ErrorMessage = "teacher Id Must Be Greater Then 1")]
        public int TeacherId { get; set; }
    }
}
