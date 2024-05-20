// TS-01:44:41-01:57:53: 
namespace GameStore.Api.Dtos;

// TS-01:44:41-01:57:53: 
public class Genre
{
    // TS-01:44:41-01:57:53: 
    public int Id { get; set; }

    // TS-01:44:41-01:57:53: Non-nullable property 'Name' must contain a non-null value when exiting constructor. 
    // TS-01:44:41-01:57:53: Consider declaring the property as nullable.(CS8618)
    // TS-01:44:41-01:57:53: Solution 1: public string Name { get; set; } = string.Empty; // chances of returning null
    // TS-01:44:41-01:57:53: Solution 2: public string ? Name { get; set; } // chances of returning null
    // TS-01:44:41-01:57:53: Solution 3: public required string Name { get; set; } // value is required, no chance of null
    public required string Name { get; set; }

}
