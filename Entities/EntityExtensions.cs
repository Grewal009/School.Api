using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School.Api.Dtos;

namespace School.Api.Entities
{
    public static class EntityExtensions
    {
        public static StudentDto AsDto(this Student student)
        {
            return new StudentDto(
                student.Id,
                student.Name,
                student.DateOfBirth,
                student.Course,
                student.Address,
                student.Preferences
            );
        }
    }
}