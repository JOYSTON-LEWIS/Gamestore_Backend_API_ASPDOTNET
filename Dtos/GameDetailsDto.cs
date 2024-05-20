// TS-02:56:05-03:18:16: 
namespace GameStore.Api.Dtos;

// TS-02:56:05-03:18:16: 
public record class GameDetailsDto(
    // TS-02:56:05-03:18:16: 
    int Id,
    // TS-02:56:05-03:18:16: 
    string Name,
    // TS-02:56:05-03:18:16: changing datatype to int instead
    int GenreId,
    // TS-02:56:05-03:18:16: 
    decimal Price,
    // TS-02:56:05-03:18:16: 
    DateOnly ReleaseDate
);
