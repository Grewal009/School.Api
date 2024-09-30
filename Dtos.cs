using System.ComponentModel.DataAnnotations;

namespace School.Api.Dtos;

public record StudentDto(
    int Id,
    string Name,
    DateOnly DateOfBirth,
    string Course,
    string Address
);

public record CreateStudentDto(
    [Required][StringLength(50)] string Name,
    DateOnly DateOfBirth,
    [Required][StringLength(50)] string Course,
    [Required][StringLength(100)] string Address
);

public record UpdateStudentDto(
    [Required][StringLength(50)] string Name,
    DateOnly DateOfBirth,
    [Required][StringLength(50)] string Course,
    [Required][StringLength(100)] string Address
);