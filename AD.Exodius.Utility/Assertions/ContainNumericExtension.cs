using AD.Exodius.Utility.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace AD.Exodius.Utility.Assertions;

public static class ContainNumericExtension
{
    private static IFormatHelper FormatHelper { get; } = new FormatHelper();

    public static AndConstraint<StringAssertions> ContainNumeric(this StringAssertions assertions)
    {
        var subject = assertions.Subject;

        Execute.Assertion
            .ForCondition(!string.IsNullOrEmpty(subject))
            .FailWith($"Expected a non-null and non-empty string but found {subject}.");

        var sanitizedValue = NumericSanitizer.Sanitize(subject);

        if (!FormatHelper.IsValueNumeric(sanitizedValue))
        {
            Execute.Assertion
                .FailWith($"Expected the string {subject} to contain a numeric value.");
        }

        return new AndConstraint<StringAssertions>(assertions);
    }
}
