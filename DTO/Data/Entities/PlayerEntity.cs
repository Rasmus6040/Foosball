using System.ComponentModel.DataAnnotations;

namespace DTO.Data.Entities;

public class PlayerEntity
{
    [Key]
    public int Id { get; set; }
    public required string DisplayName { get; set; }
    public string Email { get; set; } = string.Empty;
    public double Rating { get; set; } = 1200;
    public string ImageUrl { get; init; } = "https://cdn-icons-png.flaticon.com/512/147/147144.png";
    public long CreatedAt { get; init; } = DateTimeOffset.Now.ToUnixTimeSeconds();

    public virtual ICollection<PlayerMatchEntity> PlayerMatches { get; set; } = [];
}