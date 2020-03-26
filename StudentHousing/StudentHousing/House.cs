using System;
using System.Collections.Generic;
using System.Text;

namespace StudentHousing
{
    class House
    {
        public float HouseQuality { get; set; }
        public int HouseID { get; set; }
        public bool Occupied { get; set; }
        public Student StudentResident { get; set; }

        // Function for a year to end 
        // If a house is occupied, the occupant completes a year of study and moves out if they have finished all their years of study
        public House YearPassed(House House) 
        {
            if (House.Occupied)
            {
                House.StudentResident.StudyYears -= 1;

                if (House.StudentResident.StudyYears < 1)
                {
                    Console.WriteLine("Student: " + House.StudentResident.StudentID + " has finished their studies and has no need for a house");
                    House.StudentResident = null;
                    Occupied = false;
                    return House;
                }
            }
                return House;
        }

        public House UserInputHouse(int TotalHouses) 
        {
            House UserInputHouse = new House();
            UserInputHouse.HouseID = UserInputHouse.GenerateHouseID(TotalHouses);
            bool InputCheck = true;
            float InputQuality;
            UserInputHouse.Occupied = false;

            while(InputCheck) 
            { 
            Console.WriteLine("Please input the Quality of this House(A value between, but not including 0-1)");
                if (float.TryParse(Console.ReadLine(), out InputQuality))
                {
                    if ((InputQuality > 0.0f && InputQuality < 1.0f))
                    {
                        InputCheck = !InputCheck;
                        UserInputHouse.HouseQuality = InputQuality;
                    }
                    else 
                    {
                        Console.WriteLine("Sorry that is not a vaild float between 0-1");
                    }
                }
                else 
                {
                    Console.WriteLine("Sorry, That isn't a float");
                }
            }
            Console.WriteLine("You have just created a house with the following attributes: " +
                "\nHouse ID: " + UserInputHouse.HouseID +
                "\nHouse Quality: " + UserInputHouse.HouseQuality + "\n");

            return UserInputHouse;
        }

        // Creates a random house
        public House GenerateRandomHouse(int TotalHouses) 
        {
            House house = new House();
            house.HouseQuality = house.GenerateHouseQualityRandom()/1000.0f;
            house.HouseID = house.GenerateHouseID(TotalHouses);
            house.Occupied = false;
            Console.WriteLine("A house has been generated with the following attributes: " +
                "\nHouse ID: " + house.HouseID +
                "\nHouse Quality: " + house.HouseQuality + "\n");
            return house;
        }

        // Generates a random Quality value 
        public float GenerateHouseQualityRandom() 
        {
            Random rand = new Random();
            float randomQuality = rand.Next(1, 1000);
            return randomQuality;
        }

        // Generates a house ID
        public int GenerateHouseID(int TotalHouses) 
        {
            int NewHouseID = TotalHouses += 1;
            return NewHouseID;
        }
    }
}
