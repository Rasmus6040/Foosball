using Microsoft.AspNetCore.Components;
using DTO.Data;

namespace FrontEnd.Components;

public partial class MatchCard : ComponentBase
{
    [Parameter] public Match Match { get; set; } = default!;
}