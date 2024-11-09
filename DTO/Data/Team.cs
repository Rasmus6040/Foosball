namespace DTO.Data;

public class Team
{
    public required int Score { get; init; }
    public List<int> PlayerIds { get; init; }
}