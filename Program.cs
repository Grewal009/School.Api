using Microsoft.EntityFrameworkCore;
using School.Api.Data;
using School.Api.Endpoints;
using School.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<IStudentRepository, InMemoryStudentsRepository>();

var connString = builder.Configuration.GetConnectionString("SchoolContext");
builder.Services.AddSqlServer<SchoolContext>(connString);

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<SchoolContext>();
    dbContext.Database.Migrate();
}


app.MapStudentsEndpoints();

app.Run();
