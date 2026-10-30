using Microsoft.Extensions.Configuration;

namespace GraphAppOnlyTutorial;

public class Settings
{
    public string? ClientId { get; set; }
    public string? ClientSecret { get; set; }
    public string? TenantId { get; set; }

    public static Settings LoadSettings()
    {
        IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .AddUserSecrets<Program>()
            .Build();
        
        return config.GetRequiredSection("settings").Get<Settings>() ??
            throw new Exception("You dun goof'd pal");
    }
}