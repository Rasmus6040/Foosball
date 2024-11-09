using DTO.Data;
using Match = FrontEnd.Components.Pages.Match;

namespace FrontEnd.Interfaces;

public interface IMatchService
{
    Task<OData<Match>> GetLatestMatches();
}