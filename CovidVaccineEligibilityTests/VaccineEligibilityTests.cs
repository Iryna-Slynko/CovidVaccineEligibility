using Microsoft.VisualStudio.TestTools.UnitTesting;
using CovidVaccineEligibility;
using System;
using System.Collections.Generic;
using System.Text;

namespace CovidVaccineEligibility.Tests
{
    [TestClass()]
    public class VaccineEligibilityTests
    {
        [TestMethod()]
        public void GetVaccineTestForChildren()
        {
            VaccineEligibility vaccineEligibility = new VaccineEligibility();

            vaccineEligibility.Age = 12;
            vaccineEligibility.Gender = Gender.Female;

            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Johnson"));
            vaccineEligibility.Age = 12;
            vaccineEligibility.Gender = Gender.Male;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Johnson"));
        }

        [TestMethod()]
        public void GetVaccineTestForFemales()
        {
            VaccineEligibility vaccineEligibility = new VaccineEligibility();

            vaccineEligibility.Gender = Gender.Female;
            vaccineEligibility.Age = 21;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("AstraZeneca"), "*" + vaccineEligibility.Vaccine + "* should contain AstraZeneca");
            vaccineEligibility.Age = 36;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Pfizer"));
            vaccineEligibility.Age = 55;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Pfizer"));
        }

        [TestMethod()]
        public void GetVaccineTestForMales()
        {
            VaccineEligibility vaccineEligibility = new VaccineEligibility();

            vaccineEligibility.Gender = Gender.Male;
            vaccineEligibility.Age = 21;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Johnson"));
            vaccineEligibility.Age = 36;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("AstraZeneca"));
            vaccineEligibility.Age = 55;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("AstraZeneca"));
        }
    }
}