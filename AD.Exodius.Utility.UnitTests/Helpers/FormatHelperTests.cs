using AD.Exodius.Utility.Helpers;

namespace AD.Exodius.Utility.UnitTests.Helpers;

public class FormatHelperTests
{
    private readonly IFormatHelper _formatHelper;

    public FormatHelperTests()
    {
        _formatHelper = new FormatHelper();
    }

    [Theory]
    [InlineData("123", true)]
    [InlineData("-123", true)]
    [InlineData("123.45", false)]
    [InlineData("abc", false)]
    public void IsValueInt32_ShouldBe_ExpectedResult(string value, bool expected)
    {
        var result = _formatHelper.IsValueInt32(value);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("1234567890123", true)]
    [InlineData("-1234567890123", true)]
    [InlineData("1234567890123.45", false)]
    [InlineData("abc", false)]
    public void IsValueInt64_ShouldBe_ExpectedResult(string value, bool expected)
    {
        var result = _formatHelper.IsValueInt64(value);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123.45", true, 2)]
    [InlineData("123.456", false, 2)]
    [InlineData("123", true, 0)]
    [InlineData("123.4", true, 1)]
    [InlineData("123.45", false, 3)]
    [InlineData("abc", false, 2)]
    public void IsValueFloat_ShouldBe_ExpectedResult(string value, bool expected, int decimalPlaces)
    {
        var result = _formatHelper.IsValueFloat(value, decimalPlaces);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123.45", true, 2)]
    [InlineData("123.456", false, 2)]
    [InlineData("123", true, 0)]
    [InlineData("123.4", true, 1)]
    [InlineData("123.45", false, 3)]
    [InlineData("abc", false, 2)]
    public void IsValueDouble_ShouldBe_ExpectedResult(string value, bool expected, int decimalPlaces)
    {
        var result = _formatHelper.IsValueDouble(value, decimalPlaces);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("123.45", true, 2)]
    [InlineData("123.456", false, 2)]
    [InlineData("123", true, 0)]
    [InlineData("123.4", true, 1)]
    [InlineData("123.45", false, 3)]
    [InlineData("abc", false, 2)]
    public void IsValueDecimal_ShouldBe_ExpectedResult(string value, bool expected, int decimalPlaces)
    {
        var result = _formatHelper.IsValueDecimal(value, decimalPlaces);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("0", true)]
    [InlineData("123", true)]
    [InlineData("47.00", true)]
    [InlineData(".001", true)]
    [InlineData("1234567890123", true)]
    [InlineData("N/A", false)]
    [InlineData("12 min", false)]
    [InlineData("67.0%", false)]
    public void IsValueNumeric_ShouldBe_ExpectedResult(string value, bool expected)
    {
        var result = _formatHelper.IsValueNumeric(value);

        result.Should().Be(expected);
    }
}
