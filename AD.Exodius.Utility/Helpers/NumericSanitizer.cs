using System.Text;

namespace AD.Exodius.Utility.Helpers;

public class NumericSanitizer
{
    public static string Sanitize(string amount)
    {
        var allowedCharacters = new HashSet<char> { '.', '-' };
        var result = new StringBuilder(amount.Length);

        foreach (var c in amount)
        {
            if (char.IsDigit(c) || allowedCharacters.Contains(c))
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }
}
