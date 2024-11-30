using AD.Exodius.Utility.Attributes;

namespace Mock.SwagLabs.Components.Enums;

public enum ProductFilter
{
    [HtmlElementValue("az")]
    AZ,

    [HtmlElementValue("za")]
    ZA,

    [HtmlElementValue("lohi")]
    LoHi,

    [HtmlElementValue("hilo")]
    HiLo,
}
