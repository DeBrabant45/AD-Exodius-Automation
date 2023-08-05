using AD.Playwrightlib.Driver;

namespace AD.Playwrightlib.Configuration;

public class TestSettings
{
    public Browser Browser { get; set; } = Browser.Chrome;

    public string ApplicationUrl { get; set; } = string.Empty;

    public string[]? Args { get; set; }

    public float? Timeout = 30f;

    public bool? Headless { get; set; } = true;

    public float? SlowMotion { get; set; } = null;
}
