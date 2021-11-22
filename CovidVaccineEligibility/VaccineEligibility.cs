using System;
using System.ComponentModel.DataAnnotations;

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
                string message;
                if (this.Age > 35 && this.Gender.Equals(Gender.Male))
                {
                    message = SuitableVaccines.AstraZeneca + " is the most suitable vaccine for you.";
                }
                else if (this.Age > 35 && this.Gender.Equals(Gender.Female))
                {
                    message = SuitableVaccines.Pfizer + " is the most suitable vaccine for you.";
                }
                else if (this.Age > 20 && this.Gender.Equals(Gender.Male))
                {
                    message = SuitableVaccines.JohnsonAndJohnson + " is the most suitable vaccine for you.";
                }
                else if (this.Age > 20 && this.Gender.Equals(Gender.Female))
                {
                    message = $"{SuitableVaccines.AstraZeneca} is the most suitable vaccine for you.";
                }
                else
                {
                    message = $"{SuitableVaccines.JohnsonAndJohnson} is the most suitable vaccine for you.";
                }

                return $"You are {Age} and {Gender}. {message}";
            }
        }
    }
}
