using School.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace School.Api.Data;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }

    public DbSet<Student> Students => Set<Student>();

}