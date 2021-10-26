using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

#region Additonal Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly AboutServices _services;

        public BuildVersion dbVersion { get; set; }

        public IndexModel(ILogger<IndexModel> logger, AboutServices services)
        {
            _logger = logger;
            _services = services;
        }

        public void OnGet()
        {
            dbVersion = _services.GetDatabaseVersion();
        }
    }
}
