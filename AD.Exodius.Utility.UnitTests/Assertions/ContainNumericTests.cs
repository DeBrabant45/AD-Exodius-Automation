using AD.Exodius.Utility.Assertions;

namespace AD.Exodius.Utility.UnitTests.Assertions;

public class ContainNumericTests
{
    [Theory]
    [InlineData("0")]
    [InlineData("123")]
    [InlineData("-456")]
    [InlineData("0000123")]
    [InlineData("2147483647")]
    [InlineData("-2147483648")]
    [InlineData("   789   ")]
    [InlineData("800 mins")]
    [InlineData("100%")]
    [InlineData("-123.45")]
    [InlineData("-0.1")]
    [InlineData("1234567890.9876543")]
    public void ContainNumeric_ShouldPass_ForValidStrings(string value)
    {
        value.Should().ContainNumeric();
    }

    [Theory]
    [InlineData("Hello%")]
    [InlineData("abc")]
    [InlineData("Not a Number")]
    [InlineData(" ")]
    [InlineData("")]
    public void ContainNumeric_ShouldFail_ForInvalidStrings(string value)
    {
        Assert.Throws<XunitException>(() => value.Should().ContainNumeric());
    }
}
