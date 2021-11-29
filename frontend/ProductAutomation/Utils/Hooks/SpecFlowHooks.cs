using ProductAutomation.Utils.Selenium;
using TechTalk.SpecFlow;

namespace ProductAutomation.Utils.Hooks
{
    [Binding]
    internal static class SpecFlowHooks
    {
        [Before]
        [Scope(Tag = "Chrome")]
        internal static void StartChromeDriver()
        {
            Driver.InitChrome();
        }

        [Before]
        [Scope(Tag = "Firefox")]
        internal static void StartFirefoxDriver()
        {
            Driver.InitFirefox();
        }

        [After]
        internal static void StopWebDriver()
        {
            Driver.CurrentDriver.Quit();
        }
    }
}