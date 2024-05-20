// TS-02:02:40-02:20:57: 
using GameStore.Api.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Data;

// TS-02:02:40-02:20:57: 
public static class DataExtensions
{
    // TS-02:02:40-02:20:57: created this function
    // TS-03:18:16-03:38:39: converting this extension to an async task with async function MigrateDbAsync
    public static async Task MigrateDbAsync(this WebApplication app)
    {
        // TS-02:02:40-02:20:57: instance of some services registered in application
        // TS-02:02:40-02:20:57: the line builder.Services.AddSqlite<GameStoreContext>(connString);
        // TS-02:02:40-02:20:57: in the program.cs is going ot register our gamestore context into the service container
        // TS-02:02:40-02:20:57: 
        using var scope = app.Services.CreateScope();
        // TS-02:02:40-02:20:57: explained later
        var dbContext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();  
        // TS-02:02:40-02:20:57: explained later
        // TS-03:18:16-03:38:39: need to make this function asynchronous
        // TS-03:18:16-03:38:39: so lets convert this function into a async task
        // TS-03:18:16-03:38:39: and then await and MigrateAsync Function keyword added to make it asynchronous
        await dbContext.Database.MigrateAsync();
    }
}
