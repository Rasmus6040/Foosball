using BusinessLogic.Data.Contexts;
using BusinessLogic.Repositories;
using DTO.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Serilog;

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
        try
        {
            Log.Information("Adding player with name: {Name}", player.Name);
            await playerRepository.AddAsync(player);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        return Ok();
    }
    
    public async Task<IActionResult> UpdateName(int id, string name)
    {
        using var serviceScope = serviceProvider.CreateScope();
        var playerRepository = serviceScope.ServiceProvider.GetRequiredService<PlayerRepository>();
        try
        {
            Log.Information("Updating player with id: {Id} to name: {Name}", id, name);
            await playerRepository.UpdateNameAsync(id, name);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        return Ok();
    }
}