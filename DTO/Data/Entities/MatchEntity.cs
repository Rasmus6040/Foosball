using System.ComponentModel.DataAnnotations;

namespace DTO.Data.Entities;

public class MatchEntity
{
    [Key]
    public int Id { get; set; }
    public int TeamAScore { get; set; }
    public int TeamBScore { get; set; }
    public bool Ranked { get; set; }
    public int EloChange { get; set; }
    public long Date { get; set; } = DateTimeOffset.Now.ToUnixTimeSeconds();

    public virtual ICollection<PlayerMatchEntity> PlayerMatches { get; set; } = [];
}