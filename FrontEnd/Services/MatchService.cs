using FrontEnd.Components.Pages;
using FrontEnd.Interfaces;

namespace FrontEnd.Services;

public class MatchService : IMatchService
{
    public Task<DTO.Data.OData<Match>> GetLatestMatches()
    {
        throw new NotImplementedException();
    }
}