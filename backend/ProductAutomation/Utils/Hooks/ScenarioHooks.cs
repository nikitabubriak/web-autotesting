using System.Linq;
using TechTalk.SpecFlow;
using ProductAutomation.Apis;

namespace RestAutomation.Utils.Hooks
{
    [Binding]
    internal static class ScenarioHooks
    {
        [BeforeScenario()]
        internal static void BeforeHooks(ScenarioContext scenarioContext)
        {
            if (scenarioContext.ScenarioInfo.Tags.Contains("Api"))
            {
                BaseApiTests.SetBaseUriAndAuth();
            }
        }
    }
}