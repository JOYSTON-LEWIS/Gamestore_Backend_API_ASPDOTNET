// TS-01:44:41-01:57:53: 
using Microsoft.EntityFrameworkCore;

// TS-01:44:41-01:57:53: 
namespace GameStore.Api.Dtos;

// TS-01:44:41-01:57:53: inherit from Db Context. Its an object that represents a session with the database used to query and save instances of your entities with the database. Its a combination of Repository or Unit of Work
// TS-01:44:41-01:57:53: to properly construct the dbcontext, we need to receive here the options and send over these options to the base constructor. It will provide all the details of how to connect to the actual database
public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    // TS-01:44:41-01:57:53: declare prop of type Dbset of actual entity "Game", name it Games
    // TS-01:44:41-01:57:53: DbSet is an object to query and save instances in this case of games
    // TS-01:44:41-01:57:53: any LINQ queries against Dbset of type game will be translated into queries against the data
    // TS-01:44:41-01:57:53: to provide initial value we can define it as follows
    public DbSet<Game> Games => Set<Game>();

    // TS-01:44:41-01:57:53: 
    public DbSet<Genre> Genres => Set<Genre>();

    // TS-02:02:40-02:20:57: this method executes as soon as migration is completed
    // TS-02:02:40-02:20:57: don't do this for complex data operations
    // TS-02:02:40-02:20:57: 
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // TS-02:02:40-02:20:57: all 5 of these will be created during migration
        // TS-02:02:40-02:20:57: but we need to add these to migration for dotnet to know it has to run this
        modelBuilder.Entity<Genre>().HasData(
            new {Id = 1, Name = "Fighting"},
            new {Id = 2, Name = "RolePlaying"},
            new {Id = 3, Name = "Sports"},
            new {Id = 4, Name = "Racing"},
            new {Id = 5, Name = "Kids and Family"}
        );
    }

}
