namespace DTO.Data.Models;

public class Player
{
    public const string GetPlayers = "/players";
    public int Id { get; init; }
    public required string Name { get; init; }
    public int Rating { get; init; } = 1200;
    public string ImageUrl { get; init; } = "https://cdn-icons-png.flaticon.com/512/147/147144.png";
    public long CreatedAt { get; init; } = DateTimeOffset.Now.ToUnixTimeSeconds();
}