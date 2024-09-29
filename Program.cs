using School.Api.Endpoints;
using School.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IStudentRepository, InMemoryStudentsRepository>();

var app = builder.Build();

app.MapStudentsEndpoints();

app.Run();
