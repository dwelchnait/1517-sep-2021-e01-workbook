using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
#endregion

namespace WestWindSystem.Entities


{
    [Table("Regions")]
    public class Region
    {
        //properties
        //a single property in this class refers to a single attribute
        //      on the sql table
        //Best Practices
        //  use the same attribute name for your property name
        //  order your properties in the same order as your sql table attributes

        [Key]
        public int RegionID { get; set; }
        //add entities validation to the entity class that will run and
        //  automatically check my data is correct
        [Required(ErrorMessage ="Region Description is a required field.")]
        [StringLength(50, ErrorMessage ="Region Description is limited to 50 characters")]
        public string RegionDescription {get;set;}


    }
}
