using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion


namespace WebApp.Pages
{
    public class PartialFilterSearchModel : PageModel
    {
        #region Private service fields, FeedBackMessage & constructor (dependency injection)

        private readonly RegionServices _regionservices;


        public PartialFilterSearchModel(RegionServices regionservices)
        {

            _regionservices = regionservices;
        }

        [TempData]
        public string FeedbackMessage { get; set; }
        #endregion

       [BindProperty(SupportsGet = true)]
       public string searcharg { get; set; }

        [BindProperty]
        public List<Region> regionInfo { get; set; } 
        
        public void OnGet()
        {
            // check to see if you have an argument value
            if(!string.IsNullOrWhiteSpace(searcharg))
            {
                //send the argument value to the backend to obtain your data
                //the data will be place in a property that will be bound to 
                //  the output on the web page
                regionInfo = _regionservices.Region_GetByPartialDescription(searcharg);
            }
        }

        public IActionResult OnPostByName()
        {
            //check that a value was really placed in the input control
            //if not: give Feedback on requiring a value
            //return the enterd value to OnGet using the POst Redirect Get technique
            if ( string.IsNullOrWhiteSpace(searcharg))
            {
                FeedbackMessage = "Enter a region description before searching";
            }
            return RedirectToPage(new { searcharg = searcharg });
        }
    }
}
