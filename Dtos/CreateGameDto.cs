// TS-46:54-01:20:22: 
using System.ComponentModel.DataAnnotations;

// TS-46:54-01:20:22: 
namespace GameStore.Api.Dtos;

// TS-01:28:29-01:39:49: These constraint wont be enough, further configuration would be required
// TS-01:28:29-01:39:49: which is explained in the document and implemented in the GameEndpoints.cs

// TS-46:54-01:20:22: clients will not provide the id, server will, rest is same as GameDto
public record class CreateGameDto( 
    // TS-01:28:29-01:39:49: Define constraints and or validations in separate [][]
    [Required][StringLength(50)]string Name, 
    // TS-01:28:29-01:39:49: added constraints and or validations
    // TS-02:38:46-02:49:56: replace genre to Genre ID
    // TS-02:38:46-02:49:56: [Required][StringLength(20)]string Genre, 
    int GenreId,
    // TS-01:28:29-01:39:49: added constraints and or validations
    // TS-01:28:29-01:39:49: Please Note in video Required was not added for the following, only range was added.
    [Required][Range(1,100)]decimal Price, 
    // TS-01:28:29-01:39:49: Please Note in video Required was not added for the following.
    [Required]DateOnly ReleaseDate
);
