using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlow.Actions.Selenium;

namespace FunctionalTesting.Support
{
    internal class PageObject
    {
        private readonly IBrowserInteractions browserInteractions;
        private string webAppURL = "https://covidca3.azurewebsites.net/";

        public string WebAppURL { get => webAppURL; internal set
            {
                if (value != null)
                {
                    webAppURL = value;
                }
            }
        }

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
            browserInteractions.GoToUrl(webAppURL);
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
