using DTO.Data.Entities;
using DTO.Data.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace FrontEnd.Components;

public partial class PlayerSearchDialog : ComponentBase
{
    [Parameter]
    public bool BlueTeam { get; set; }

    [Parameter]
    public bool Visible { get; set; }

    [Parameter]
    public EventCallback<bool> VisibleChanged { get; set; }
    
    [Parameter]
    public EventCallback<PlayerEntity> PlayerSubmitted { get; set; }

    private async Task CloseDialog()
    {
        Visible = false;
        await VisibleChanged.InvokeAsync(Visible);
    }

    private PlayerEntity? _selectedPlayer;
    private void Enter(KeyboardEventArgs e)
    {
        if (_selectedPlayer is null) return; // TODO: Show tooltip, "Please select a player"
        if (e.Code is not ("Enter" or "NumpadEnter")) return;
        PlayerSubmitted.InvokeAsync(_selectedPlayer);
        _ = CloseDialog();
    }
}