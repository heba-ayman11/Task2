using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A1.Models.Dtos
{
    public class StudentDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }
        public string GradeLevel { get; set; } = string.Empty;

        public int SchoolId { get; set; }

    }
}
