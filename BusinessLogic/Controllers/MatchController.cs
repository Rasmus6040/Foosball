using BusinessLogic.Data.Contexts;
using BusinessLogic.Repositories;
using DTO.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

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
        await matchRepository.AddAsync(match);
        return Ok();
    }
}