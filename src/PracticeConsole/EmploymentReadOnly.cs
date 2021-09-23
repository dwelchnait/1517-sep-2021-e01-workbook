using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    public class EmploymentReadOnly
    {
        public readonly string Title;
        public readonly SupervisoryLevel Level;
        public readonly double Years;

        //in a readonly class scenario you will not likely find any
        //   property that will allow internal data to be altered via the property.
        //you may find behaviours that will allow changes to the data, remembering
        //   that internal logic can make changes
        //however, you still may have properties in your class definition BUT they
        //   consists of only get components in the property

        //becasue your data is read only, you need to have a pathway
        //   for data to come into the class instance

        //one use a greedy constructor
        public EmploymentReadOnly(string title, SupervisoryLevel level, double years)
        {
            //validation that would normally exist in your Property will NOW
            //  be code in the constructor
            //In this example, you will be using a method from a static class that
            //  we have coded called Utilities
            if (Utilities.IsEmpty(title))
            {
                throw new Exception("Job title is required.");
            }
            else
            {
                Title = title;
            }
            Level = level;
            if (Utilities.IsPositive(years))
            {
                Years = years;

            }
            else
            {
                throw new Exception("Job years needs to be 0 or greater.");

            }
            
        }

       
    }
}
