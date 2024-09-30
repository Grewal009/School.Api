using Microsoft.EntityFrameworkCore;
using School.Api.Data;
using School.Api.Endpoints;
using School.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IStudentRepository, EntityFrameworkStudentsRepository>();

var connString = builder.Configuration.GetConnectionString("SchoolContext");
builder.Services.AddSqlServer<SchoolContext>(connString);

var app = builder.Build();

await app.Services.InitializeDb();


app.MapStudentsEndpoints();

app.Run();
