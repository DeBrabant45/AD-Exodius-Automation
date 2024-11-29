using AD.Exodius.Utility.Assertions;

namespace AD.Exodius.Utility.UnitTests.Assertions;

public class ContainInt32Tests
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
    public void ContainInt32_ShouldPass_ForValidInt32Strings(string value)
    {
        value.Should().ContainInt32();
    }

    [Theory]
    [InlineData("123.45")]
    [InlineData("abc")]
    [InlineData("12e3.0")]
    [InlineData(" ")]
    [InlineData("")]
    [InlineData("1.2.3")]
    [InlineData("   456.78 ")]
    public void ContainInt32_ShouldFail_ForInvalidInt32Strings(string value)
    {
        Assert.Throws<XunitException>(() => value.Should().ContainInt32());
    }
}
