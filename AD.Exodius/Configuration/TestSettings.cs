using AD.Exodius.Driver;

namespace AD.Exodius.Configuration;

public class TestSettings
{
    public Browser Browser { get; set; } = Browser.Chrome;

    public string ApplicationUrl { get; set; } = string.Empty;

    public string[]? Args { get; set; }

    public float? Timeout = 30f;

    public bool? Headless { get; set; } = true;

    public float? SlowMotion { get; set; } = null;

    public string Username { get; set; } = string.Empty;

    public string Password { get; set; } = string.Empty;

    public string StorageStatePath { get; set; } = "state.json";
    public bool UseSavedState { get; set; }
    public bool AcceptDownloads { get; set; }
    public ViewportSize ViewportSize { get; set; } = new() { Height = 1080, Width = 1920 };
}
