using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


#region Additional Namespaces
using WestWindSystem.Entities;
using WestWindSystem.BLL;
#endregion

namespace WebApp.Pages
{
    public class CRUDPageModel : PageModel
    {
        #region Private service fields, FeedBackMessage & constructor (dependency injection)

        private readonly TerritoryServices _territoryservices;
        private readonly RegionServices _regionservices;


        public CRUDPageModel(TerritoryServices territoryservices,
                            RegionServices regionservices)
        {

            _territoryservices = territoryservices;
            _regionservices = regionservices;
        }

        [TempData]
        public string FeedbackMessage { get; set; }

        public bool HasFeedback => !string.IsNullOrWhiteSpace(FeedbackMessage);

        [TempData]
        public string ErrorMessage { get; set; }

        public bool HasError => !string.IsNullOrWhiteSpace(ErrorMessage);
        #endregion

        [BindProperty(SupportsGet =true)]
        public string territoryid { get; set; }

        // this holds the territory record we are maintaining
        // this is a two way passage of data
        // on the OnPost event (Request) the system will fill your Bound Property
        //    with the current contents of the data fields
        [BindProperty]
        public Territory territoryInfo { get; set; }

        [BindProperty]
        public List<Region> regionInfo { get; set; }

        public void OnGet()
        {
            if (!string.IsNullOrWhiteSpace(territoryid))
            {
                territoryInfo = _territoryservices.Territory_GetyID(territoryid);
            }
            regionInfo = _regionservices.Region_List();
        }

        public IActionResult OnPostAdd()
        {
            //this has to be done in a user freindly error handling environment
            try
            {
                // call the appropriate TerritoryService to attempt to add the
                //    data to the database
                FeedbackMessage = "Teritory has been added";
                return RedirectToPage(new { territoryid = territoryid });
            }
            catch (Exception ex)
            {
                ErrorMessage = GetInnerException(ex).Message;
                regionInfo = _regionservices.Region_List(); //retreive data for the dropdownlist
                return Page(); //Page IS NOT the same as RedirectToPage, does not go to OnGet
            }

        }
        public IActionResult OnPostUpdate()
        {
            //this has to be done in a user freindly error handling environment
            try
            {
                // call the appropriate TerritoryService to attempt to update the
                //    data on the database
                FeedbackMessage = "Territory has been updated";
                return RedirectToPage(new { territoryid = territoryid });
            }
            catch (Exception ex)
            {
                ErrorMessage = GetInnerException(ex).Message;
                regionInfo = _regionservices.Region_List(); //retreive data for the dropdownlist
                return Page(); //Page IS NOT the same as RedirectToPage, does not go to OnGet
            }

        }

        public IActionResult OnPostRemove()
        {
            
            //this has to be done in a user freindly error handling environment
            try
            {
                // call the appropriate TerritoryService to attempt to remove the
                //    data from the database
                FeedbackMessage = "Territory has been removed";
                return RedirectToPage(new { territoryid = "" });
            }
            catch (Exception ex)
            {
                ErrorMessage = GetInnerException(ex).Message;
                regionInfo = _regionservices.Region_List(); //retreive data for the dropdownlist
                return Page(); //Page IS NOT the same as RedirectToPage, does not go to OnGet
            }
            
        }

        public IActionResult OnPostClear()
        {
            

            return RedirectToPage(new { territoryid = ""});
        }
        public IActionResult OnPostBack()
        {
            return RedirectToPage("/PartialFilterSearch");
        }

        private Exception GetInnerException(Exception ex)
        {
            //drill down to the REAL ERROR MESSAGE
            while (ex.InnerException != null)
                ex = ex.InnerException;
            return ex;
        }
    }
}
