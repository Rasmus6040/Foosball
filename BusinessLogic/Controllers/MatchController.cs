using BusinessLogic.Data.Contexts;
using BusinessLogic.Data.Entities;
using BusinessLogic.Repositories;
using DTO.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Controllers;

[ApiController]
[Route("[controller]")]
public class MatchController(EloSystemContext context, IServiceProvider serviceProvider) : ControllerBase
{
    
    [HttpGet(Match.GetMatches)]
    public IActionResult GetMatches()
    {
        return Ok(context.Matches.AsNoTracking());
    }
    
    [HttpPost(Match.GetMatches)]
    public async Task<IActionResult> AddMatch(Match match)
    {
        var serviceScope = serviceProvider.CreateScope();
        var matchRepository = serviceScope.ServiceProvider.GetRequiredService<MatchRepository>();
        await matchRepository.AddAsync(match);
        return Ok();
    }
    
    [HttpGet("/players")]
    public IActionResult GetPlayers()
    {
        return Ok(context.Players.AsNoTracking());
    }
    
    [HttpPost("/players")]
    public async Task<IActionResult> AddPlayer(Player player)
    {
        var playerEntity = new PlayerEntity()
        {
            Name = player.Name, 
            Rating = player.Rating
        };
        await context.Players.AddAsync(playerEntity);
        await context.SaveChangesAsync();
        return Ok();
    }
}