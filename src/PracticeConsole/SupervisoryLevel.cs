using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    //SupervisoryLevel is the data type name of the enum  
    //the data type of an enum is a whole number: default type of int
    public enum SupervisoryLevel
    {
        Entry,          // = 0
        TeamMember,     // = 1
        TeamLeader,     // = 2
        Supervisor,     // = 3
        DepartmentHead, // = 4
        Owner           // = 5
    }
}
