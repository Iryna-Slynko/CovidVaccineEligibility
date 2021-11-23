using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MyNamespace
{
    [Binding]
    public class StepDefinitions
    {
        CovidVaccineEligibility.VaccineEligibility vaccineEligibility;
        public StepDefinitions(ScenarioContext scenarioContext)
        {
        }
        [Given(@"I am (.*)-year old female")]
        public void GivenIAm_YearOldFemale(int age)
        {
            vaccineEligibility = new CovidVaccineEligibility.VaccineEligibility
            {
                Gender = CovidVaccineEligibility.Gender.Female,
                Age = age
            };
        }

        [Then(@"my vaccine is ""(.*)""")]
        public void ThenMyVaccineIs(string vaccineName)
        {
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains(vaccineName), $"'{vaccineEligibility.Vaccine}' does not include {vaccineName}");
        }

        [Given(@"I am (.*)-year old male")]
        public void GivenIAm_YearOldMale(int age)
        {
            vaccineEligibility = new CovidVaccineEligibility.VaccineEligibility
            {
                Gender = CovidVaccineEligibility.Gender.Male,
                Age = age
            };
        }

        [Given(@"I am (.*)-year old")]
        public void GivenIAm_YearOld(int age)
        {
            vaccineEligibility = new CovidVaccineEligibility.VaccineEligibility { Gender = CovidVaccineEligibility.Gender.Other, Age = age };
        }

        [Then(@"my vaccine can be either ""([^""]*)"" or ""([^""]*)""")]
        public void ThenMyVaccineCanBeEitherOr(string vaccine1, string vaccine2)
        {
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains(vaccine1), $"'{vaccineEligibility.Vaccine}' does not include {vaccine1}");
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains(vaccine2), $"'{vaccineEligibility.Vaccine}' does not include {vaccine2}");
        }

        [Then(@"the information does not mention gender")]
        public void ThenTheInformationDoesNotMentionGender()
        {
            Assert.IsFalse(vaccineEligibility.Vaccine.Contains("Other"), $"'{vaccineEligibility.Vaccine}' does include gender");
        }

    }
}