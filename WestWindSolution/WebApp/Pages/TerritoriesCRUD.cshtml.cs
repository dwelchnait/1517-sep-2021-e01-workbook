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
    public class TerritoriesCRUDModel : PageModel
    {
        #region Private service fields, FeedBackMessage & constructor (dependency injection)

        private readonly TerritoryServices _territoryservices;


        public TerritoriesCRUDModel(TerritoryServices territoryservices)
        {

            _territoryservices = territoryservices;
        }

        [TempData]
        public string FeedbackMessage { get; set; }
        #endregion

        [BindProperty(SupportsGet = true)]
        public int? regionid { get; set; }

        [BindProperty]
        public List<Territory> territoryInfo { get; set; }

        public void OnGet()
        {
            if (regionid.HasValue)
            {
                //send the argument value to the backend to obtain your data
                //the data will be place in a property that will be bound to 
                //  the output on the web page
                territoryInfo = _territoryservices.Territory_GetForRegion((int)regionid);
            }

        }
    }
}
