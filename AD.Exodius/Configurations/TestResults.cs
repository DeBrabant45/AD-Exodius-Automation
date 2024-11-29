namespace AD.Exodius.Configurations;

public class TestResults
{
    public bool HasTestFailed { get; set; }

    public List<string> FolderPaths { get; set; } = [];

    public List<Tuple<string, List<string>>> TestParameters { get; set; } = [];

    public string ExpectedResults { get; set; } = string.Empty;

    public string StackTrace { get; set; } = string.Empty;
}
