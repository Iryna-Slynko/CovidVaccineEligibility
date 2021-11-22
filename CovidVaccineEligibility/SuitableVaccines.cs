using System.ComponentModel.DataAnnotations;

namespace CovidVaccineEligibility
{
    /*
     * Which Vaccine: Based on the details entered, use the table
     * below to determine which vaccine the person is most likely to get.
     *
    Age     Gender      Vaccine
    >50     Male        AstraZeneca
    >50     Female      Pfizer
    >35     Male        AstraZeneca
    >35     Female      Pfizer
    >20     Male        Johnson & Johnson
    >20     Female      AstraZeneca
    <20     All         Johnson & Johnson
     */
    public enum SuitableVaccines
    {
        [Display(Name = "AstraZeneca")]
        AstraZeneca = 0,
        [Display(Name = "Pfizer")]
        Pfizer = 1,
        [Display(Name = "Johnson & Johnson")]
        JohnsonAndJohnson = 2,
    }
}
