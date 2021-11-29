using System;
using OpenQA.Selenium;
using ProductAutomation.Utils.Extensions;
using ProductAutomation.Utils.Selenium;

using static ProductAutomation.Utils.Selenium.Settings;

namespace ProductAutomation.Pages
{
    public class BasePage
    {
        public IWebDriver driver = Driver.CurrentDriver;
        public string GetTitle => Driver.CurrentDriver.Title;
        public string GetUrl => Driver.CurrentDriver.Url;
        public string GetPageSource => Driver.CurrentDriver.PageSource;
        public By SearchField => By.Name("q");

        public void NavigateBaseUrl()
        {
            driver.Navigate().GoToUrl(baseUrl);
            driver.Manage().Window.Maximize();
            Console.WriteLine(" :: The base URL is navigated to");
        }

        public SearchResultsPage SearchFor(string searchTerm)
        {
            SearchField.WdSendKeys(searchTerm);
            return new SearchResultsPage();
        }
    }
}