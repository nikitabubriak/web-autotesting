using NUnit.Framework;
using System;
using OpenQA.Selenium;
using ProductAutomation.Pages;
using TechTalk.SpecFlow;

namespace ProductAutomation.Steps.BaseSteps
{
    [Binding]
    public class BaseSteps
    {
        private BasePage basePage = new BasePage();

        [Given(@"(?:a Google|an internet) user is on the (?:base|search) page")] 
        public void GivenIAmOnTheBasePage() 
        { 
            basePage.NavigateBaseUrl();
        }

        [Then(@"they see the page title contains ""(.*)""")]

        public void ThenIseeThePageTitleContains(string expectedTitle)
        {
            var titleToValidate = basePage.GetTitle.Contains(expectedTitle);
            Assert.IsTrue(titleToValidate, " :: The actual page title is incorrect");
            Console.WriteLine(" :: The actual page title is " + titleToValidate);
        }

        [Then(@"the page URL contains ""(.*)""")]
        public void ThenISeeThePageUrlContains(string expectedUrl)
        {
            var urlToValidate = basePage.GetUrl.Contains(expectedUrl);
            Assert.IsTrue(urlToValidate, " :: The actual page URL is different");
            Console.WriteLine(" :: The actual page URL is " + urlToValidate);
        }

        [Then(@"they see ""(.*)"" in the PageSource")]
        public void ThenISeeInThePageSource(string expectedText)
        {
            var pageSourceTextToValidate = basePage.GetPageSource.Contains(expectedText);
            Assert.IsTrue(pageSourceTextToValidate, " :: The expected string is not present in the page source");
            Console.WriteLine(" :: The page source does not contain " + expectedText);
        }

        [Then(@"they see")]
        public void ThenISee(Table table)
        {
            foreach (var row in table.Rows) 
            { 
                var textToValidate = row["expected_text"]; 
                Assert.IsTrue(basePage.GetPageSource.Contains(textToValidate), textToValidate + " is not in the PageSource!"); 
                Console.WriteLine(":: The text " + textToValidate + " is in the PageSource "); 
            }
        }
    }
}