// TS-02:56:05-02:56:05 
using GameStore.Api.Dtos;

// TS-02:56:05-02:56:05 
namespace GameStore.Api.Mapping;

// TS-02:56:05-02:56:05 Creating a static class to refactor the Create Game function below in endpoints
// TS-02:56:05-02:56:05 group.MapPost("/", (CreateGameDto newGame, GameStoreContext dbContext) =>

public static class GameMapping
{
    // TS-02:56:05-02:56:05 
    public static Game ToEntity(this CreateGameDto game)
    {
        // TS-02:56:05-02:56:05 
        return new Game()
        {
            // TS-02:56:05-02:56:05 
            Name = game.Name,
            // TS-02:56:05-02:56:05 we will get the Genre in the Dto itself so lets remove this from here
            // TS-02:56:05-02:56:05 we only focus on the Dto values and make them static here
            // TS-02:56:05-02:56:05 Genre = dbContext.Genres.Find(newGame.GenreId),
            GenreId = game.GenreId,
            // TS-02:56:05-02:56:05 
            Price = game.Price,
            // TS-02:56:05-02:56:05 
            ReleaseDate = game.ReleaseDate
        };

    }

    // TS-02:56:05-03:18:16: 
    public static Game ToEntity(this UpdateGameDto game, int id)
    {
        // TS-02:56:05-03:18:16: 
        return new Game()
        {
            // TS-02:56:05-03:18:16: Id is needed to know which 
            // TS-02:56:05-03:18:16: game to update when it would be sent from frontend
            Id = id,
            // TS-02:56:05-02:56:05 
            Name = game.Name,
            // TS-02:56:05-03:18:16: 
            GenreId = game.GenreId,
            // TS-02:56:05-03:18:16: 
            Price = game.Price,
            // TS-02:56:05-03:18:16: 
            ReleaseDate = game.ReleaseDate
        };

    }

    // TS-02:56:05-02:56:05 
    // TS-02:56:05-03:18:16: namespace updated, function name updated
    public static GameSummaryDto ToGameSummaryDto(this Game game)
    {
        // TS-02:56:05-02:56:05 
        return new(
                // TS-02:56:05-02:56:05 
                game.Id,
                // TS-02:56:05-02:56:05 
                game.Name,
                // TS-02:56:05-02:56:05 
                game.Genre!.Name,
                // TS-02:56:05-02:56:05 
                game.Price,
                // TS-02:56:05-02:56:05 
                game.ReleaseDate
            );
    }

    // TS-02:56:05-03:18:16: 
    public static GameDetailsDto ToGameDetailsDto(this Game game)
    {
        // TS-02:56:05-03:18:16: 
        return new(
                // TS-02:56:05-03:18:16: 
                game.Id,
                // TS-02:56:05-03:18:16: 
                game.Name,
                // TS-02:56:05-03:18:16: capturing the genre Id instead of the name
                game.GenreId,
                // TS-02:56:05-03:18:16: 
                game.Price,
                // TS-02:56:05-03:18:16: 
                game.ReleaseDate
            );
    }
}
