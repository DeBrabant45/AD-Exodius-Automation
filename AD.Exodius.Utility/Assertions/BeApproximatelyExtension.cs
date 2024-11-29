using FluentAssertions.Numeric;

namespace AD.Exodius.Utility.Assertions;

public static class BeApproximatelyExtension
{
    /// <summary>
    /// Asserts that a numeric value is within a specified variance of an expected value.
    /// </summary>
    /// <typeparam name="TNumeric">The numeric type of the value being asserted. Must be a value type and implement <see cref="IComparable{TNumeric}"/>.</typeparam>
    /// <param name="assertions">The <see cref="NumericAssertions{TNumeric}"/> to apply the assertion on.</param>
    /// <param name="expectedValue">The expected value to compare against, of type <typeparamref name="TNumeric"/>.</param>
    /// <param name="variance">The allowable variance or difference from the expected value, of type <typeparamref name="TNumeric"/>. Defaults to 2.</param>
    /// <param name="logger">
    /// An optional logging action to output a message indicating whether the actual value was within the allowed variance. 
    /// If not provided, logs to the console by default.
    /// </param>
    /// <exception cref="FluentAssertions.Execution.AssertionFailedException">
    /// Thrown when the value is outside the specified range.
    /// </exception>
    /// <example>
    /// <code>
    /// double actualValue = 98.5;
    /// double expectedValue = 100.0;
    /// double variance = 2.0;
    /// 
    /// actualValue.Should().BeApproximately(expectedValue, variance, message => Console.WriteLine(message));
    /// </code>
    /// This example asserts that <c>actualValue</c> is within 2 units of <c>expectedValue</c> and logs the result.
    /// </example>
    public static void BeApproximately<TNumeric>(
        this NumericAssertions<TNumeric> assertions,
        TNumeric expectedValue,
        TNumeric variance,
        Action<string>? logger = null)
        where TNumeric : struct, IComparable<TNumeric>
    {
        logger ??= message => Console.WriteLine(message);

        var actualValue = assertions.Subject.Value;
        var expectedValueDouble = Convert.ToDouble(expectedValue);
        var actualValueDouble = Convert.ToDouble(actualValue);
        var varianceDouble = Convert.ToDouble(variance);

        var isExactMatch = Math.Abs(actualValueDouble - expectedValueDouble) < 1e-10;
        var isWithinVariance = Math.Abs(actualValueDouble - expectedValueDouble) <= varianceDouble;

        var message = isExactMatch
            ? $"[INFO] Actual value {actualValue} is exactly the same as the expected value {expectedValue}."
            : $"[INFO] Actual value {actualValue} differed from expected {expectedValue} and was {(isWithinVariance ? "within" : "outside")} the allowed variance of {variance}.";

        logger(message);

        assertions.BeInRange(
            (TNumeric)Convert.ChangeType(expectedValueDouble - varianceDouble, typeof(TNumeric)),
            (TNumeric)Convert.ChangeType(expectedValueDouble + varianceDouble, typeof(TNumeric)),
            $"because the value should be within {variance} units of {expectedValue}");
    }
}
