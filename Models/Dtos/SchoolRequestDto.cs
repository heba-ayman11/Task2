using System.ComponentModel.DataAnnotations;

namespace A1.Models.Dtos
{
    public class SchoolRequestDto
    {
        [Required]
        [MaxLength(100 , ErrorMessage ="Name Must Be At Most 100 Char")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(200 , ErrorMessage = "Address Must Be At Most 200 Char")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [MaxLength(100 , ErrorMessage = "City Must Be At Most 100 Char")]
        public string City { get; set; } = string.Empty;
    }
}
