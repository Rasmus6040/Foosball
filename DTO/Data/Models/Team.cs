namespace DTO.Data.Models;

public class Team
{
    public required int Score { get; init; }
    public List<int> PlayerIds { get; init; }
}