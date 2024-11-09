using DTO.Data;
using Match = FrontEnd1.Components.Pages.Match;

namespace FrontEnd.Interfaces;

public interface IMatchService
{
    Task<OData<Match>> GetLatestMatches();
}