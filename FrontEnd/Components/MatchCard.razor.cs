using DTO.Data.Entities;
using Microsoft.AspNetCore.Components;
using DTO.Data.Entities;

namespace FrontEnd.Components;

public partial class MatchCard : ComponentBase
{
    [Parameter] public MatchEntity Match { get; set; } = default!;
}