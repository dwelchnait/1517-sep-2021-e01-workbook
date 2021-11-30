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
        #endregion

        [BindProperty(SupportsGet =true)]
        public string territoryid { get; set; }

        // this holds the territory record we are maintaining
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
            //TODO: a comment in Add
            return Page();
        }
        public IActionResult OnPostUpdate()
        {
            //TODO: a comment in update
            return Page();
        }

        public IActionResult OnPostRemove()
        {
            //TODO: a comment in remove
            return Page();
        }

        public IActionResult OnPostClear()
        {
            //TODO: a comment in clear
            return Page();
        }
    }
}
