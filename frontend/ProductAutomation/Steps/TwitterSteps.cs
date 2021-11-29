using NUnit.Framework;
using OpenQA.Selenium;
using ProductAutomation.Pages;
using ProductAutomation.Utils.Extensions;
using TechTalk.SpecFlow;

namespace ProductAutomation.Steps.TwitterSteps
{
    [Binding]
    public class TwitterSteps
    {
        private SearchResultsPage searchResultsPage = new SearchResultsPage();
        private TwitterPage twitterPage = new TwitterPage();

        [When(@"they view the first result")]
        public void WhenIViewTheFirstResult()
        {
            IWebElement searchResults = searchResultsPage.driver.FindElement(searchResultsPage.SearchResultsContainer);
            Assert.IsTrue(searchResults.WeElementIsDisplayed());
            searchResultsPage.SelectFirstListedSearchResult();
        }

        [Then(@"they see the Twitter homepage")]
        public void ThenTheySeeTheTwitterHomePage()
        {
            IWebElement twitterPageContent = twitterPage.driver.FindElement(twitterPage.twitterContentArea); 
            Assert.IsTrue(twitterPageContent.WeElementIsDisplayed());
        }


    }
}