using Microsoft.Extensions.Logging;

namespace AD.Exodius.Utility.Errors;

public static class ErrorExtensions
{
    /// <summary>
    /// Throws an ArgumentException if the value is null, and logs the error message.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="value">The value to check.</param>
    /// <param name="errorMessage">The error message to log and include in the exception.</param>
    /// <param name="logger">The logger to use for logging the error message.</param>
    /// <returns>The original value if it is not null.</returns>
    /// <exception cref="ArgumentException">Thrown if the value is null.</exception>
    public static T ThrowIfNull<T>(this T? value, string errorMessage, ILogger logger)
    {
        if (value != null)
            return value;

        logger.LogError(errorMessage);
        throw new ArgumentException(errorMessage);
    }

    /// <summary>
    /// Throws an ArgumentException if the string is null or whitespace, and logs the error message.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="errorMessage">The error message to log and include in the exception.</param>
    /// <param name="logger">The logger to use for logging the error message.</param>
    /// <returns>The original string if it is not null or whitespace.</returns>
    /// <exception cref="ArgumentException">Thrown if the string is null or whitespace.</exception>
    public static string ThrowIfNullOrWhiteSpace(this string? value, string errorMessage, ILogger logger)
    {
        if (!string.IsNullOrWhiteSpace(value))
            return value;

        logger.LogError(errorMessage);
        throw new ArgumentException(errorMessage);
    }

    /// <summary>
    /// Throws an ArgumentException and logs the error message.
    /// </summary>
    /// <param name="errorMessage">The error message to log and include in the exception.</param>
    /// <param name="logger">The logger to use for logging the error message.</param>
    /// <exception cref="ArgumentException">Always thrown.</exception>
    public static void ThrowArgumentException(string errorMessage, ILogger logger)
    {
        logger.LogError(errorMessage);
        throw new ArgumentException(errorMessage);
    }
}