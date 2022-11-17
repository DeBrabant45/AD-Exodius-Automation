using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightLibrary.Locators;

public class CssSelectorFindStrategy : FindStrategy
{
    public CssSelectorFindStrategy(string value) : base(value)
    {
    }

    public override string Convert() => Value;
}
