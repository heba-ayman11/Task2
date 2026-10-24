
using A1.Models.Dtos;

namespace A1.Models.Mappers
{
    public static class TeacherMappers
    {
        // Convert Teacher to TeacherDto
        public static TeacherDto ToTeacherDto(this Teacher teacher)
        {
            return new TeacherDto
            {
                Id = teacher.Id,
                Name = teacher.Name,
                HireDate = teacher.HireDate,
                Salary = teacher.Salary,
                SchoolId = teacher.SchoolId
            };
        }

        // Convert TeacherRequestDto to Teacher
        public static Teacher ToTeacherFromRequestDto(
            this TeacherRequestDto teacherRequestDto)
        {
            return new Teacher
            {
                Name = teacherRequestDto.Name,
                HireDate = teacherRequestDto.HireDate,
                Salary = teacherRequestDto.Salary,
                SchoolId = teacherRequestDto.SchoolId
            };
        }

        // Update existing Teacher
        public static void UpdateTeacherFromRequestDto(
            this Teacher teacher,
            TeacherRequestDto teacherRequestDto)
        {
            teacher.Name = teacherRequestDto.Name;
            teacher.HireDate = teacherRequestDto.HireDate;
            teacher.Salary = teacherRequestDto.Salary;
            teacher.SchoolId = teacherRequestDto.SchoolId;
        }
    }
}
