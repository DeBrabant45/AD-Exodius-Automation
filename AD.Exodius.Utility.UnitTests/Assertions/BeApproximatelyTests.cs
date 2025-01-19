using AD.Exodius.Utility.Assertions;
using FluentAssertions.Numeric;

namespace AD.Exodius.Utility.UnitTests.Assertions;

public class BeApproximatelyTests
{
    private readonly ITestOutputHelper _output;

    public BeApproximatelyTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Theory]
    [InlineData(98, 100, 2)]
    [InlineData(100, 100, 2)]
    [InlineData(102, 100, 2)]
    public void BeApproximately_ShouldPass_ForValidVariance_Int32(int actualValue, int expectedValue, int variance)
    {
        var assertions = new NumericAssertions<int>(actualValue);

        assertions.BeApproximately(expectedValue, variance);
    }

    [Theory]
    [InlineData(97, 100, 2)]
    [InlineData(103, 100, 2)]
    public void BeApproximately_ShouldFail_ForInvalidVariance_Int32(int actualValue, int expectedValue, int variance)
    {
        var assertions = new NumericAssertions<int>(actualValue);

        Assert.Throws<XunitException>(() =>
            assertions.BeApproximately(expectedValue, variance));
    }

    [Theory]
    [InlineData(100.0, 100.0, 0.0)]
    [InlineData(98.5, 100.0, 2.0)]
    [InlineData(100.0, 100.0, 2.0)]
    [InlineData(57.2, 57.4, 0.2)]
    [InlineData(57.2, 57.3, 0.1)]
    [InlineData(100.0, 100.0, 10.0)]
    [InlineData(90.0, 100.0, 20.0)]
    [InlineData(105.5, 100.0, 10.0)]
    [InlineData(95.0, 100.0, 10.0)]
    [InlineData(99.9, 100.0, 1.0)]
    [InlineData(100.1, 100.0, 1.0)]
    [InlineData(0.123456789, 0.123456780, 0.000001)]
    [InlineData(0.123456789, 0.123456780, 0.00001)]
    public void BeApproximately_ShouldPass_ForValidVariance_Double(double actualValue, double expectedValue, double variance)
    {
        var assertions = new NumericAssertions<double>(actualValue);

        assertions.BeApproximately<double>(expectedValue, variance, _output.WriteLine);
    }

    [Theory]
    [InlineData(99.9, 100.0, 0.0)]
    [InlineData(100.1, 100.0, 0.0)]
    [InlineData(97.5, 100.0, 2.0)]
    [InlineData(102.5, 100.0, 2.0)]
    [InlineData(89.0, 100.0, 10.0)]
    [InlineData(110.0, 99.8, 10.0)]
    [InlineData(78.9, 99.9, 20.0)]
    [InlineData(121.5, 100.1, 20.0)]
    [InlineData(101.5, 100.0, 1.0)]
    [InlineData(98.5, 100.0, 1.0)]
    public void BeApproximately_ShouldFail_ForInvalidVariance_Double(double actualValue, double expectedValue, double variance)
    {
        var assertions = new NumericAssertions<double>(actualValue);

        Assert.Throws<XunitException>(() => assertions.BeApproximately<double>(expectedValue, variance));
    }

    [Theory]
    [InlineData(98, 100, 2)]
    [InlineData(10.2, 10.3, 0.2)]
    [InlineData(102.05, 102.06, 2)]
    public void BeApproximately_ShouldLogCorrectMessage_ForValidGivenVariance(double actualValue, double expectedValue, double variance)
    {
        var stringWriter = new StringWriter();
        Action<string> logger = stringWriter.WriteLine;

        actualValue.Should().BeApproximately(expectedValue, variance, logger);

        var output = stringWriter.ToString().Trim();
        var expectedLogMessage = $"[INFO] Actual value {actualValue} differed from expected {expectedValue} and was within the allowed variance of {variance}.";

        expectedLogMessage.Should().Contain(output);
    }

    [Theory]
    [InlineData(100, 100, 2)]
    [InlineData(10.1, 10.1, 0.1)]
    [InlineData(102.05, 102.05, 2)]
    public void BeApproximately_ShouldLogCorrectMessage_ForExactMatch(double actualValue, double expectedValue, double variance)
    {
        var stringWriter = new StringWriter();
        Action<string> logger = stringWriter.WriteLine;

        actualValue.Should().BeApproximately(expectedValue, variance, logger);

        var output = stringWriter.ToString().Trim();
        var expectedLogMessage = $"[INFO] Actual value {actualValue} is exactly the same as the expected value {expectedValue}.";

        expectedLogMessage.Should().Contain(output);
    }
}
