using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AD.Exodius.Configurations;

public static class DriverConfigurationReader
{
    public static DriverSettings Read()
    {
        var configurationFile = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/driversettings.json");
        var jsonSettings = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
        };
        jsonSettings.Converters.Add(new JsonStringEnumConverter());
        var testSettings = JsonSerializer.Deserialize<DriverSettings>(configurationFile, jsonSettings)
            ?? throw new InvalidOperationException($"Driversettings failed to deserialize and is null!");

        UpdateTestSettingsWithEnvironmentVariables(testSettings);

        return testSettings;
    }

    private static void UpdateTestSettingsWithEnvironmentVariables(DriverSettings testSettings)
    {
        UpdateTestResultsPath(testSettings.TraceSettings);
        UpdateTestCaptureType(testSettings.TraceSettings);
    }

    private static void UpdateTestResultsPath(TraceSettings traceSettings)
    {
        traceSettings.FileStoragePath = GetEnvironmentVariable("TEST_RESULTS_PATH", traceSettings.FileStoragePath);
    }

    private static void UpdateTestCaptureType(TraceSettings traceSettings)
    {
        var testCaptureType = GetEnvironmentVariable("TEST_CAPTURE_TYPE");
        if (!string.IsNullOrEmpty(testCaptureType) 
            && Enum.TryParse<CaptureType>(testCaptureType, out var parsedCaptureType))
        {
            traceSettings.CaptureType = parsedCaptureType;
        }
    }

    private static string GetEnvironmentVariable(string variableName, string defaultValue = "")
    {
        return Environment.GetEnvironmentVariable(variableName) ?? defaultValue;
    }
}
