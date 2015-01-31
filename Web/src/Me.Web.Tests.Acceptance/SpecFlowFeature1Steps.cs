using System;
using TechTalk.SpecFlow;

namespace Me.Web.Tests.Acceptance
{
    // MVC Tests: https://github.com/aspnet/Mvc/tree/f94bd534642d43ac6279df100946876b8ae21bc3/test/Microsoft.AspNet.Mvc.FunctionalTests
    [Binding]
    public class SpecFlowFeature1Steps
    {
        [Given(@"I have entered (.*) into the calculator")]
        public void GivenIHaveEnteredIntoTheCalculator(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
