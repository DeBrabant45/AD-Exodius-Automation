using AD.Exodius.Utility.Primitives;

namespace AD.Exodius.Utility.UnitTests.Extensions;

public class ConvertToTypeTests
{
    [Fact]
    public void ConvertToType_IntToString()
    {
        int amount = 1000;
        string result = amount.ConvertToType<string, int>();
        var expected = "1,000";

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_DoubleToString()
    {
        double amount = 12345.6;
        string result = amount.ConvertToType<string, double>();
        var expected = "12,345.6";

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_FloatToString()
    {
        float amount = 9876.54f;
        string result = amount.ConvertToType<string, float>();
        var expected = "9,876.5";

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_IntToInt()
    {
        int amount = 1000;
        int result = amount.ConvertToType<int, int>();
        var expected = 1000;

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_NullableLongToInt_NullValue()
    {
        long? amount = null;
        int result = amount.ConvertToType<int, long>();
        var expected = default(int);

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_NullableIntToString()
    {
        int? amount = 1000;
        string result = amount.ConvertToType<string, int>();
        var expected = "1,000";

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_NullableIntToString_NullValue()
    {
        int? amount = null;
        string result = amount.ConvertToType<string, int>();
        var expected = default(string);

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_IntToDouble()
    {
        int amount = 1000;
        double result = amount.ConvertToType<double, int>();
        var expected = 1000.0;

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_NullableIntToDouble_NullValue()
    {
        int? amount = null;
        double result = amount.ConvertToType<double, int>();
        var expected = default(double);

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_IntToInt64()
    {
        int amount = 1000;
        long result = amount.ConvertToType<long, int>();
        var expected = 1000L;

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_NullableIntToInt64_NullValue()
    {
        int? amount = null;
        long result = amount.ConvertToType<long, int>();
        var expected = default(long);

        result.Should().Be(expected);
    }

    [Theory]
    [InlineData("1234", 1234)]
    [InlineData("1234.0", 1234)]
    [InlineData("1234.99", 1234)]
    public void ConvertToType_StringToInt32(string amount, int expected)
    {
        int result = amount.ConvertToType<int>();

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_StringToInt64()
    {
        var amount = "9,223,372,036,854,775,807";
        long result = amount.ConvertToType<long>();
        var expected = 9223372036854775807;

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_StringToDouble()
    {
        var amount = "1234.5678";
        double result = amount.ConvertToType<double>();
        var expected = 1234.5;

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_StringToFloat()
    {
        var amount = "1234.5678";
        float result = amount.ConvertToType<float>();
        var expected = 1234.5f;

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_StringToDecimal()
    {
        var amount = "1234.5678";
        decimal result = amount.ConvertToType<decimal>();
        var expected = 1234.5M;

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_StringToString()
    {
        var amount = "1234.5678";
        string result = amount.ConvertToType<string>();
        var expected = "1234.5678";

        result.Should().Be(expected);
    }

    [Fact]
    public void ConvertToType_ThrowException()
    {
        var amount = "NaN%";

        Action act = () => amount.ConvertToType<int>();

        act.Should().Throw<ArgumentException>()
            .WithMessage("The sanitized amount resulted in an empty string. Input value: 'NaN%'.");
    }
}
