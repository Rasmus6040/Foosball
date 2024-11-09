using BusinessLogic.Data.Contexts;
using BusinessLogic.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace BusinessLogic.Controllers;

public class HistoryController(EloSystemContext context) : ODataController
{
    [EnableQuery]
    public IActionResult Get()
    {
        Log.Information("Getting history");
        return Ok(context.Matches.AsNoTracking());
    }
}