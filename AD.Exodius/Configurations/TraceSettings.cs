namespace AD.Exodius.Configurations;

public class TraceSettings
{
    public bool IsTraceEnabled { get; set; }

    public bool Screenshots { get; set; } = true;

    public bool Snapshots { get; set; } = true;

    public bool Sources { get; set; } = true;

    public CaptureType CaptureType { get; set; }

    public string FileStoragePath { get; set; } = string.Empty;
}

public enum CaptureType
{
    Failure,
    Success,
    All,
    None
}