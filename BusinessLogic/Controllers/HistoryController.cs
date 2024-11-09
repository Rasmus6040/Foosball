using BusinessLogic.Data.Contexts;
using BusinessLogic.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Controllers;

public class HistoryController(EloSystemContext context) : ODataController
{
    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(context.Matches.AsNoTracking());
    }
}