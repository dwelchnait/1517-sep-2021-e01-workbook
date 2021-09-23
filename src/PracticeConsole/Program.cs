using PracticeConsole.Data;
using System;
using System.Collections.Generic;
//using static System.Console;

namespace PracticeConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            
            List<Employment> jobs = new List<Employment>();

            //declare and load Employment instance separately
            //default constructor
            Employment job1 = new Employment();
            //property set
            job1.Title = "Lab assistance";
            //the Level property has a private set so you cannot directly
            //  assign a value to te Level property
            //Instead, use the method provided which will assign the
            //  given argument value to the Level property internally
            job1.SetEmployeeResponsibility(SupervisoryLevel.TeamLeader);
            job1.Years = 7.4;

            jobs.Add(job1); //add to the jobs List<T> where T is Employment

            //declare and load Employment instance using constructor
            //we can reuse the Employment variable job1 BECAUSE we are creating
            //  a new instance of the Employment class
            //greedy constructor
            job1 = new Employment("Lab Research", SupervisoryLevel.TeamMember, 5.8);
            jobs.Add(job1); //add to the jobs List<T> where T is Employment


            //declare and load Employment instance using object instantiation
            job1 = new Employment()
            {
                Title = "Gander Cooking Club",
                Years = 1.2
            };
            job1.SetEmployeeResponsibility(SupervisoryLevel.Owner);
            jobs.Add(job1); //add to the jobs List<T> where T is Employment

            Person me = new Person()
            {
                FirstName = "don",
                LastName = "welch",
                EmploymentPositions = jobs
            };

            //display the contents of Person
            Console.WriteLine("Person:\n");
            Console.WriteLine($"{me.LastName}, {me.FirstName}: \n");
            Console.WriteLine("Past/Present Employment:\n");
            foreach (Employment item in me.EmploymentPositions)
            {
                Console.WriteLine($"\t{item.ToString()}");
            }

            //using a readonly non static class which can hold data
            //at the time of instanation, you must supply all required value data
            //      to your new instance
            EmploymentReadOnly altJob = new EmploymentReadOnly("Art Director", SupervisoryLevel.Supervisor, 4.5);
            Console.WriteLine($"\n\n*****\nEmployement ReadOnly\n\t{altJob.Title},{altJob.Level},{altJob.Years}\n*****\n");



            Employment badjob;
            Person badperson;
            try
            {
                //badjob = new Employment("testing bads", SupervisoryLevel.TeamMember, 5.8);
                badperson = new Person()
                {
                    FirstName = "don",
                    LastName = "welch"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine($"**********\n{ex.Message}\n**************");
            }
        }
    }
}
