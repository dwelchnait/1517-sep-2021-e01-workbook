using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


#region Additinal 
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class WestWindServices
    {
        //I need an instance of he WestWindContext class
        private readonly WestWindContext _context;

        //I need a constructor of this class to initialize my instance of WestWindContext
        internal WestWindServices(WestWindContext context)
        {
            _context = context;
        }

        //create a method (service) that will retrieve the BuildVersion record
        //this will be called from the web app, thus it needs to be public
        //this comes part of the class library's (application library) public interface
        public BuildVersion GetBuildVersion()
        { 
            //going to your context instance, calling on the DbSet  property,
            // which will retrieve your data from the database, then return
            // the First record from the database collection (set, dataset) OR
            // if not data was returned from sql, set the receiving variable to null.
            BuildVersion info = _context.BuildVersions.FirstOrDefault();
            return info;
        }
    }
}
