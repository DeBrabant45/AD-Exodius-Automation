﻿namespace AD.Exodius.Utility.Attributes;

[AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
public sealed class HtmlElementValueAttribute : Attribute, IAttributeValue
{
    public string AttributeValue { get; }

    public HtmlElementValueAttribute(string elementValue)
    {
        AttributeValue = elementValue;
    }
}
