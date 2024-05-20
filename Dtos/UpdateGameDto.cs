// TS-01:28:29-01:39:49: 
using System.ComponentModel.DataAnnotations;

// TS-46:54-01:20:22: 
namespace GameStore.Api.Dtos;

// TS-46:54-01:20:22: 
public record class UpdateGameDto( 
    // TS-01:28:29-01:39:49: Define constraints and or validations in separate [][]
    [Required][StringLength(50)]string Name, 
    // TS-01:28:29-01:39:49: added constraints and or validations
    // TS-02:56:05-03:18:16: [Required][StringLength(20)]string Genre, 
    // TS-02:56:05-03:18:16: adding GenreId instead of Genre String Name
    int GenreId,
    // TS-01:28:29-01:39:49: added constraints and or validations
    // TS-01:28:29-01:39:49: Please Note in video Required was not added for the following, only range was added.
    [Required][Range(1,100)]decimal Price, 
    // TS-01:28:29-01:39:49: Please Note in video Required was not added for the following.
    [Required]DateOnly ReleaseDate
);
