using BusinessLogic.Data.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Controllers;

public class PlayerMatchesController(EloSystemContext context) : ODataController
{
    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(context.PlayerMatches.AsNoTracking());
    }
}