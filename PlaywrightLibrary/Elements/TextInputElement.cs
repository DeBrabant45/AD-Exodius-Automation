using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightLibrary.Elements;
public class TextInputElement : BaseElement
{
    public TextInputElement(ILocator webElement) : base(webElement)
    {

    }

    public async Task TypeInput(string input) => await Locator.FillAsync(input);
}
