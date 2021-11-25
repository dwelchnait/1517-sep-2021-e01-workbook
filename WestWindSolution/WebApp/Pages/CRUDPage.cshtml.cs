using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class CRUDPageModel : PageModel
    {
        [BindProperty(SupportsGet =true)]
        public int? territoryid { get; set; }

        public void OnGet()
        {
        }
    }
}
