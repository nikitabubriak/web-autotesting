using System.Linq;
using TechTalk.SpecFlow;
using ProductAutomation.Apis;

namespace RestAutomation.Utils.Hooks
{
    [Binding]
    internal static class FeatureHooks
    {
        [BeforeFeature()]
        internal static void BeforeHooks(FeatureContext featureContext)
        {
            if (featureContext.FeatureInfo.Tags.Contains("Api"))
            {
                BaseApiTests.SetBaseUriAndAuth();
            }
        }
    }
}