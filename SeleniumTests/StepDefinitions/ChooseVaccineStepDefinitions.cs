using FunctionalTesting.Support;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace FunctionalTesting.StepDefinitions
{
    [Binding]
    internal sealed class ChooseVaccineStepDefinitions
    {
        private readonly PageObject pageObject;

        public ChooseVaccineStepDefinitions(PageObject pageObject)
        {
            this.pageObject = pageObject;
            pageObject.WebAppURL = TestContext.Parameters["webAppUrl"];
        }

        [Given(@"I am on home page")]
        public void GivenIAmOnHomePage()
        {
            pageObject.GoHome();
        }

        [When(@"I submit the form")]
        public void WhenISubmitTheForm()
        {
            pageObject.SubmitForm();
        }

        [Then(@"I see ""([^""]*)""")]
        public void ThenISee(string text)
        {
            Assert.IsTrue(pageObject.SeeTheText(text));
        }

        [When(@"I set my age to (.*)")]
        public void WhenISetMyAgeTo(int age)
        {
            pageObject.SetAge(age);
        }

        [When(@"I choose ""([^""]*)"" as my gender")]
        public void WhenIChooseAsMyGender(string gender)
        {
            pageObject.SetGender(gender);
        }
    }
}
