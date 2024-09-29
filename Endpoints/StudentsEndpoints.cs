using Microsoft.AspNetCore.DataProtection.Repositories;
using School.Api.Entities;
using School.Api.Repositories;

namespace School.Api.Endpoints;

public static class StudentsEndpoints
{

    static List<Student> students = new List<Student>(){
    new Student(){Id=1,Name="Per",DateOfBirth=new DateOnly(1995,10,15),Course="Web Development",Address="0500 Oslo"},
    new Student(){Id=2,Name="Peter",DateOfBirth=new DateOnly(1996,1,1),Course="Frontend Development",Address="0520 Oslo"},
    new Student(){Id=3,Name="Pål",DateOfBirth=new DateOnly(1997,8,25),Course="Web Development",Address="0506 Oslo"},
    };
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

            repository.Update(updatedStudent);

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