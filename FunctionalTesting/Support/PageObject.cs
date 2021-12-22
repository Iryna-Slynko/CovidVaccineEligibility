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

        private IWebElement ageField => browserInteractions.WaitAndReturnElement(By.Id("VaccineEligibility_Age"));
        private IWebElement genderField => browserInteractions.WaitAndReturnElement(By.Id("VaccineEligibility_Gender"));

        internal void SetAge(int age)
        {
            ageField.SendKeys(age.ToString());
        }

        internal void GoHome()
        {
            browserInteractions.GoToUrl("https://covidca3.azurewebsites.net/");
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
            SelectElement element = new SelectElement(genderField);
            element.SelectByText(gender);
        }
    }
}
