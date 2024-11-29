using AD.Exodius.Utility.Assertions;

namespace AD.Exodius.Utility.UnitTests.Assertions;

public class ContainDoubleTests
{
    [Theory]
    [InlineData("0", 0)]
    [InlineData("0.0", 1)]
    [InlineData("10", 0)]
    [InlineData("20.1", 1)]
    [InlineData("100.1%", 1)]
    [InlineData("70 MINS", 0)]
    [InlineData("   12.345 ", 3)]
    [InlineData("0.123456", 6)]
    [InlineData("-123.45", 2)]
    [InlineData("-0.1", 1)]
    [InlineData("1234567890", 0)]
    [InlineData("1234567890.9876543", 7)]
    public void ContainDouble_ShouldPass_WithValidDoubleStrings(string value, int decimals)
    {
        value.Should().ContainDouble(decimals);
    }

    [Theory]
    [InlineData("abc", 0)]
    [InlineData("100.1234", 2)]
    [InlineData("12.34.56", 2)]
    [InlineData("12.34", 3)]
    [InlineData(null, 0)]
    public void ContainDouble_ShouldFail_WithInvalidDoubleStrings(string value, int decimals)
    {
        Assert.Throws<XunitException>(() => value.Should().ContainDouble(decimals));
    }
}
