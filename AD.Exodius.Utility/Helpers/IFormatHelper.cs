namespace AD.Exodius.Utility.Helpers;

public interface IFormatHelper
{
    public bool IsValueBoolean(string value);
    public bool IsValueChar(string value);
    public bool IsValueDecimal(string value, int decimalPlaces = -1);
    public bool IsValueDouble(string value, int decimalPlaces = -1);
    public bool IsValueFloat(string value, int decimalPlaces = -1);
    public bool IsValueInt32(string value);
    public bool IsValueInt64(string value);
    public bool IsValueNumeric(string value);
}
