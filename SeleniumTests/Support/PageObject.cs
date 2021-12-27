using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlow.Actions.Selenium;

namespace FunctionalTesting.Support
{
    internal class PageObject
    {
        private readonly IBrowserInteractions browserInteractions;

        public PageObject(IBrowserInteractions browserInteractions)
        {
            this.browserInteractions = browserInteractions;
        }

        internal void SetAge(int age)
        {
            browserInteractions.WaitAndReturnElement(By.Id("VaccineEligibility_Age")).SendKeys(age.ToString());
        }

        internal void GoHome()
        {
            string? url = Environment.GetEnvironmentVariable("INTEGRATION_TEST_URL");
            if (url == null) {
                url = "https://covidca3.azurewebsites.net/";
            }
            browserInteractions.GoToUrl(url);
        }

        internal void SubmitForm()
        {
            browserInteractions.WaitAndReturnElement(By.ClassName("btn")).Click();
        }

        internal bool SeeTheText(string text)
        {
            var body = browserInteractions.WaitAndReturnElement(By.TagName("body"));
            return body.Text.Contains(text);
        }

        internal void SetGender(string gender)
        {
            SelectElement element = new(browserInteractions.WaitAndReturnElement(By.Id("VaccineEligibility_Gender")));
            element.SelectByText(gender);
        }
    }
}
