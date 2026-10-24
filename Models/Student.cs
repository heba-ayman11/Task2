using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace A1.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public int Age { get; set; }
        public string GradeLevel { get; set; } = string.Empty;

        public School School { get; set; }
        [ForeignKey(nameof(SchoolId))]
        public int SchoolId { get; set; }
        public Collection<Subject> Subjects { get; set; } = new Collection<Subject>();

    }
}
