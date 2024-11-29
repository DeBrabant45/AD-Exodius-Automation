using Mock.SwagLabs.Configurations.Models;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mock.SwagLabs.Configurations;

public class AppsettingConfigurationReader
{
    public static ApplicationSettings Read()
    {
        var configurationFile = 
            File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/appsettings.json");

        var jsonSettings = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };

        jsonSettings.Converters.Add(new JsonStringEnumConverter());

        var dashboardSettings = JsonSerializer.Deserialize<ApplicationSettings>(configurationFile, jsonSettings)
            ?? throw new InvalidOperationException($"Appsettings.json failed to deserialize and is null!");

        return dashboardSettings;
    }
}
