using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyNamespace
{
    [Binding]
    public class StepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        CovidVaccineEligibility.VaccineEligibility vaccineEligibility;
        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [Given(@"I am (.*)-year old female")]
        public void GivenIAm_YearOldFemale(int age)
        {
            vaccineEligibility = new CovidVaccineEligibility.VaccineEligibility();
            vaccineEligibility.Gender = CovidVaccineEligibility.Gender.Female;
            vaccineEligibility.Age = age;
        }

        [Then(@"my vaccine is ""(.*)""")]
        public void ThenMyVaccineIs(string vaccineName)
        {
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains(vaccineName));
        }
    }
}