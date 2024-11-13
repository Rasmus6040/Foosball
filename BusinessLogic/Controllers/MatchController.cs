using BusinessLogic.Data.Contexts;
using BusinessLogic.Repositories;
using DTO.Data.Entities;
using DTO.Data.Models;
using ELOSystem;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BusinessLogic.Controllers;

public class MatchController(IServiceProvider serviceProvider, EloSystemContext context) : ODataController
{
    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(context.Matches.AsNoTracking());
    }
    
    [HttpPost(Match.GetMatches)]
    public async Task<IActionResult> AddMatch(Match match)
    {
        var serviceScope = serviceProvider.CreateScope();
        var matchRepository = serviceScope.ServiceProvider.GetRequiredService<MatchRepository>();
        var playerRepository = serviceScope.ServiceProvider.GetRequiredService<PlayerRepository>();
        var eloCalculator = serviceScope.ServiceProvider.GetRequiredService<EloCalculator>();
        
        try
        {
            Log.Information("Adding match");
            var eloChange = 0;
            if (match.Ranked)
            {
                List<PlayerEntity> teamAPlayers = playerRepository.Get(match.TeamA.PlayerIds);
                List<PlayerEntity> teamBPlayers = playerRepository.Get(match.TeamB.PlayerIds);
                var matchEloChange =
                    eloCalculator.GetRatings(teamAPlayers, teamBPlayers, (match.TeamA.Score, match.TeamB.Score));
                eloChange = matchEloChange.EloChange;
                foreach (var valueTuple in matchEloChange.PlayerIdsAndEloChange)
                {
                    await playerRepository.UpdateEloAsync(valueTuple.Item1, valueTuple.Item2);
                }
            }
            await matchRepository.AddAsync(match, eloChange);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
        return Ok();
    }
}