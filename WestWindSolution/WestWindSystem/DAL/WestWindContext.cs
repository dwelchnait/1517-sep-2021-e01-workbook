
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.EntityFrameworkCore;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.DAL
{
    internal class WestWindContext:DbContext
    {
        public WestWindContext()
        {

        }

        //options? things like DatabaseProvider(MSQL | Oracle)
        //                     what is the connection string
        //                      what type of Authorization
        //                      that is the name of the database
        //this Dependency injection is to help us "externalize" our reliance on objects
        //      that are "out-of-scope" of your code
        //example wheels on a car are attached by bolts so they can be change if needed
        //         (software updates).
        //Consider if the wheels wer welded to your axils. How difficult would it be
        //      to change the tires {update software).
        //the options can have the necessary values to context our system to the
        //      software in the EntityFramework which is responsible for the actually
        //      transfer of data from sql to the program and back.
        public WestWindContext(DbContextOptions<WestWindContext> options) : base(options)
        {

        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<BuildVersion> BuildVersions { get; set; }
    }
}
