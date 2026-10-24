using A1.Models.Dtos;
using A1.Models;

namespace A1.Models.Mappers
{
    public static class SchoolMappers
    {
        public static SchoolDto ToSchoolDto(this School school)
        {
            return new SchoolDto
            {
                Id = school.Id,
                Name = school.Name,
                Address=school.Address,
                City = school.City
                
            };
        }

        public static School ToSchoolFromRequestDto(
         this SchoolRequestDto schoolRequestDto)
        {
            return new School
            {
                Name = schoolRequestDto.Name,
                Address = schoolRequestDto.Address,
                City = schoolRequestDto.City
            };
        }


        public static void UpdateSchoolFromRequestDto(
    this School school,
    SchoolRequestDto schoolRequestDto)
        {
            school.Name = schoolRequestDto.Name;
            school.Address = schoolRequestDto.Address;
            school.City = schoolRequestDto.City;
        }
    }
}
