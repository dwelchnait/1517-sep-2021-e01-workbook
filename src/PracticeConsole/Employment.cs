using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    public class Employment
    {
        //An instance in this class will describe an employment of a job
        //the characteristics will be
        //  Title, supervisory level, years of employment within that job

        //the 4 components of a class are
        //  data field 
        //  property
        //  constructor
        //  behaviour (aka method)

        //data field
        //this is a storage area in your program
        //this is a variable

        //a declared storage area that will be associated with the Title property
        //normally this delcaration is a private access type
        //one does NOT want an outsider user to directly interact with the variable
        private string _Title;

        //Properties
        //These are access techniques to retrieve or set data in your class without
        //  directly touch the storage data field

        // fully implemented property
        //  a) a declare storage area (data field)
        //  b) declare the property signature
        //  c) code an get "method"
        //  d) optionally code a set "method"

        public string Title {
            get 
            {
                // accessor
                //the get "method" will return the contents of a data field(s) as an expression
                return _Title;
            }
            set 
            { 
                //mutator
                //the set "method" receives an incoming value and places it in the associate data field
                //during the set method, you might wish to validate the incoming data for correctess
                //during the set method, you might wish to do some type of logically processing against
                //      the incoming data
                //the incoming piece of data is referred to using the keyword "value"

                //ensure that the incoming is not null or empty
                if (string.IsNullOrEmpty(value))
                {
                    throw new Exception("Title is a required piece of data.");
                }
                else
                {
                    _Title = value;
                }
            } 
        }

        //using an enum to declare a variable
        public SupervisoryLevel Level { get; set; }

        public double Years { get; set; }
    }
}
