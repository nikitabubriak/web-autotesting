using OpenQA.Selenium;

namespace ProductAutomation.Pages
{
    public class TwitterPage : SearchResultsPage
    {
        public By twitterContentArea = By.Id("react-root");
    }
}