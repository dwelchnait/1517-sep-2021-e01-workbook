using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


#region Additional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
using WebApp.Helpers;
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

        #region Paginator
        //my desired page size
        private const int PAGE_SIZE = 5;
        //instance of the Paginator
        public Paginator Pager { get; set; }
        #endregion

        public void OnGet(int? currentPage)
        {
            if (regionid.HasValue)
            {
                //using the Paginator with your query

                //OnGet will have an parameter (Request query string) the receives the current page
                //   number. On the initial load of the page, this value will
                //   be null.

                //determine the ccurrent pagenumber
                int pagenumber = currentPage.HasValue ? currentPage.Value : 1;
                //setup the current stae of the paginator (sizing)
                PageState current = new(pagenumber, PAGE_SIZE);
                //temporary int to hold the results of the query's total collection size
                int totalcount;

                //we need to pass paging data into our query so that efficiencies in the system
                //   will only return the amount of records to actually
                //   be display on the browser page
                territoryInfo = _territoryservices.Territory_GetForRegion((int)regionid, pagenumber, PAGE_SIZE,
                    out totalcount);

                //set the paginator instance
                Pager = new Paginator(totalcount, current);
            }

        }

        public IActionResult OnPost()
        {
            return Redirect("/CRUDPage");
        }
    }
}
