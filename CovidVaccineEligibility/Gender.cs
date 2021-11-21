using System.ComponentModel.DataAnnotations;

namespace CovidVaccineEligibility
{
    public enum Gender
    {
        Male,
        Female,
        Other,
        [Display(Name = "Don't want to declared")]
        DontWantToDeclare
    }
}
