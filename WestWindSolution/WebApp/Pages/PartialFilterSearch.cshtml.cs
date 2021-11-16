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
        #region Private service fields, FeedBackMessage & constructor

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
        }
    }
}
