using FunctionalTesting.Support;
using System;
using TechTalk.SpecFlow;

namespace SeleniumTests.StepDefinitions
{
    [Binding]
    internal class PrivacyPolicyStepDefinitions
    {
        private readonly PageObject pageObject;

        internal PrivacyPolicyStepDefinitions(PageObject pageObject)
        {
            this.pageObject = pageObject;
        }

        [When(@"I click on ""([^""]*)""")]
        internal void WhenIClickOn(string text)
        {
            pageObject.ClickOn(text);
        }
    }
}
