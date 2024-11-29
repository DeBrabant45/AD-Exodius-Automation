using FluentAssertions;
using FluentAssertions.Primitives;
using FluentAssertions.Execution;
using AD.Exodius.Utility.Helpers;

namespace AD.Exodius.Utility.Assertions;

public static class BeInt32Extension
{
    private static IFormatHelper FormatHelper { get; } = new FormatHelper();

    public static AndConstraint<StringAssertions> BeInt32(this StringAssertions assertions)
    {
        var subject = assertions.Subject;

        Execute.Assertion
            .ForCondition(!string.IsNullOrEmpty(subject))
            .FailWith($"Expected a non-null and non-empty string but found {subject}.");

        if (!FormatHelper.IsValueInt32(subject))
        {
            Execute.Assertion
                .FailWith($"Expected the string {subject} to be an Int32");
        }

        return new AndConstraint<StringAssertions>(assertions);
    }
}
