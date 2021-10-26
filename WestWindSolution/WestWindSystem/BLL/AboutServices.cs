using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;
#endregion

namespace WestWindSystem.BLL
{
    public class AboutServices
    {
        private readonly WestWindContext _context;

        internal AboutServices(WestWindContext context)
        {
            _context = context;
        }

        public BuildVersion GetDatabaseVersion()
        {
            BuildVersion results = _context.BuildVersions
                                    .Select(x => x)
                                    .FirstOrDefault();
            return results;
        }
    }
}
