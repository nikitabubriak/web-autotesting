using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProductAutomation.Utils.Selenium;

using static ProductAutomation.Utils.Selenium.Settings;

namespace ProductAutomation.Utils.Extensions
{
    public static class WebElementExtensions
    {
        private static IWebDriver _driver = Driver.CurrentDriver;

        public static void WeHighlightElement(this IWebElement element)
        {
            var js = (IJavaScriptExecutor) _driver;
            js.ExecuteScript(weHighlightedColour, element);
        }

        public static bool WeElementIsEnabled(this IWebElement element, int sec = 5)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(sec));
            return wait.Until(d =>
            {
               try
               {
                   element.WeHighlightElement();
                   return element.Enabled;
               } 
               catch (StaleElementReferenceException)
               {
                   return false;
               }
            });
        }

        public static void WeSelectDropdownOptionByIndex(this IWebElement element, string text, int sec = 5)
        {
            element.WeElementIsEnabled();
            new SelectElement(element).SelectByText(text);
        }

        public static void WeSelectDropdownOptionByValue(this IWebElement element, string value, int sec = 5)
        {
            element.WeElementIsEnabled(sec);
            new SelectElement(element).SelectByValue(value);
        }

        public static string WeGetAttribute(this IWebElement element, string attribute)
        {
            return element.GetAttribute(attribute);
        }

        public static bool WeElementIsDisplayed(this IWebElement element, int sec = 5)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(sec));
            return wait.Until(d =>
            {
               try
               {
                   element.WeHighlightElement();
                   return element.Displayed;
               } 
               catch (StaleElementReferenceException)
               {
                   return false;
               }
            });
        }

        public static void WeSendKeys(this IWebElement element, string text, int sec = 5, bool clearFirst = false)
        {
            element.WeElementIsDisplayed(sec);
            if (clearFirst) element.Clear();
            element.SendKeys(text+Keys.Return);
        }

        public static void WeElementToBeClickable(this IWebElement element, int sec = 5)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(sec));
            wait.Until(c => element.Enabled);
        }

        public static void WeClick(this IWebElement element, int sec = 5)
        {
            element.WeElementToBeClickable();
            element.WeHighlightElement();
            element.Click();
        }

        public static void WeSwitchTo(this IWebElement iframe, int sec = 5)
        {
            iframe.WeElementToBeClickable(sec);
            iframe.WeHighlightElement();
            _driver.SwitchTo().Frame(iframe);
        }
    }
}