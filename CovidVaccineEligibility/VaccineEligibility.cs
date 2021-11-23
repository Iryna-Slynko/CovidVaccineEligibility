using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace CovidVaccineEligibility
{
    /// <summary>
    /// Class to present to the Internet.
    /// </summary>
    public class VaccineEligibility
    {
        public const int AgeMin = 12;
        public const int AgeMax = 110;

        public string Name { get; set; }

        public Gender Gender { get; set; }

        [Range(AgeMin, AgeMax, ErrorMessage = "Invalid age - Vaccine Only Available from 12 to 110")]
        public int Age { get; set; }

        // calculate which vaccine is most suitable
        /*
         * Which Vaccine: Based on the details entered, use the table
         * below to determine which vaccine the person is most likely to get.
         *
        Age Gender      Vaccine
        >50     Male    AstraZeneca
        >50     Female  Pfizer
        >35     Male    AstraZeneca
        >35     Female  Pfizer
        >20     Male    Johnson & Johnson
        >20     Female  AstraZeneca
        <20     All     Johnson & Johnson
         */

        public string Vaccine
        {
            get
            {
                SuitableVaccines vaccine;
                if (this.Age > 35 && this.Gender.Equals(Gender.Male))
                {
                    vaccine = SuitableVaccines.AstraZeneca;
                }
                else if (this.Age > 35 && this.Gender.Equals(Gender.Female))
                {
                    vaccine = SuitableVaccines.Pfizer;
                }
                else if (this.Age > 20 && this.Gender.Equals(Gender.Male))
                {
                    vaccine = SuitableVaccines.JohnsonAndJohnson;
                }
                else if (this.Age > 20 && this.Gender.Equals(Gender.Female))
                {
                    vaccine = SuitableVaccines.AstraZeneca;
                }
                else
                {
                    vaccine = SuitableVaccines.JohnsonAndJohnson;
                }

                // based on https://stackoverflow.com/questions/13099834/how-to-get-the-display-name-attribute-of-an-enum-member-via-mvc-razor-code
                string vaccineDisplayName = vaccine.GetType().GetMember(vaccine.ToString())[0].GetCustomAttribute<DisplayAttribute>().Name;
                return $"You are {Age} and {Gender}. {vaccineDisplayName} is the most suitable vaccine for you.";
            }
        }
    }
}
