namespace AD.Exodius.Configurations;

public class DriverSettings
{
    public required BrowserSettings BrowserSettings { get; set; } = new();

    public required ContextSettings ContextSettings { get; set; } = new();

    public required TraceSettings TraceSettings { get; set; } = new();
}
