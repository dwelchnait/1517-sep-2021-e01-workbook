
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using WestWindSystem.DAL;
using WestWindSystem.Entities;

//this namespace is used in the update and delet
using Microsoft.EntityFrameworkCore.ChangeTracking;
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

        
        public Territory Territory_GetyID(string territoryid)
        {
            return _context.Territories
                            .Where(x => x.TerritoryID.Equals(territoryid))
                            .FirstOrDefault();
        }
        #endregion

        #region Add, Update and Delete (Deactivate)
        public void Territory_Add(Territory item)
        {
            //the return datatype will be one of two possibiiites
            //   void if you are returning no inforemation
            //     this is used when the pkey value is supplied by the user
            //   int if you are return information
            //     this is used when the pkey is an identity key on the database
            //     AND you wish to return that value to the web page for display

            //Since in this example, the user is entering the pkey value
            //   we will validate that the pkey value does not yet exist
            //if the value exists, then the pkey value is going to cause an sql error
            //   thus the add would not be done

            //.Find(pkeyvalue) is a method that will use the incoming value and
            //      by default check the pkey field of each record on the database

            var exist = _context.Territories.Find(item.TerritoryID);
            if (exist != null)
            {
                throw new Exception("Territory ID is already in use. Choose a different ID value");
            }

            //Staging
            //staging is the process of generating the needed command for EntityFramework
            //  to use when the execution of database changes are done
            //this informat information is in local memory, NOT YET sent to the database
            _context.Territories.Add(item);

            //Commit data to database
            //this command is going to cause EntityFramework to start the process of placing
            //  your data onto the database
            //During this process, ANY validaation annotation on your entity is executed
            //   BEFORE the data is sent to the database
            _context.SaveChanges();

            //Identity pkey
            //If you pkey is an identity pkey, where the database generates the pkey value
            //    the incoming instance of your record will be used by EntityFramework to
            //    receive the new pkey value from the database
            //REMEMBER IMPORTANT; this pkey value is NOT available until AFTER the completion
            //  of .SaveChanges()
            //If you successfully add your record to the database, the your instanc pkey field
            //  will contain the new pkey value and you can return the value to your web page
            //In this case, your return datatype should be an int
            
            //return item.pkeyfield;
        }

        public int Territory_Update(Territory item)
        {
            EntityEntry<Territory> updating = _context.Entry(item);
            updating.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            //Commit
            //on the update/delete when .SaveChanges() is executed and does NOT abort
            //  the method will return the number of rows affected.
            return _context.SaveChanges();
        }

        public int Territory_Delete(Territory item)
        {

            //Physical  Delete scenario
            EntityEntry<Territory> deleting = _context.Entry(item);
            deleting.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

            //Deactivate scenario
            //This is a situation where records are NOT phyiscally removed from the database
            //    BUT are flagged as inactive
            //How to recongize
            //   Read your specs
            //   Does the entity have some field that is set to indicate the record is not active
            //       such as Active, Discontinued, termination date
            //What is the solution: do an update

            //item.flaggingField = deactivatevalue;
            //EntityEntry<Territory> deactiviting = _context.Entry(item);
            //deactiviting.State = Microsoft.EntityFrameworkCore.EntityState.Modified;


            //Commit
            //on the update/delete when .SaveChanges() is executed and does NOT abort
            //  the method will return the number of rows affected.
            return _context.SaveChanges();
        }

        #endregion
    }
}
