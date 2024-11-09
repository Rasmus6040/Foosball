using System.ComponentModel.DataAnnotations;

namespace DTO.Data.Entities;

public class PlayerEntity
{
    [Key]
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Rating { get; set; } = 1200;
    
    public virtual ICollection<PlayerMatchEntity> PlayerMatches { get; set; }
}