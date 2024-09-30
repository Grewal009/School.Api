using Microsoft.AspNetCore.DataProtection.Repositories;
using School.Api.Entities;
using School.Api.Repositories;

namespace School.Api.Endpoints;

public static class StudentsEndpoints
{
    const string GetStudentByIdEndpoint = "GetGameById";

    public static RouteGroupBuilder MapStudentsEndpoints(this IEndpointRouteBuilder routes)
    {

        var group = routes.MapGroup("/students").WithParameterValidation();

        group.MapGet("/", (IStudentRepository repository) => repository.GetALL());

        group.MapGet("/{id}", (IStudentRepository repository, int id) =>
        {
            var student = repository.GetByID(id);
            if (student == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(student);
        }).WithName(GetStudentByIdEndpoint);

        group.MapPost("/", (IStudentRepository repository, Student student) =>
        {
            repository.Create(student);

            return Results.CreatedAtRoute(GetStudentByIdEndpoint, new { id = student.Id }, student);
        });

        group.MapPut("/{id}", (IStudentRepository repository, int id, Student updatedStudent) =>
        {
            Student? student = repository.GetByID(id);

            if (student == null)
            {
                return Results.NotFound();
            }

            student.Name = updatedStudent.Name;
            student.DateOfBirth = updatedStudent.DateOfBirth;
            student.Course = updatedStudent.Course;
            student.Address = updatedStudent.Address;

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