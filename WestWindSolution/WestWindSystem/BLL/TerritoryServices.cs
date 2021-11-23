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
    public class TerritoryServices
    {
        #region Context variable & constructor
        private readonly WestWindContext _context;

        internal TerritoryServices(WestWindContext context)
        {
            _context = context;
        }
        #endregion

        #region Queries
        public List<Territory> Territory_GetForRegion(int regionid,
                                                      int pagenumber,
                                                      int pagesize,
                                                      out int totalcount)
        {
            IEnumerable<Territory> info = _context.Territories
                                               .Where(x => x.RegionID == regionid)
                                               .OrderBy(x => x.TerritoryDescription);
            //determine the total collection size of your query
            totalcount = info.Count();
            //determine the number of rows to skip
            //remember the pagenumber is a natural number (1,2,3,4...
            //this needs to be treated as an index (natural number - 1)
            //the number of rows to skip is index * page size
            int skipRows = (pagenumber - 1) * pagesize;
            //remember Linq is a "lazy loader" which basically means
            //   the query is not executed until the data is required
            //   in memory (ToList())
            //therefore, the Skip and Take are done on the sql server
            return info.Skip(skipRows).Take(pagesize).ToList();
        }

        #endregion
    }
}
