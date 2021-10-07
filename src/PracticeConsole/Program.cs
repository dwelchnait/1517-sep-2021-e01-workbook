using PracticeConsole.Data;  //point to the appropriate namespace
using System;
using System.Collections.Generic;
using System.IO;            //File IO
//using static System.Console;

namespace PracticeConsole
{
    class Program
    {
        private const string ArrayFileName = "IntData.dat";
        private const string CSVFileName = "EmploymentData.dat";

        static void Main(string[] args)
        {
            //ClassObjectReview();
            //ArrayReview();
            int[] inputArray = ReadArrayFile();
            PrintArray(inputArray, inputArray.Length, "File IO input array");
            //CreateEmploymentData();
            ReadCSVFile();
           
        }

        public static void ReadCSVFile()
        {
            string[] fileinput = File.ReadAllLines(CSVFileName);
            List<Employment> employments = new List<Employment>();
            Employment anEmployment = null;
            int badRecordCount = 0;
            foreach(string item in fileinput)
            {
                //Parse the record line into the separate values of an
                //   Employment instance
                //using the same concept of int.Parse, let us create
                //   a .Parse for our developer defined datatype
                //  input will be a string
                //  output will be an instance of Employment
                //because we are using classname.method, the method will
                //  be a static method within the specific classname

                //the .TryParse is the same concept as int.TryParse

                if(Employment.TryParse(item, out anEmployment))
                {
                    employments.Add(anEmployment);
                }
                else
                {
                    badRecordCount++;
                }
                
            }

            Console.WriteLine($"Lines read: good : {employments.Count} bad: {badRecordCount} ");
            foreach(var line in employments)
            {
                Console.WriteLine($"{line.ToString()}");
            }
        }

        public static void CreateEmploymentData()
        {
            List<Employment> employments = new List<Employment>();
            employments.Add(new Employment("Instructor", SupervisoryLevel.TeamLeader, 35.5));
            employments.Add(new Employment("System Developer", SupervisoryLevel.TeamMember, 7.65));
            employments.Add(new Employment("Lab Tech", SupervisoryLevel.TeamMember, 3.5));
            employments.Add(new Employment("Student Advisor", SupervisoryLevel.TeamMember, 3.5));

            List<string> csvlines = new List<string>();
            foreach(var item in employments)
            {
                csvlines.Add(item.ToString());
            }
            //write out all the csv lines
            File.WriteAllLines(CSVFileName, csvlines);
        }

        public static int[] ReadArrayFile()
        {
            //read all the record lines from the input file
            //each line is treated as a string
            //the return datatype of ReadAllLines(filename) is an
            //  array of strings
            string[] fileinput = File.ReadAllLines(ArrayFileName);

            //create an int [] of a specific size
            //create the array with the number of lines read size
            //the array property .Length will indicate the number of lines read
            int[] myArray = new int[fileinput.Length];

            //move string data to int array
            for(int i = 0; i < fileinput.Length; i++)
            {
                //assumption is data in file is valid
                //int is a struct of System.Int32
                // .Parse is a method within the struct
                // calling struct methods require structname.methodname
                myArray[i] = int.Parse(fileinput[i]);
            }
            return myArray;
        }

        public static void ArrayReview()
        {
            //Declare a single-dimensional array size 5
            int lsArray1 = 0;
            int lsArray2 = 0;

            int lsArray3 = 0;

            int[] array1 = new int[5];
            PrintArray(array1, 5, "declare int array size 5");
            lsArray1 = 0;

            //Declare and set array elements
            int[] array2 = new int[] {1, 2, 3, 4, 5 };
            PrintArray(array2, 5, "declare and set int array size 5");
            lsArray2 = 5;

            //alternate syntax
            int[] array3 = { 1, 2, 3, 4, 5 };
            PrintArray(array3, 5, "alternative declare and set int array size 5");
            lsArray3 = 5;

            //add an value to array1
            //compare physical size to logical size, is there room
            if (array1.Length > lsArray1)
            {
                Random rnd = new Random();
                int position = rnd.Next(0, 5);
                array1[position] = 15;
                lsArray1++;
            }
            PrintArray(array1, 5, "declare int array size 5");

            //remove element 3 from array2
            //determine the logic size
            //index of the element to remove
            array2[2] = array2[lsArray2 - 1];
            lsArray2--;
            PrintArray(array2, 5, "declare and set int array size 5");

            string filerecord = "don, 1986, edmonton, ab";
            string[] values = filerecord.Split(',');
            int i = 1;
            Console.WriteLine($"Number of values is {values.Length}");
            foreach(var item in values)
            {
                Console.WriteLine($"item {i} is {item}");
                i++;
            }

        }

        public static void PrintArray(int[] array, int logicalsize, string comment)
        {
            Console.WriteLine($"{comment}\n");
            for (int i = 0; i < logicalsize; i++)
            {
                Console.Write($"{array[i]}, ");
            }
            Console.WriteLine("\n");
        }
        public static void ClassObjectReview()
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
            //source
            //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/how-to-initialize-objects-by-using-an-object-initializer
            //object initializer
            //declaring an instance using object initantiation does so without
            //explicitly invoking a constructor type.
            //The compiler processes object initializers by first accessing the
            //  parameterles instance constructor and then processing the member 
            //  initializations.
            //You must use an object initializer if you are defining an anonymous type
            //
            //this works whether you have explicitly coded constructors in your class
            //  definition or not

            job1 = new Employment
            {
                Title = "Gander Cooking Club",
                Years = 1.2
            };
            job1.SetEmployeeResponsibility(SupervisoryLevel.Owner);
            jobs.Add(job1); //add to the jobs List<T> where T is Employment

            //struct sample
            //remember structs are value types, not reference types
            //can initialize via constructor or object initializer
             ResidentAddress address = new ResidentAddress(123, "Maple St.", null, null, "Edmonton", "AB");
            //ResidentAddress address = new ResidentAddress
            //{
            //    //Number = 123, //when field is readonly in struct definition
            //    Address1 = "Maple St.",
            //    City = "Edmonton",
            //    ProvinceState = "AB"

            //};
               

            Person me = new Person
            {
                FirstName = "don",
                LastName = "welch",
                Address = address, 
                EmploymentPositions = jobs
            };

            //display the contents of Person
            Console.WriteLine("Person:\n");
            Console.WriteLine($"{me.LastName}, {me.FirstName} \n");
            Console.WriteLine($"{me.Address.Number} {me.Address.Address1} \n" +
                $"{me.Address.City}, {me.Address.ProvinceState}");
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
