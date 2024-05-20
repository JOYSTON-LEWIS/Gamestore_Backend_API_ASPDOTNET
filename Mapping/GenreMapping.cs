// TS-03:18:16-03:38:39: created
using GameStore.Api.Dtos;

// TS-03:18:16-03:38:39: created
namespace GameStore.Api.Mapping;

// TS-03:18:16-03:38:39: created extension class
public static class GenreMapping
{
    // TS-03:18:16-03:38:39: created extension class of Genre Type
    public static GenreDto ToDto(this Genre genre)
    {
        // TS-03:18:16-03:38:39: returning Genre with Id and name provided
        return new GenreDto(genre.Id, genre.Name);
    }
}
