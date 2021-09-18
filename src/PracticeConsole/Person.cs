using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeConsole.Data
{
    public class Person
    {
        //each instance of this class will represent an individual
        //This class will define the following characteristics of a person
        //  First Name, Last Name, list of employment positions

        //This class definition is an example of class Composition

        private string _FirstName;
        private string _LastName;

        public string FirstName
        {
            get { return _FirstName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Peron first name is required");
                }
                else
                {
                    _FirstName = value;
                }
            }
        }

        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Peron last name is required");
                }
                else
                {
                    _LastName = value;
                }
            }
        }

        //List<Employment> property
        //this is an example of a Composition class property
        //this property makes use of another programmer-declared class data type: Employment
        //one could have many properties within your class definition that uses
        //   multiple different programmer-declared class data types
        //this differs from the concept of inheritance where the class definition is extended to
        //   another class
        //inheritance syntax appears on the class declarative
        //   example assume a class call Transportation (fuel, motor, fuelusage)
        //           assume types of transportation: Vehicle, Bike, Boat, ..
        //           public class Vehicle : Transportation
        //           public class Bike : Transportation
        //           public class Boat : Transportation
        //In addition to the unique properties within Vehicle, Bike, Boat the class definition is
        //      extended to also have access to the Transportation class.
        public List<Employment> EmploymentPositions { get; set; }

        public Person() { }

        public Person(string firstname, string lastname, List<Employment> positions)
        {
            FirstName = firstname;
            LastName = lastname;
            EmploymentPositions = positions;
        }
    }
}
