using School.Api.Entities;

List<Student> students = new List<Student>(){
    new Student(){Id=1,Name="Per",DateOfBirth=new DateOnly(1995,10,15),Course="Web Development",Address="0500 Oslo"},
    new Student(){Id=2,Name="Peter",DateOfBirth=new DateOnly(1996,1,1),Course="Frontend Development",Address="0520 Oslo"},
    new Student(){Id=3,Name="Pål",DateOfBirth=new DateOnly(1997,8,25),Course="Web Development",Address="0506 Oslo"},
};



var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/students", () => students);

app.Run();
