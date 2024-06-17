using Microsoft.EntityFrameworkCore;

namespace first_project.Data;

public static class DataExtensions
{
    public static async Task MigrateDbAsync(this WebApplication app){
        using var scope = app.Services.CreateScope();
        var dbcontext = scope.ServiceProvider.GetRequiredService<RecordStoreContext>();
        await dbcontext.Database.MigrateAsync(); 
    }
}
