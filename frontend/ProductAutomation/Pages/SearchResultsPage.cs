using OpenQA.Selenium;
using ProductAutomation.Utils.Extensions;

namespace ProductAutomation.Pages
{
    public class SearchResultsPage : BasePage
    {
        public By SearchResultsContainer => By.Id("rcnt");
        public By SearchResultLinks => By.CssSelector("h3");

        public TwitterPage SelectFirstListedSearchResult()
        {
            SearchResultLinks.WdClickByIndex(0);
            return new TwitterPage();
        }
    }
}