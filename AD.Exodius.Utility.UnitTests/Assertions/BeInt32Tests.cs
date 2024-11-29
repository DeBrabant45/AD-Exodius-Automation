using AD.Exodius.Utility.Assertions;

namespace AD.Exodius.Utility.UnitTests.Assertions;

public class BeInt32Tests
{
    [Theory]
    [InlineData("0")]
    [InlineData("123")]
    [InlineData("-456")]
    [InlineData("0000123")]
    [InlineData("2147483647")]
    [InlineData("-2147483648")]
    public void BeInt32_ShouldPass_ForValidInt32Strings(string value)
    {
        value.Should().BeInt32();
    }

    [Theory]
    [InlineData("123.45")]
    [InlineData("abc")]
    [InlineData("12e3")]
    [InlineData(" ")]
    [InlineData("")]
    [InlineData("1.2.3")]
    [InlineData("   456.78 ")]
    [InlineData("   -2147483649 ")]
    [InlineData("2147483648")]
    public void BeInt32_ShouldFail_ForInvalidInt32Strings(string value)
    {
        Assert.Throws<XunitException>(() => value.Should().BeInt32());
    }
}
