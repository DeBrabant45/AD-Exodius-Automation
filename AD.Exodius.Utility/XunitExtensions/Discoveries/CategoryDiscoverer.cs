﻿using Xunit.Abstractions;
using Xunit.Sdk;

namespace AD.Exodius.Utility.XunitExtensions.Discoveries;

public class CategoryDiscoverer : ITraitDiscoverer
{
    public const string Key = "Category";

    public IEnumerable<KeyValuePair<string, string>> GetTraits(IAttributeInfo traitAttribute)
    {
        var ctorArgs = traitAttribute.GetConstructorArguments().ToList();
        yield return new KeyValuePair<string, string>(Key, ctorArgs[0].ToString());
    }
}