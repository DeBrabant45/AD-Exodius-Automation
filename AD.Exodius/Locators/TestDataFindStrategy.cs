﻿namespace AD.Exodius.Locators;

public class TestDataFindStrategy : FindStrategy
{
    public TestDataFindStrategy(string value) : base(value)
    {
    }

    public override string Convert() => $"data-test={Value}";
}
