using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    class Employment
    {
        //An instance in this class will describe an employment of a job
        //the characteristics will be
        //  Title, supervisory level, years of employment within that job

        public string Title { get; set; }

        //using an enum to declare a variable
        public SupervisoryLevel Level { get; set; }

        public double Years { get; set; }
    }
}
