namespace DTO.Data;

public class Player
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public int Rating { get; init; } = 1200;
}