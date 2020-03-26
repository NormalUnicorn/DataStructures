using System;
using System.Collections.Generic;
using System.Text;

namespace StudentHousing
{
    class Student
    {
        public float StudentQuality { get; set; }
        public int StudentID { get; set; }
        public int StudyYears { get; set; }
        public bool NeedsHouse { get; set; }

        // Function for creating a student using user inputs.
        public Student UserInputStudent(int TotalStudents) 
        {
            Student student = new Student();

            student.StudentQuality = student.StudentQualityInput();
            student.StudyYears = student.StudentYearsInput();
            student.StudentID = GenerateStudentIDCounter(TotalStudents);
            student.NeedsHouse = true;

            Console.WriteLine("You have just created a student with the following attributes: " +
                "\nStudent ID: " + student.StudentID +
                "\nStudent Quality Threashold: " + student.StudentQuality +
                "\nYears of accomodation left: " + student.StudyYears + "\n");

            return student;
        }

        // Function for a user to put in a student years value, with error handling/checking.
        public int StudentYearsInput() 
        {
            bool InputCheck = true;
            int StudentYears = 0;

            while(InputCheck) 
            {
                Console.WriteLine("Please input a value for the number of years this student plans on living at a house for");
                if(int.TryParse(Console.ReadLine(), out StudentYears)) 
                { 
                    if(StudentYears > 0) 
                    {
                        InputCheck = !InputCheck;
                        return StudentYears;
                    }
                    else 
                    {
                        Console.WriteLine("Sorry, the student needs to live somewhere for at least 1 year");
                    }
                }
                else 
                {
                    Console.WriteLine("Sorry, that is not an int");
                }            
            }
            return StudentYears;        
        }

        // Fucntion for a user to put in a student quality value, with error handling/checking.
        public float StudentQualityInput() 
        {
            bool InputCheck = true;
            float StudentQuality = 0;
            while (InputCheck)
            {
                Console.WriteLine("Please input a value for the quality threashold of this student between(but not including) 0 - 1");
                if (float.TryParse(Console.ReadLine(), out StudentQuality))
                {
                    if (StudentQuality > 0 && StudentQuality < 1)
                    {
                        InputCheck = !InputCheck;
                        return StudentQuality;
                    }
                    else 
                    {
                        Console.WriteLine("Sorry, that is not a value between(but not including) 0-1");
                    }
                }
                else 
                {
                    Console.WriteLine("Sorry, that is not a float");
                }                   
            }
            return StudentQuality;
        }

        // Function for creating a student with random year/qualities attributes.
        public Student GenerateStudent(int TotalStudents) 
        {
            Student student = new Student();

            student.StudentID = GenerateStudentIDCounter(TotalStudents);
            student.StudentQuality = (GenerateStudentRandom(1, 1000))/1000.0f;
            student.StudyYears = GenerateStudentRandom(1, 4);
            student.NeedsHouse = true;

            Console.WriteLine("A student has been generated with the following attributes:" +
                "\nStudent ID: " + student.StudentID +
                "\nStudent Quality Threashold: " + student.StudentQuality +
                "\nYears of accomodation left: " + student.StudyYears + "\n");

            return student;
        }

        // Random number generator function.
        public int GenerateStudentRandom(int min, int max) 
        {
            Random newRand = new Random();
            int randQuality = newRand.Next(min, max);

            return randQuality;
        }

        // Function to generate student ID based off number of current students.
        public int GenerateStudentIDCounter(int TotalStudents) 
        {
            int NewStudentID = TotalStudents + 1;
            return NewStudentID;
        }
    }
}
