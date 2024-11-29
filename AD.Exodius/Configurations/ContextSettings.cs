namespace AD.Exodius.Configurations;

public class ContextSettings
{
    public bool UseSavedState { get; set; }

    public bool AcceptDownloads { get; set; }

    public string StorageStatePath { get; set; } = "state.json";

    public ViewportSize ViewportSize { get; set; } = new() { Height = 1080, Width = 1920 };
}
