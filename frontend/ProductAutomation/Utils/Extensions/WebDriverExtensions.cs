using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProductAutomation.Utils.Selenium;

using static ProductAutomation.Utils.Selenium.Settings;

namespace ProductAutomation.Utils.Extensions
{
    public static class WebDriverExtensions
    {
        private static IWebDriver _driver = Driver.CurrentDriver;

        public static object WdHighlight(this By locator)
        {
            var myLocator = _driver.FindElement(locator);
            var js = (IJavaScriptExecutor) _driver;
            return js.ExecuteScript(weHighlightedColour, myLocator);
        }

        public static IWebElement WdFindElement(this By locator, int sec = 5)
        {       
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(sec));
            return wait.Until(drv =>
                {
                    try
                    {
                        locator.WdHighlight();
                        return drv.FindElement(locator);
                    }
                    catch (NoSuchElementException)
                    {
                        return null;
                    }
                });
        }

        public static void WdSendKeys(this By locator, string text, int sec = 5, bool clearFirst = false)
        {
            if (clearFirst) locator.WdFindElement(sec).Clear();
            locator.WdFindElement(sec).SendKeys(text+Keys.Return);
        }

        public static void WdClickByIndex(this By locator, int index = 0, int sec = 5)
        {
            var myLocator = _driver.FindElements(locator);
            myLocator[index].Click();
        }

        public static void WdClick(this By locator, int sec = 5)
        {
            locator.WdFindElement(sec).Click();
        }
    }
}