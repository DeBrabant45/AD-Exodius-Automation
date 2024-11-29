namespace AD.Exodius.Configurations;

public class BrowserSettings
{
    public string[]? Args { get; set; }

    public float? Timeout { get; set; } = 30f;

    public bool? Headless { get; set; } = true;

    public float? SlowMotion { get; set; } = null;

    public Browser Browser { get; set; } = Browser.Chrome;
}
