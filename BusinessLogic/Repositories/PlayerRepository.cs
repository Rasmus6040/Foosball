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
            Rating = player.Rating
        };
        await context.Players.AddAsync(playerEntity);
        await context.SaveChangesAsync();
    }
}