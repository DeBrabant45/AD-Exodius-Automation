using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightLibrary.Elements;

public interface IElement
{
    public Task<string> Text();
    public Task<string> Value();
}
