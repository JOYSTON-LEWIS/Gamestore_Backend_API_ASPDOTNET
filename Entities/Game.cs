// TS-01:44:41-01:57:53: 
namespace GameStore.Api.Dtos;

// TS-01:44:41-01:57:53: 
public class Game
{
    // TS-01:44:41-01:57:53: 
    public int Id { get; set; }

    // TS-01:44:41-01:57:53:
    public required string Name { get; set; }

    // TS-01:44:41-01:57:53:
    public int GenreId { get; set; }

    // TS-01:44:41-01:57:53: if we provide Genre accept it otherwise null is fine, we would provide GenreId
    public Genre ? Genre { get; set; }

    // TS-01:44:41-01:57:53: 
    public decimal Price { get; set; }

    // TS-01:44:41-01:57:53: 
    public DateOnly ReleaseDate { get; set; }
}
