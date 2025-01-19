using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Numeric;

namespace AD.Exodius.Utility.Assertions;

public static class BeTruncatedToExtension
{
    public static AndConstraint<NumericAssertions<double>> BeTruncatedTo(
        this NumericAssertions<double> assertions, 
        double expected, 
        int decimalPlaces = 1, 
        string because = "", 
        params object[] becauseArgs)
    {
        if (!assertions.Subject.HasValue)
        {
            Execute.Assertion
                .BecauseOf(because, becauseArgs)
                .FailWith($"Expected {{context:double}} to be approximately {expected} to {decimalPlaces} decimal places{{reason}}, but found <null>.");
        }

        var actual = assertions.Subject.Value;

        var truncatedActual = TruncateToDecimals(actual, decimalPlaces);
        var truncatedExpected = TruncateToDecimals(expected, decimalPlaces);

        Execute.Assertion
            .ForCondition(truncatedActual == truncatedExpected)
            .BecauseOf(because, becauseArgs)
            .FailWith($"Expected {{context:double}} to be approximately {truncatedExpected} to {decimalPlaces} decimal places{{reason}}, but found {truncatedActual}.");

        return new AndConstraint<NumericAssertions<double>>(assertions);
    }

    private static double TruncateToDecimals(double value, int decimalPlaces)
    {
        double multiplier = Math.Pow(10, decimalPlaces);
        return Math.Truncate(value * multiplier) / multiplier;
    }
}
