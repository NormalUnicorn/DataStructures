using System;
using System.Collections.Generic;

namespace StudentHousing
{
    class Program
    {
        static void Main(string[] args)
        {

            int TotalStudents = 0;
            int TotalHouses = 0;

            Queue<Student> StudentQueue = new Queue<Student>();
            List<House> HouseList = new List<House>();

            bool InputCheck = true;

            int InputValue;


            Console.WriteLine("Hello,  and welcome to the Student Housing Generator, Would you like to: \n" +
                "1 - Input new Students\n" +
                "2 - Input new Houses\n" +
                "3 - Generate a list of random Students\n" +
                "4 - Generate a list of ranom Houses\n" +
                "5 - Print out all the students\n" +
                "6 - Print out all the houses\n" +
                "7 - Start a year, and assign houses to students\n" +
                "8 - Exit Program"
                );


            // Main program loop
            // Asks the user what they wish to do, and handles their input
            // Runs functions based off inputs
            while (InputCheck)
            {
                if (int.TryParse(Console.ReadLine(), out InputValue))
                {

                    Console.WriteLine(InputValue);
                    if ((InputValue > 0 && InputValue < 9))
                    {

                        switch (InputValue)
                        {

                            case (1):
                                StudentQueue.Enqueue(CreateStudent(InputValue, TotalStudents));
                                TotalStudents += 1;
                                break;

                            case (2):
                                HouseList.Add(CreateHouse(InputValue, TotalHouses));
                                TotalHouses += 1;
                                break;

                            case (3):
                                Student newStudent = CreateStudent(InputValue, TotalStudents);
                                StudentQueue.Enqueue(newStudent);
                                TotalStudents += 1;
                                break;

                            case (4):
                                House newHouse = CreateHouse(InputValue, TotalHouses);
                                HouseList.Add(newHouse);
                                TotalHouses += 1;
                                break;

                            case (5):
                                PrintStudents(StudentQueue);
                                break;

                            case (6):
                                PrintHouses(HouseList);
                                break;

                            case (7):
                                StartYear(StudentQueue, HouseList);
                                break;

                            case (8):
                                InputCheck = !InputCheck;
                                break;
                        }
                        //Console.WriteLine("You have input a house with the following quality: " + InputQuality);
                    }
                    else
                    {
                        Console.WriteLine("Sorry that is not a vaild option");
                    }
                }
                else
                {
                    Console.WriteLine("Sorry, That isn't an int");
                }
            }
        }

        // This function takes in all the students and houses
        // It then takes a student and loops through all the houses until the student finds a house they like, in which they move in
        // Or the student denies all the houses and so their quality rating is lowered
        // The school year then ends
        static void StartYear(Queue<Student> StudentQueue, List<House> HouseList)
        {
            if (HouseList.Count <= 0)
            {
                Console.WriteLine("Sorry, there are no houses to allocate students");
            }

            if (StudentQueue.Count <= 0)
            {
                Console.WriteLine("Sorry, there are no students to try to house");
            }

            if (StudentQueue.Count > 0 && HouseList.Count > 0)
            {

                foreach (Student studentApplicant in StudentQueue)
                {
                    
                    Console.WriteLine("");
                    if (studentApplicant.NeedsHouse == true)
                    {
                        for (int i = 0; i < HouseList.Count; i++)
                        {

                            House HouseChoice = HouseList[i];

                            if (HouseChoice.HouseQuality > studentApplicant.StudentQuality && HouseChoice.Occupied == false)
                            {
                                HouseChoice.StudentResident = studentApplicant;
                                studentApplicant.NeedsHouse = false;
                                HouseChoice.Occupied = true;
                                Console.WriteLine("Student: " + studentApplicant.StudentID + " with a quality threshold of: " + studentApplicant.StudentQuality + " has accepted house: " + HouseChoice.HouseID + " with a quality rating of: " + HouseChoice.HouseQuality);

                                break;
                            }

                            else if (HouseChoice.HouseQuality < studentApplicant.StudentQuality && HouseChoice.Occupied == false)
                            {
                                Console.WriteLine("Student: " + studentApplicant.StudentID + " with a quality threshold of: " + studentApplicant.StudentQuality + " has rejected house: " + HouseChoice.HouseID + " with a quality rating of: " + HouseChoice.HouseQuality);
                            }

                            if (i == HouseList.Count - 1 && studentApplicant.NeedsHouse == true)
                            {
                                Console.WriteLine("Student: " + studentApplicant.StudentID + " has rejected all houses with a threshold of " + studentApplicant.StudentQuality + ", so their threshold has been updated to: " + (studentApplicant.StudentQuality * 0.9f));
                                studentApplicant.StudentQuality = studentApplicant.StudentQuality * 0.9f;
                            }
                        }
                    }
                }
                EndYear(HouseList);
            }
        }

        // Only affects houses that are occupied
        static void EndYear(List<House> HouseArray) 
        {
            foreach (House house in HouseArray)
            {
                if (house.Occupied == true)
                {
                    house.YearPassed(house);
                }
            } 
        }
        
        // Prints student information to the console 
        static void PrintStudents(Queue<Student> StudentQueue)
        {
            foreach(Student student in StudentQueue) 
            {
                Console.WriteLine("\nStudent ID: " + student.StudentID + "\nStudent quality threashold: " + student.StudentQuality + "\nYears of study left: " + student.StudyYears + "\n");
            }
        }

        // Prints house information to the console
        static void PrintHouses(List<House> HouseList) 
        { 
            foreach(House house in HouseList) 
            {
                Console.WriteLine("House: " + house.HouseID + "\nHouse Quality: " + house.HouseQuality);

                if(house.Occupied == true) 
                {
                    Console.WriteLine("Student Resident: " + house.StudentResident.StudentID);
                }

                else
                {
                    Console.WriteLine("Unoccupied");
                }
                Console.WriteLine("");
            }
        }

        // Creates a student
        // Uses InputValue to indicate if the student should be user input or randomly generated
        // TotalStudents is used to generate a student ID
        static Student CreateStudent(int InputValue, int TotalStudents) 
        {
            Student student = new Student();

            if(InputValue == 1) 
            {
                student = student.UserInputStudent(TotalStudents);
            }
            else if (InputValue == 3)
            {
                student = student.GenerateStudent(TotalStudents);
            }
            return student;
        }


        // Creates a house
        // Uses InputValue to indicate if the house should be user input or randomly generated 
        // TotalHouses is used to generate a house ID
        static House CreateHouse(int InputValue, int TotalHouses) 
        {
            House house = new House();
            if (InputValue == 2)
            {
                house = house.UserInputHouse(TotalHouses);
            }
            else if (InputValue == 4) 
            {
                house = house.GenerateRandomHouse(TotalHouses);
            }
            return house;
        
        }
    }
}
