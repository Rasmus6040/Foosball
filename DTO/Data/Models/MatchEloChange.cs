namespace DTO.Data.Models;

public class MatchEloChange 
{
    public int EloChange { get; set; }
    public List<(int, int)> PlayerIdsAndEloChange { get; set; } = [];
}