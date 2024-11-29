using System.Globalization;

namespace AD.Exodius.Utility.Helpers;

public class FormatHelper : IFormatHelper
{
    public bool IsValueInt32(string value)
    {
        return int.TryParse(value, NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out _);
    }

    public bool IsValueInt64(string value)
    {
        return long.TryParse(value, NumberStyles.AllowThousands | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out _);
    }

    public bool IsValueDouble(string value, int decimalPlaces = -1)
    {
        if (double.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out double result))
        {
            return HasCorrectDecimalPlaces(value, decimalPlaces);
        }

        return false;
    }

    public bool IsValueFloat(string value, int decimalPlaces = -1)
    {
        if (float.TryParse(value, NumberStyles.Float | NumberStyles.AllowThousands, CultureInfo.InvariantCulture, out float result))
        {
            return HasCorrectDecimalPlaces(value, decimalPlaces);
        }

        return false;
    }

    public bool IsValueDecimal(string value, int decimalPlaces = -1)
    {
        if (decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal result))
        {
            return HasCorrectDecimalPlaces(value, decimalPlaces);
        }

        return false;
    }

    public bool IsValueNumeric(string value)
    {
        return IsValueInt32(value) 
            || IsValueInt64(value) 
            || IsValueFloat(value) 
            || IsValueDouble(value) 
            || IsValueDecimal(value);
    }

    public bool IsValueBoolean(string value)
    {
        return bool.TryParse(value, out _);
    }

    public bool IsValueChar(string value)
    {
        return char.TryParse(value, out _);
    }

    private bool HasCorrectDecimalPlaces(string value, int decimalPlaces)
    {
        if (decimalPlaces < 0)
            return true;

        var actualDecimalPlaces = value.Contains('.') ? value.Substring(value.IndexOf('.') + 1).Length : 0;

        return actualDecimalPlaces == decimalPlaces;
    }
}
