using BusinessLogic.Data.Contexts;
using BusinessLogic.Repositories;
using DTO.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Controllers;

public class PlayerController(IServiceProvider serviceProvider, EloSystemContext context) : ODataController
{
    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(context.Players.AsNoTracking());
    }
    
    [HttpPost(Player.GetPlayers)]
    public async Task<IActionResult> AddPlayer(Player player)
    {
        using var serviceScope = serviceProvider.CreateScope();
        var playerRepository = serviceScope.ServiceProvider.GetRequiredService<PlayerRepository>();
        await playerRepository.AddAsync(player);
        return Ok();
    }
}