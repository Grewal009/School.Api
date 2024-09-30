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

        group.MapGet("/", async (IStudentRepository repository) => (await repository.GetALLAsync()).Select(student => student.AsDto()));

        group.MapGet("/{id}", async (IStudentRepository repository, int id) =>
        {
            var student = await repository.GetByIDAsync(id);
            if (student == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(student.AsDto());
        }).WithName(GetStudentByIdEndpoint);

        group.MapPost("/", async (IStudentRepository repository, CreateStudentDto studentDto) =>
        {
            Student student = new()
            {
                Name = studentDto.Name,
                DateOfBirth = studentDto.Dob,
                Course = studentDto.Course,
                Address = studentDto.Address,
            };
            await repository.CreateAsync(student);

            return Results.CreatedAtRoute(GetStudentByIdEndpoint, new { id = student.Id }, student.AsDto());
        });

        group.MapPut("/{id}", async (IStudentRepository repository, int id, UpdateStudentDto updatedStudentDto) =>
        {
            Student? student = await repository.GetByIDAsync(id);

            if (student == null)
            {
                return Results.NotFound();
            }

            student.Name = updatedStudentDto.Name;
            student.DateOfBirth = updatedStudentDto.Dob;
            student.Course = updatedStudentDto.Course;
            student.Address = updatedStudentDto.Address;

            await repository.UpdateAsync(student);

            return Results.NoContent();

        });

        group.MapDelete("/{id}", async (IStudentRepository repository, int id) =>
        {
            Student? student = await repository.GetByIDAsync(id);
            if (student == null)
            {
                return Results.NotFound();
            }

            await repository.DeleteAsync(id);
            return Results.NoContent();
        });
        return group;
    }
}