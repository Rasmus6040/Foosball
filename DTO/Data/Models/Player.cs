namespace DTO.Data.Models;

public class Player
{
    public const string GetPlayers = "/players";
    public int Id { get; init; }
    public required string Name { get; init; }
    public int Rating { get; init; } = 1200;
}