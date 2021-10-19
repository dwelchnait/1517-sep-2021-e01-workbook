using System;
using System.Collections.Generic;
using System.Linq;
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

        //contructors


        //behaviours (aka methods)
        public void OnGet()
        {
            //Default Request is OnGet(),
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
    }
}
