using School.Api.Entities;

List<Student> students = new List<Student>(){
    new Student(){Id=1,Name="Per",DateOfBirth=new DateOnly(1995,10,15),Course="Web Development",Address="0500 Oslo"},
    new Student(){Id=2,Name="Peter",DateOfBirth=new DateOnly(1996,1,1),Course="Frontend Development",Address="0520 Oslo"},
    new Student(){Id=3,Name="Pål",DateOfBirth=new DateOnly(1997,8,25),Course="Web Development",Address="0506 Oslo"},
};

const string GetStudentByIdEndpoint = "GetGameById";


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var group = app.MapGroup("/students");

group.MapGet("/", () => students);

group.MapGet("/{id}", (int id) =>
{
    var student = students.Find(s => s.Id == id);
    if (student == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(student);
}).WithName(GetStudentByIdEndpoint);

group.MapPost("/", (Student student) =>
{
    student.Id = students.Max(s => s.Id) + 1;
    students.Add(student);

    return Results.CreatedAtRoute(GetStudentByIdEndpoint, new { id = student.Id }, student);
});

group.MapPut("/{id}", (int id, Student updatedStudent) =>
{
    Student? student = students.Find(s => s.Id == id);

    if (student == null)
    {
        return Results.NotFound();
    }
    student.Name = updatedStudent.Name;
    student.DateOfBirth = updatedStudent.DateOfBirth;
    student.Course = updatedStudent.Course;
    student.Address = updatedStudent.Address;

    return Results.NoContent();

});

group.MapDelete("/{id}", (int id) =>
{
    Student? student = students.Find(s => s.Id == id);
    if (student == null)
    {
        return Results.NotFound();
    }

    students.Remove(student);
    return Results.NoContent();
});


app.Run();
