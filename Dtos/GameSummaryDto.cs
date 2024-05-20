// TS-40:01-46:54: 
namespace GameStore.Api.Dtos;

// TS-40:01-46:54: record are immutable - once properties created cant be changed, 
// TS-40:01-46:54: this is perfect for dtos to transmit data from one source to another without any modifications
// TS-40:01-46:54: records reduce boilerplate code which is associated with class definitions intended for 
// TS-40:01-46:54: data holding like dtos, we can define records in single line code which simplifies code readability
// TS-40:01-46:54: 
// TS-02:56:05-03:18:16: updated the classname to the file and in the code here below
public record class GameSummaryDto(
    int Id, 
    string Name, 
    string Genre, 
    decimal Price, 
    DateOnly ReleaseDate
);
