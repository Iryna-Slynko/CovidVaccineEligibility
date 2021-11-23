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
            VaccineEligibility vaccineEligibility = new()
            {
                Age = 12,
                Gender = Gender.Female
            };

            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Johnson"));
            vaccineEligibility.Age = 12;
            vaccineEligibility.Gender = Gender.Male;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Johnson"));
        }

        [TestMethod()]
        public void GetVaccineTestForFemales()
        {
            VaccineEligibility vaccineEligibility = new()
            {
                Gender = Gender.Female,
                Age = 21
            };
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("AstraZeneca"), "*" + vaccineEligibility.Vaccine + "* should contain AstraZeneca");
            vaccineEligibility.Age = 36;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Pfizer"));
            vaccineEligibility.Age = 55;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Pfizer"));
        }

        [TestMethod()]
        public void GetVaccineTestForMales()
        {
            VaccineEligibility vaccineEligibility = new();

            vaccineEligibility.Gender = Gender.Male;
            vaccineEligibility.Age = 21;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Johnson"));
            vaccineEligibility.Age = 36;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("AstraZeneca"));
            vaccineEligibility.Age = 55;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("AstraZeneca"));
        }

        [TestMethod()]
        public void GetVaccineTestForOther()
        {
            VaccineEligibility vaccineEligibility = new();

            vaccineEligibility.Gender = Gender.Other;
            vaccineEligibility.Age = 15;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Johnson"));
            vaccineEligibility.Age = 21;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("AstraZeneca"));
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Johnson"));
            vaccineEligibility.Age = 55;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("AstraZeneca"));
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Pfizer"));
        }

        [TestMethod()]
        public void GetVaccineTestForUndeclaredGender()
        {
            VaccineEligibility vaccineEligibility = new();

            vaccineEligibility.Gender = Gender.DontWantToDeclare;
            vaccineEligibility.Age = 15;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Johnson"));
            vaccineEligibility.Age = 21;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("AstraZeneca"));
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Johnson"));
            vaccineEligibility.Age = 55;
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("AstraZeneca"));
            Assert.IsTrue(vaccineEligibility.Vaccine.Contains("Pfizer"));
        }
    }
}