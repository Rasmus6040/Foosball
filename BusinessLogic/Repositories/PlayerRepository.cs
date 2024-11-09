using BusinessLogic.Data.Contexts;
using DTO.Data.Entities;
using DTO.Data.Models;

namespace BusinessLogic.Repositories;

public class PlayerRepository(EloSystemContext context)
{
    public async Task AddAsync(Player player)
    {
        var playerEntity = new PlayerEntity()
        {
            Name = player.Name,
            Rating = player.Rating,
            CreatedAt = player.CreatedAt,
            ImageUrl = player.ImageUrl
        };
        await context.Players.AddAsync(playerEntity);
        await context.SaveChangesAsync();
    }
    
    public async Task UpdateEloAsync(int id, int rating)
    {
        var playerEntity = await context.Players.FindAsync(id);
        if (playerEntity == null)
        {
            throw new ArgumentException("Player not found");
        }
        
        playerEntity.Rating += rating;
        await context.SaveChangesAsync();
    }

    public List<PlayerEntity> Get(List<int> teamAPlayerIds)
    {
        return context.Players.Where(p => teamAPlayerIds.Contains(p.Id)).ToList();
    }

    public async Task UpdateNameAsync(int id, string name)
    {
        var playerEntity = await context.Players.FindAsync(id);
        if (playerEntity == null)
        {
            throw new ArgumentException("Player not found");
        }
        
        playerEntity.Name = name;
        await context.SaveChangesAsync();
    }
}