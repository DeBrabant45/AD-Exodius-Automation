namespace AD.Exodius.Helpers;

/// <summary>
/// Provides methods for resolving file and directory paths and manipulating them.
/// </summary>
/// <author>Aaron DeBrabant</author>
public interface IPathResolver
{
    /// <summary>
    /// Appends multiple files to the specified path.
    /// </summary>
    /// <param name="path">The path to which the files will be appended.</param>
    /// <param name="files">The list of files to append.</param>
    public void Append(string path, List<string> files);

    /// <summary>
    /// Appends a file to the specified path.
    /// </summary>
    /// <param name="path">The path to which the file will be appended.</param>
    /// <param name="file">The file to append.</param>
    /// <returns>The combined path with the appended file.</returns>
    public string Append(string path, string file);

    /// <summary>
    /// Generates a full path from the provided list of path components.
    /// </summary>
    /// <param name="paths">A list of path components.</param>
    /// <returns>The full path generated from the components.</returns>
    public string GeneratePath(List<string> paths);

    /// <summary>
    /// Checks if the specified directory exists.
    /// </summary>
    /// <param name="path">The path to the directory to check.</param>
    /// <returns>True if the directory exists; otherwise, false.</returns>
    public bool IsDirectoryPresent(string path);

    /// <summary>
    /// Checks if the specified file exists.
    /// </summary>
    /// <param name="file">The path to the file to check.</param>
    /// <returns>True if the file exists; otherwise, false.</returns>
    public bool IsFilePresent(string file);
}
