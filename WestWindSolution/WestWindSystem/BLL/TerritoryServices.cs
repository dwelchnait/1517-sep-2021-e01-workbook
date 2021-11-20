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
        public List<Territory> Territory_GetForRegion(int regionid)
        {
            IEnumerable<Territory> info = _context.Territories
                                               .Where(x => x.RegionID == regionid)
                                               .OrderBy(x => x.TerritoryDescription);
            return info.ToList();
        }

        #endregion
    }
}
