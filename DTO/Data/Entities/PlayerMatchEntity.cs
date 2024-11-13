using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DTO.Data.Entities;

public class PlayerMatchEntity
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("PlayerEntity")]
    public int PlayerId { get; set; }
    [ForeignKey("MatchEntity")]
    public int MatchId { get; set; }
    public int Team { get; set; }
    
    public MatchEntity MatchEntity { get; set; } = null!;
    public PlayerEntity PlayerEntity { get; set; } = null!;
}