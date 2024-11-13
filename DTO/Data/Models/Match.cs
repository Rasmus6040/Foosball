namespace DTO.Data.Models;

public class Match
{
    public const string GetMatches = "/matches";
    public int Id { get; init; }
    public required Team TeamA { get; init; }
    public required Team TeamB { get; init; }
    public bool Ranked { get; init; }
    public long Date { get; init; } = DateTimeOffset.Now.ToUnixTimeSeconds();
}