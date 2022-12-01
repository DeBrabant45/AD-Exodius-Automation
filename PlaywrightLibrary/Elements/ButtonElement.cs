using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightLibrary.Elements;
public class ButtonElement : BaseElement
{
    public ButtonElement(ILocator locator) : base(locator)
    {
    }

    public async Task Click() => await Locator.ClickAsync();
}