
using A1.Models.Dtos;

namespace A1.Models.Mappers
{
    public static class SubjectMappers
    {
        public static SubjectDto ToSubjectDto(this Subject subject)
        {
            return new SubjectDto
            {
                Id = subject.Id,
                Name = subject.Name,
                Credits = subject.Credits,
                Code = subject.Code,
                TeacherId = subject.TeacherId
            };
        }

        public static Subject ToSubjectFromRequestDto(
            this SubjectRequestDto subjectRequestDto)
        {
            return new Subject
            {
                Name = subjectRequestDto.Name,
                Credits = subjectRequestDto.Credits,
                Code = subjectRequestDto.Code,
                TeacherId = subjectRequestDto.TeacherId
            };
        }

        public static void UpdateSubjectFromRequestDto(
            this Subject subject,
            SubjectRequestDto subjectRequestDto)
        {
            subject.Name = subjectRequestDto.Name;
            subject.Credits = subjectRequestDto.Credits;
            subject.Code = subjectRequestDto.Code;
            subject.TeacherId = subjectRequestDto.TeacherId;
        }
    }
}
