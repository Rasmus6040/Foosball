using FrontEnd.Interfaces;
using FrontEnd1.Components.Pages;

namespace FrontEnd1.Services;

public class MatchService : IMatchService
{
    public Task<DTO.Data.OData<Match>> GetLatestMatches()
    {
        throw new NotImplementedException();
    }
}