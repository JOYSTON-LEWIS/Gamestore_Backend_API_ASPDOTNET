// TS-03:18:16-03:38:39: created
using GameStore.Api.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Dtos;

// TS-03:18:16-03:38:39: created
public static class genresEndpoints
{
    // TS-03:18:16-03:38:39: created
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
        // TS-03:18:16-03:38:39: created group as routebuilder for webapplication
        var group = app.MapGroup("genres");

        // TS-03:18:16-03:38:39: created endpoint for get
        group.MapGet("/", async (GameStoreContext dbContext) =>
            await dbContext.Genres
                           .Select(genre => genre.ToDto())
                            .AsNoTracking()
                            .ToListAsync()
        );

        // TS-03:18:16-03:38:39: returning group value
        return group;
    }
}
