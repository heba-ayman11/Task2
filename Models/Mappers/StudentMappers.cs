using A1.Models.Dtos;
using A1.Models;


namespace A1.Models.Mappers
{
    public static class StudentMappers
    {
        public static StudentDto ToStudentDto(this Student student)
        {
            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                GradeLevel = student.GradeLevel,
                SchoolId = student.SchoolId
            };
        }

        public static Student ToStudentFromRequestDto(
          this StudentRequestDto studentRequestDto)
        {
            return new Student
            {
                Name = studentRequestDto.Name,
                Age = studentRequestDto.Age,
                GradeLevel = studentRequestDto.GradeLevel,
                SchoolId = studentRequestDto.SchoolId
            };
        }

        public static void UpdateStudentFromRequestDto(
           this Student student,
           StudentRequestDto studentRequestDto)
        {
            student.Name = studentRequestDto.Name;
            student.Age = studentRequestDto.Age;
            student.GradeLevel = studentRequestDto.GradeLevel;
            student.SchoolId = studentRequestDto.SchoolId;
        }
    }

}

