
namespace A1.Models.Dtos
{
    public class SubjectDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Credits { get; set; }

        public string Code { get; set; } = string.Empty;

        public int TeacherId { get; set; }
    }
}
