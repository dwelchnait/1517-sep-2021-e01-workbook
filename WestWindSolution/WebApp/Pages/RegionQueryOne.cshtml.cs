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
    public class RegionQueryOneModel : PageModel
    {
        #region Private service fields, FeedBackMessage & constructor
        
        private readonly RegionServices _regionservices;


        public RegionQueryOneModel(RegionServices regionservices)
        {
            
            _regionservices = regionservices;
        }

        [TempData]
        public string FeedbackMessage { get; set; }
        #endregion

        #region Web Page variable and data
        public Region regionInfo { get; set; }

        [BindProperty(SupportsGet = true)]
        public int? regionid { get; set; }

        public List<Region> RegionList { get; set; }

        [BindProperty]
        public int selectregionid { get; set; }
        #endregion


        public void OnGet()
        {
            //executes when the page first comes up
            //executes on a Post Redirect Get
            //what you want to get as a pattern
            //   the post will receive incoming data, validate and forward to the Get
            //   the get will make the query call and obtain the database information
            if (regionid.HasValue)
            {
                regionInfo = _regionservices.Region_GetByID((int)regionid);
            }

            //this query obtains a list of all the regions on file
            //this query fill the <select> on the web page
            //this query MUST be executed on each refresh of the page
            RegionList = _regionservices.Region_List();
        }

        public IActionResult OnPostByID()
        {
            if (regionid.HasValue && regionid <= 0)
            {
                FeedbackMessage = "Region id values are 1 or greater";
            }
            else if (!regionid.HasValue)
            {
                FeedbackMessage = "Region id was not entered";

            }
            //RedirectToPage will cause the Post Redirect Get response
            return RedirectToPage(new { regionid = regionid});
        }

        public IActionResult OnPostBySelection()
        {
            regionid = selectregionid;
            //the <select> has a prompt line
            //this prompt line is not a valid selection
            //if the returned value from the <select> is the prompt line then
            //  regionid will be 0
            if (selectregionid == 0)
            {
                FeedbackMessage = "Select a region to display";
                regionid = null;
            }
            
            //RedirectToPage will cause the Post Redirect Get response
            return RedirectToPage(new { regionid = regionid });
        }

    }
}
