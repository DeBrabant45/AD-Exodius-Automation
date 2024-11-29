﻿using AD.Exodius.Utility.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;

namespace AD.Exodius.Utility.Assertions;

public static class ContainInt32Extension
{
    private static IFormatHelper FormatHelper { get; } = new FormatHelper();

    public static AndConstraint<StringAssertions> ContainInt32(this StringAssertions assertions)
    {
        var subject = assertions.Subject;

        Execute.Assertion
            .ForCondition(!string.IsNullOrEmpty(subject))
            .FailWith($"Expected a non-null and non-empty string but found {subject}.");

        var sanitizedValue = NumericSanitizer.Sanitize(subject);

        if (!FormatHelper.IsValueInt32(sanitizedValue))
        {
            Execute.Assertion
                .FailWith($"Expected the string {subject} to be an Int32");
        }

        return new AndConstraint<StringAssertions>(assertions);
    }
}