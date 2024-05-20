// TS-01:20:22-01:25:46: 
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Dtos;

// TS-01:20:22-01:25:46: we can extend this class to use its properties within out classes
// TS-01:20:22-01:25:46: migrated List from Program.cs to GameEndpoint.cs
// TS-01:20:22-01:25:46: to make an extension class static declaration is necessary
// TS-01:20:22-01:25:46: as we wont be modifying the list, we decalre it as readonly
// TS-01:20:22-01:25:46: as the parent class is statis, its inner declarations also need to be static
// TS-01:20:22-01:25:46: this is added to make it into an extension method, this will show up like a new method of this class
// TS-01:20:22-01:25:46: copy paste all endpoints here
public static class GameEndpoints
{
    // TS-02:56:05-03:18:16: updated the namespace of GameDto
    // TS-02:56:05-03:18:16: private static readonly List<GameSummaryDto> games = [
    // TS-02:56:05-03:18:16:     new(1,"Street Fighter II","Fighting", 19.99M, new DateOnly(1992,7,15)),
    // TS-02:56:05-03:18:16:     new(2,"Final Fantasy XIV","Roleplaying", 59.99M, new DateOnly(2010,9,30)),
    // TS-02:56:05-03:18:16:     new(3,"FIFA 23","Sports", 69.99M, new DateOnly(2022,9,27)),
    // TS-02:56:05-03:18:16: ];

    // TS-01:25:46-01:28:29: IMPLEMENTATION OF ROUTE GROUPS STEPS:-
    // TS-01:25:46-01:28:29: We can define groups for common endpoints like for instance we see games games called alot of times
    // TS-01:25:46-01:28:29: once the group is created using MapGroup Function we need to replace all instances of app.get/post/put/delete
    // TS-01:25:46-01:28:29: to group.get/post/put/delete. also we need to return this group instead of the final return app
    // TS-01:25:46-01:28:29: but when we do this, it throws an error that it requires a RouteGroupBuilder and not WebApplication so update the class type
    // TS-01:25:46-01:28:29: benefit of doing group routing is we dont have to reprint the group's name in our classfile
    // TS-01:25:46-01:28:29: replace "games" with / for the basic route and remove games word in other routes with additional path like "games/{id}" will become "/{id}"
    // TS-01:25:46-01:28:29: changed from WebApplication to RouteGroupBuilder
    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        // TS-01:25:46-01:28:29: 
        var group = app.MapGroup("games")
        // TS-01:28:29-01:39:49: added validations to all endpoints using dtos with the help of grouped routes
        .WithParameterValidation();

        // TS-46:54-01:20:22: Constant for GetGame Endpoint, replace it in the code below
        const string GetGameEndpointName = "GetGame";

        // TS-46:54-01:20:22: in 19.99M, the M denotes Decismal, D denotes Double
        // TS-01:20:22-01:25:46: migrated from Program.cs to GameEndpoint.cs
        // List<GameDto> games = [
        //     new(1,"Street Fighter II","Fighting", 19.99M, new DateOnly(1992,7,15)),
        //     new(2,"Final Fantasy XIV","Roleplaying", 59.99M, new DateOnly(2010,9,30)),
        //     new(3,"FIFA 23","Sports", 69.99M, new DateOnly(2022,9,27)),
        // ];

        // TS-46:54-01:20:22: path where this endpoint is location inside MapGet
        // TS-46:54-01:20:22: second define the handler
        // TS-46:54-01:20:22: GET /games
        // TS-01:20:22-01:25:46: migrated from Program.cs to GameEndpoint.cs
        // TS-01:25:46-01:28:29: changed from app to group, replaced games with /
        // TS-02:56:05-03:18:16: upgrading to fetch data from database
        // TS-02:56:05-03:18:16: group.MapGet("/", () => games);
        // TS-02:56:05-03:18:16: projecting our database by using select query to retrieve data in Dto format
        // TS-03:18:16-03:38:39: adding async keyword to make asynchronous
        group.MapGet("/", async (GameStoreContext dbContext) => 
            // TS-03:18:16-03:38:39: adding await keyword to make asynchronous
            await dbContext.Games
            // TS-02:56:05-03:18:16: 
            .Include(game => game.Genre)
            .Select(game => game.ToGameSummaryDto())
            // TS-02:56:05-03:18:16: avoids any tracking of the returning entities, this improves the performance of operation
            .AsNoTracking()
            // TS-03:18:16-03:38:39: adding ToListAsync Function keyword to make asynchronous
            .ToListAsync() 
            );

        // TS-46:54-01:20:22: GET /games
        // TS-46:54-01:20:22: bad practices app.MapGet("get-games/{id}"
        // TS-46:54-01:20:22: bad practices app.MapGet("games/games-byid/{id}"
        // TS-46:54-01:20:22: proper: grouping name followed by id, then its a REST API
        // TS-46:54-01:20:22: the WithName builds the header and returns back to client
        // TS-46:54-01:20:22: logic updated to have null check included
        // TS-46:54-01:20:22: with terniary operator Results dot response format is compulsary
        // TS-01:20:22-01:25:46: migrated from Program.cs to GameEndpoint.cs
        // TS-01:25:46-01:28:29: changed from app to group, remove games tag
        // TS-02:56:05-03:18:16: converting from static to the dbContext to query from database by adding dbContext asq dependency injection
        // TS-03:18:16-03:38:39: adding async keyword to make asynchronous
        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            // TS-02:56:05-03:18:16: converting from static to the dbContext to query from database
            // TS-02:56:05-03:18:16: find metod will try to find the game will check the games in memory right now 
            // TS-02:56:05-03:18:16: and if not found it will find it in the database, so its very efficient
            // TS-03:18:16-03:38:39: adding await and FindAsync function keyword instead of Find to make asynchronous
            Game? game = await dbContext.Games.FindAsync(id);
            // TS-02:56:05-03:18:16: GameDto? game = games.Find(games => games.Id == id);

            return
                // TS-02:56:05-03:18:16: instead of returning the game variable lets return the Dto Format 
                game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailsDto());
        })
        .WithName(GetGameEndpointName);

        // TS-46:54-01:20:22: POST /games
        // TS-46:54-01:20:22: Step 1 is the Data
        // TS-46:54-01:20:22: Step 2 is the Addition of Data
        // TS-46:54-01:20:22: Step 3 is the success / failure response while adding the data
        // TS-46:54-01:20:22: In step 3 parameters accepted are name of the route for the enpoint, lets add this in api defined above, then use it here
        // TS-46:54-01:20:22: In step 3 Second Value for the GetGame Route is the id of  the game
        // TS-46:54-01:20:22: In step 3 the third value is the payload that we wish to return at that route
        // TS-46:54-01:20:22: lets define a constant to use to avoid duplication of the strings / endpoints we use
        // TS-01:20:22-01:25:46: migrated from Program.cs to GameEndpoint.cs
        // TS-01:25:46-01:28:29: changed from app to group, replaced games with /
        // TS-02:38:46-02:49:56: added dependency injection dbContext
        // TS-02:38:46-02:49:56: created this function
        // TS-03:18:16-03:38:39: adding async keyword to make asynchronous
        group.MapPost("/", async (CreateGameDto newGame, GameStoreContext dbContext) =>
        {
            // TS-01:28:29-01:39:49: So if we send a request without a name to the Post or Put, it creates a record with null name
            // TS-01:28:29-01:39:49: ideally it should return a Bad Request and not create or update the record
            // TS-01:28:29-01:39:49: so for this we can define a condition for our requests like as shown below
            // TS-01:28:29-01:39:49: but again this is not an ideal way to resolve this as we will end up writing alot of code handling the same
            // TS-01:28:29-01:39:49: so we can define this in our dtos, lets remove or comment this and lets do it the right way
            // if(string.IsNullOrEmpty(newGame.Name))
            // {
            //     return Results.BadRequest("Name is Required");
            // }
            // TS-02:38:46-02:49:56: commented / removed
            // GameDto game = new(
            //     games.Count + 1,
            //     newGame.Name,
            //     newGame.Genre,
            //     newGame.Price,
            //     newGame.ReleaseDate
            // );

            // TS-02:38:46-02:49:56: 
            // TS-02:56:05-02:56:05 code removal and replaced by the following 
            // TS-02:56:05-02:56:05 Game game = new()
            // TS-02:56:05-02:56:05 {
            // TS-02:56:05-02:56:05     Name = newGame.Name,
            // TS-02:56:05-02:56:05     Genre = dbContext.Genres.Find(newGame.GenreId),
            // TS-02:56:05-02:56:05     GenreId = newGame.GenreId,
            // TS-02:56:05-02:56:05     Price = newGame.Price,
            // TS-02:56:05-02:56:05     ReleaseDate = newGame.ReleaseDate
            // TS-02:56:05-02:56:05 };

            // TS-02:56:05-02:56:05 
            Game game = newGame.ToEntity();
            // TS-02:56:05-02:56:05 
            // TS-02:56:05-03:18:16: Entity framework will self populate this GenreId from the tables, 
            // TS-02:56:05-03:18:16: we dont need to populate this and assign the value so lets remove the following
            // TS-02:56:05-03:18:16: game.Genre = dbContext.Genres.Find(newGame.GenreId);
            
            // TS-02:38:46-02:49:56: games.Add(game);
            // TS-02:38:46-02:49:56: 
            dbContext.Games.Add(game);
            // TS-02:38:46-02:49:56: 
            // TS-03:18:16-03:38:39: adding await and SaveChangesAsync function keyword to make asynchronous      
            await dbContext.SaveChangesAsync();
            // TS-01:28:29-01:39:49: 
            // TS-01:28:29-01:39:49: null check handle applied to 
            // TS-01:28:29-01:39:49: get genre name as we were getting an object instead of the genre name earlier
            // TS-02:56:05-02:56:05 GameDto gameDto = new(
            // TS-02:56:05-02:56:05     game.Id,
            // TS-02:56:05-02:56:05     game.Name,
            // TS-02:56:05-02:56:05     game.Genre!.Name,
            // TS-02:56:05-02:56:05     game.Price,
            // TS-02:56:05-02:56:05     game.ReleaseDate
            // TS-02:56:05-02:56:05 );
            // TS-01:28:29-01:39:49: 
            // TS-02:38:46-02:49:56: updated variable name to gameDto
            // TS-02:56:05-02:56:05 ToDto called from extension class
            // TS-02:56:05-03:18:16: Updated the function name from ToDto to updated name of function
            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game.ToGameDetailsDto());
        }
        // TS-01:28:29-01:39:49: added this after importing nuget package MinimalApis.Extensions
        // TS-01:28:29-01:39:49: run and test the program to check if the validations work
        // TS-01:28:29-01:39:49: better practice is to attach this to our group above so that any 
        // TS-01:28:29-01:39:49: of the requests using dtos will use validations, hence commenting here
        )
        // TS-01:28:29-01:39:49: .WithParameterValidation()
        ;

        // TS-46:54-01:20:22: PUT /games
        // TS-46:54-01:20:22: adding a case handle for PUT if the record for the id is not present
        // TS-46:54-01:20:22: you can put a not found or else define logic to create a new record
        // TS-46:54-01:20:22: thats what is mostly followed as a practice online
        // TS-46:54-01:20:22: hence there is not definitive response that is considered correct or a norm
        // TS-46:54-01:20:22: in the case that a put request failure to find a record for the specified ID
        // TS-46:54-01:20:22: this has a chance of breaking, as when we do put request we always provide the ID
        // TS-46:54-01:20:22: and if the ID provided is present in the database, it will throw error that the ID exists
        // TS-46:54-01:20:22: and fail to create the new record, this would have to be handled too
        // TS-01:20:22-01:25:46: migrated from Program.cs to GameEndpoint.cs
        // TS-01:25:46-01:28:29: changed from app to group, remove games tag
        // TS-02:56:05-03:18:16: injecting dbContext using dependency injection and updating in logic
        // TS-03:18:16-03:38:39: adding async keyword to make asynchronous
        group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
        {
            // TS-02:56:05-03:18:16: var index = games.FindIndex(game => game.Id == id);

            // TS-02:56:05-03:18:16: if (index == -1)
            // TS-02:56:05-03:18:16: {
            // TS-02:56:05-03:18:16:     return Results.NotFound();
            // TS-02:56:05-03:18:16: }

            // TS-02:56:05-03:18:16: 
            // TS-03:18:16-03:38:39: adding await and FindAsync Function keyword to make asynchronous
            var existingGame = await dbContext.Games.FindAsync(id);
            // TS-02:56:05-03:18:16: 
            if(existingGame is null)
            {
                return Results.NotFound();
            }
            // TS-02:56:05-03:18:16: updated namespace to GameSummaryDto
            // TS-02:56:05-03:18:16: games[index] = new GameSummaryDto(
            // TS-02:56:05-03:18:16:     id,
            // TS-02:56:05-03:18:16:     updatedGame.Name,
            // TS-02:56:05-03:18:16:     updatedGame.Genre,
            // TS-02:56:05-03:18:16:     updatedGame.Price,
            // TS-02:56:05-03:18:16:     updatedGame.ReleaseDate
            // TS-02:56:05-03:18:16: );

            // TS-02:56:05-03:18:16: 
            dbContext.Entry(existingGame)
            .CurrentValues
            .SetValues(updatedGame.ToEntity(id));

            // TS-02:56:05-03:18:16: created this function
            // TS-03:18:16-03:38:39: adding await and SaveChangesAsync keyword to make asynchronous
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // TS-46:54-01:20:22: DELETE /games/1
        // TS-46:54-01:20:22: the delete logic deletes only if the resource is found
        // TS-46:54-01:20:22: so it does not really matter if we handle this.
        // TS-01:20:22-01:25:46: migrated from Program.cs to GameEndpoint.cs
        // TS-01:25:46-01:28:29: changed from app to group, remove games tag
        // TS-02:56:05-03:18:16: dependency injection for dbContext
        // TS-03:18:16-03:38:39: adding async keyword to make asynchronous
        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            
            // TS-02:56:05-03:18:16: games.RemoveAll(game => game.Id == id);

            // TS-02:56:05-03:18:16: 
            // TS-02:56:05-03:18:16: executedelete is a bulk delete method 
            // TS-02:56:05-03:18:16: and hence handled and optimised for one or more id
            // TS-03:18:16-03:38:39: adding await and ExecuteDeleteAsync Function keyword to make asynchronous
            await dbContext.Games
                .Where(game => game.Id == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        // TS-04:40-27:54: configuration for request pipeline - what happen 
        // TS-04:40-27:54: when request come in and how to handle them
        // TS-46:54-01:20:22: removed the following during this timestamp but I have only commented it
        // TS-01:20:22-01:25:46: migrated from Program.cs to GameEndpoint.cs
        // app.MapGet("/", () => "Hello World!");

        // TS-01:20:22-01:25:46: returning the http back to the program.cs
        // TS-01:25:46-01:28:29: changed from app to group
        return group;
    }
}
