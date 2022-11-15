using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrightLibrary.Driver;

public interface IBrowserService
{
    public Task Start(Browser browserType, BrowserTypeLaunchOptions options);
    public Task Quit();
}