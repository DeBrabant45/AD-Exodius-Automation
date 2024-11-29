using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using FluentAssertions;
using AD.Exodius.Utility.Helpers;

namespace AD.Exodius.Utility.Assertions;

public static class ContainDoubleExtension
{
    private static IFormatHelper FormatHelper { get; } = new FormatHelper();

    public static AndConstraint<StringAssertions> ContainDouble(this StringAssertions assertions, int decimalPlaces = 1)
    {
        var subject = assertions.Subject;

        Execute.Assertion
            .ForCondition(!string.IsNullOrEmpty(subject))
            .FailWith($"Expected a non-null and non-empty string but found {subject}.");

        var sanitizedValue = NumericSanitizer.Sanitize(subject);

        if (!FormatHelper.IsValueDouble(sanitizedValue, decimalPlaces))
        {
            Execute.Assertion
                .FailWith($"Expected the string {subject} to contain a valid double with {decimalPlaces} decimal places, but it did not.");
        }

        return new AndConstraint<StringAssertions>(assertions);
    }
}
