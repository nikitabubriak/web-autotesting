using ProductAutomation.Utils.Selenium;
using TechTalk.SpecFlow;

namespace ProductAutomation.Utils.Hooks
{
    internal static class TestRunHooks
    {
        [AfterTestRun]
        internal static void AfterTestRun()
        {
            Driver.CurrentDriver.Quit();
        }
    }
}