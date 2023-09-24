using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AD.Exodius.Configuration;

public static class ConfigurationReader
{
    public static TestSettings Read()
    {
        var configurationFile = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/appsettings.json");
        var jsonSettings = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };
        jsonSettings.Converters.Add(new JsonStringEnumConverter());
        return JsonSerializer.Deserialize<TestSettings>(configurationFile, jsonSettings);
    }
}
