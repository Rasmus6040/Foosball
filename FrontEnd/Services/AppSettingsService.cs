namespace FrontEnd.Services;

public class AppSettingsService
{
    private readonly IConfiguration _configuration;

    public AppSettingsService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetODataUrl()
    {
        return _configuration["ConnectionStrings:ODataUrl"]!;
    }
}