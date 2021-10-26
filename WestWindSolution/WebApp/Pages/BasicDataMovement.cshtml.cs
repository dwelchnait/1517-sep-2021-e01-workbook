using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages
{
    public class BasicDataMovementModel : PageModel
    {
        //data members
        public string MyName;

        //properties

        [TempData]
        public string FeedbackMessage { get; set; }

        [BindProperty(SupportsGet =true)]
        public int? id { get; set; }

        [BindProperty]
        public string selection { get; set; }

        //contructors


        //behaviours (aka methods)
        public void OnGet()
        {
            //events
            //Default Request event is OnGet(),
            //executed each time the page is enterd and/or refreshed
            //  if no form post with a RedirecToPage()
            Random rdn = new Random();
            int oddeven = rdn.Next(0, 25);
            if (oddeven % 2 == 0)
            {
                MyName = $"Don is {oddeven}";
            }
            else
            {
                MyName = null;
            }
        }

        //Request method: 
        //handle post methods from forms
        //public IActionResult OnPost()
        //{
        //    Thread.Sleep(2000);
        //    string buttonvalue = Request.Form["theButton"];
        //    if(buttonvalue.Equals("A"))
        //    {
        //        //use a asp page handler to get to the logic for
        //        //   this true path
        //    }
        //    else if (buttonvalue.Equals("B"))
        //    {

        //    }
        //    else
        //    {

        //    }
        //    FeedbackMessage = buttonvalue;
        //    //the RedirectToPage will cause the OnGet to execute
        //    return RedirectToPage();
        //}

        //if you have a handler on the submit button AND name your
        //   event method using OnPostxxxxx where xxxxx is the asp-page-handler
        //   then this method will be executed instead of the general OnPost
        //
        // this method (event) logic is dedicated to the action required
        //    by the pressed button
        public IActionResult OnPostAButton()
        {
            Thread.Sleep(1000);
            //string buttonvalue = Request.Form["theButton"];
            FeedbackMessage = $"You pressed the A Button, input was {id}";
            //the RedirectToPage will cause the OnGet to execute
            //we will create an anonymous object and assign the disired value
            //  to the object
            return RedirectToPage(new { id = id});
        }

        public IActionResult OnPostBButton()
        {
            Thread.Sleep(1000);
            //string buttonvalue = Request.Form["theButton"];
            FeedbackMessage = $"You pressed the B Button, selection was {selection}";
            //the RedirectToPage will cause the OnGet to execute
            return RedirectToPage(new { id = id });
        }
    }
}
