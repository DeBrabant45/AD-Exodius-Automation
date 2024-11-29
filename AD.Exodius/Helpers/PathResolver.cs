namespace AD.Exodius.Helpers;

public class PathResolver : IPathResolver
{
    public bool IsFilePresent(string file) => File.Exists(file);

    public bool IsDirectoryPresent(string path) => Directory.Exists(path);

    public string GeneratePath(List<string> paths)
    {
        try
        {
            var sanitizedPaths = paths.Select(SanitizePathComponent).ToList();
            var currentDirectory = Directory.GetCurrentDirectory();
            var fullPath = Path.Combine(sanitizedPaths.Prepend(currentDirectory).ToArray());
            if (!IsDirectoryPresent(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            return fullPath;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while generating path: {ex.Message}", ex);
        }
    }

    public void Append(string path, List<string> files)
    {
        foreach (string file in files)
        {
            Append(path, file);
        }
    }

    public string Append(string path, string file)
    {
        try
        {
            var sanitizedFileName = SanitizePathComponent(file);
            return Path.Combine(path, sanitizedFileName);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while combining path and file: {ex.Message}");
        }
    }

    private string SanitizePathComponent(string component)
    {
        var invalidChars = Path.GetInvalidFileNameChars().Concat(Path.GetInvalidPathChars()).ToArray();
        var sanitizedComponent = new string(component.Where(c => !invalidChars.Contains(c)).ToArray());

        return sanitizedComponent;
    }
}
