

using Microsoft.EntityFrameworkCore;

namespace School.Api.Data;

public static class DataExtensions
{
    public static async Task InitializeDb(this IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<SchoolContext>();
        await dbContext.Database.MigrateAsync();
    }


}