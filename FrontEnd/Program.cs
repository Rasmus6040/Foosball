using FrontEnd.Components;
using Serilog;
using Syncfusion.Blazor;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NDaF5cWWtCf1JpRGVGfV5ycEVCal9VTnJbUiweQnxTdEFiWH9XcHBWQmRYVEF2Vw==");
// 

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();

WebApplication app = builder.Build();
Log.Logger = new LoggerConfiguration().Enrich.FromLogContext()
    .Enrich.WithProperty("ApplicationName", "frontend")
    .WriteTo.Console(outputTemplate: "{Timestamp:HH:mm:ss} [{Level}] {ApplicationName} {UserId} {Message:lj}{NewLine}{Exception}")
    .WriteTo.File("logs/frontend-.txt", rollingInterval: RollingInterval.Hour, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level}] [{ApplicationName}] [{UserId}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();