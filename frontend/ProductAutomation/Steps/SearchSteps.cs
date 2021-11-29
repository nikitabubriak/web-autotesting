using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ProductAutomation.Pages;
using TechTalk.SpecFlow;
using ProductAutomation.Utils.Selenium;
using System;



namespace ProductAutomation.Steps.SearchSteps
{
    [Binding]
    public class SearchSteps
    {
        public IWebDriver driver = Driver.CurrentDriver;
        private BasePage basePage = new BasePage();

        [When(@"they search for ""(.*)""")]
        public void WhenISearchFor(string searchTerm)
        {
            basePage.SearchFor(searchTerm); 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(driver => driver.FindElement(By.CssSelector("h3")));
            //Thread.Sleep(60000);
        }
    }
}