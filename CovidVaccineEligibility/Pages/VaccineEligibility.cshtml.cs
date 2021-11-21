using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CovidVaccineEligibility.Pages
{
    public class VaccineEligibilityModel : PageModel
    {
        [BindProperty]      // bound on POST request
        public VaccineEligibility vaccineEligibility { get; set; }


        // POST, validate
        public IActionResult OnPost()
        {
            // extra validation (probably not that useful, but might be were additional validation can be added)
            if (vaccineEligibility.Name.Equals(""))
            {
                ModelState.AddModelError("", "You need to enter your name");
            }
            return Page();
        }
    }
}