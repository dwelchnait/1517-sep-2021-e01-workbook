using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


#region Additional Namespaces
using WestWindSystem.BLL;
using WestWindSystem.Entities;
#endregion

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        #region Private service fields, FeedBackMessage & constructor
        private readonly ILogger<IndexModel> _logger;
        private readonly WestWindServices _westwindservices;


        /*
         * Services that are registered using AddTransient<>() 
         *    can be access on the constructor of the web page class
         * This is referred to as Dependency Injection
         * Each services that is injections is listed on the constructor
         *    as a parameter
         * ILogger is a service from Microsoft Logging extensions
         * 
         * We need to add our required service(s) to this page
         * Our services will be known by the BLL class name
         * 
         * When you add a service to the page, you will save the
         *    service reference in a private readonly field
         * This variable will be available to all methods within 
         *    this class
         */
        public IndexModel(ILogger<IndexModel> logger,
                            WestWindServices westwindservices)
        {
            _logger = logger;
            //save your incoming service registration to your
            //    private readonly variable
            _westwindservices = westwindservices;
        }

        [TempData]
        public string FeedbackMessage { get; set; }
        #endregion

        #region Web Page variable and data
        public BuildVersion buildVersion { get; set; }
        #endregion

        //remember OnGet() executes as the page comes up
        public void OnGet()
        {
            /*
             * to obtain data to display to your page should be done
             *    in the OnGet()
             */
            //call the GetBuildVersion() registers in the WestWindServices
            //input: none  output: instance of BuildVersion
            buildVersion = _westwindservices.GetBuildVersion();
        }
    }
}
