using School.Api.Data;
using School.Api.Endpoints;
using School.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IStudentRepository, InMemoryStudentsRepository>();

var connString = builder.Configuration.GetConnectionString("SchoolContext");
builder.Services.AddSqlServer<SchoolContext>(connString);

var app = builder.Build();

app.MapStudentsEndpoints();

app.Run();
