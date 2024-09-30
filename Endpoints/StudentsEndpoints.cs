using Microsoft.AspNetCore.DataProtection.Repositories;
using School.Api.Dtos;
using School.Api.Entities;
using School.Api.Repositories;

namespace School.Api.Endpoints;

public static class StudentsEndpoints
{
    const string GetStudentByIdEndpoint = "GetGameById";

    public static RouteGroupBuilder MapStudentsEndpoints(this IEndpointRouteBuilder routes)
    {

        var group = routes.MapGroup("/students").WithParameterValidation();

        group.MapGet("/", (IStudentRepository repository) => repository.GetALL().Select(student => student.AsDto()));

        group.MapGet("/{id}", (IStudentRepository repository, int id) =>
        {
            var student = repository.GetByID(id);
            if (student == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(student.AsDto());
        }).WithName(GetStudentByIdEndpoint);

        group.MapPost("/", (IStudentRepository repository, CreateStudentDto studentDto) =>
        {
            Student student = new()
            {
                Name = studentDto.Name,
                DateOfBirth = studentDto.DateOfBirth,
                Course = studentDto.Course,
                Address = studentDto.Address,
            };
            repository.Create(student);

            return Results.CreatedAtRoute(GetStudentByIdEndpoint, new { id = student.Id }, student);
        });

        group.MapPut("/{id}", (IStudentRepository repository, int id, UpdateStudentDto updatedStudentDto) =>
        {
            Student? student = repository.GetByID(id);

            if (student == null)
            {
                return Results.NotFound();
            }

            student.Name = updatedStudentDto.Name;
            student.DateOfBirth = updatedStudentDto.DateOfBirth;
            student.Course = updatedStudentDto.Course;
            student.Address = updatedStudentDto.Address;

            repository.Update(student);

            return Results.NoContent();

        });

        group.MapDelete("/{id}", (IStudentRepository repository, int id) =>
        {
            Student? student = repository.GetByID(id);
            if (student == null)
            {
                return Results.NotFound();
            }

            repository.Delete(id);
            return Results.NoContent();
        });
        return group;
    }
}