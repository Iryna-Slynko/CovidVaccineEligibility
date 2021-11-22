using System.ComponentModel.DataAnnotations;

namespace CovidVaccineEligibility
{
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
