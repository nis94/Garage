using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.ConsoleUI
{
    public class GarageMenu
    {
        private readonly GarageLogic.GarageManager m_GarageManager = new GarageLogic.GarageManager();
        private const int k_Yes = 1;
        private const int k_No = 2;


        internal void RunMenu()
        {
            const bool k_IsUserChoseExit = true;
            const int k_MinMenuOption = 1;
            const int k_MaxMenuOption = 8;

            Console.WriteLine("---WELLCOME TO THE AMAZING GARAGE---");
            while (k_IsUserChoseExit == true)
            {
                string i_Menu = string.Format(@" 
1. Add New Vehicle 
2. View Filtered Vehicle List
3. Change Vehicle Status
4. Pump Vehicle Wheels
5. ReFuel Vehicle
6. ReCharge Vehicle
7. View Vehicle Details
8. Exit Garage
Please select one of the options by entering the representing number: ");
                Console.WriteLine(i_Menu);
                string userInput = Console.ReadLine();
                bool isValid = int.TryParse(userInput, out int chosenNumber);
                if (isValid == true)
                {
                    isValid = chosenNumber >= k_MinMenuOption && chosenNumber <= k_MaxMenuOption;
                }
                while (isValid == false)
                {
                    Console.WriteLine("Invalid input! Please choose a number from the menu again");
                    userInput = Console.ReadLine();
                    isValid = int.TryParse(userInput, out chosenNumber);
                    if (isValid == true)
                    {
                        isValid = chosenNumber >= k_MinMenuOption || chosenNumber <= k_MaxMenuOption;
                    }
                }
                ManageUserChoice((eMenuOptions)int.Parse(userInput));///#### (BUG except minus numbers )
            }
        }

        internal void ManageUserChoice(eMenuOptions i_MenuOptions)
        {
            switch (i_MenuOptions)
            {
                case eMenuOptions.AddVechile:
                    string[] newVehicleInfo = NewVehicleInfoFromUser();
                    m_GarageManager.InsertVehicle(newVehicleInfo[0], newVehicleInfo[1], (GarageLogic.eVehicleType)int.Parse(newVehicleInfo[2]), newVehicleInfo[3]);
                    ManageNewVehicleExtraInfoFromUser(newVehicleInfo[3]);
                    break;
                case eMenuOptions.ViewFilteredVehicleList:
                    Console.Write("Would you wish to filter by vehicle status? (1-Yes,2-No): ");
                    string userInput = Console.ReadLine();              // Should merge Those
                    int isFiltered = CheckFilterValidity(userInput);   //  Tow Lines to 1 methods

                    if (isFiltered == k_No)
                    {
                        PrintStringArray(m_GarageManager.ShowAllPlateNumbers());
                    }
                    else
                    {
                        Console.Write("Please choose vehicle status filter(1-In Progress, 2-Fixed, 3-Paid): ");  // Should merge Those
                        userInput = Console.ReadLine();                                                         //  Tow Lines to 1 methods
                        int StatusFilter = CheckStatusFilterValitidy(userInput);
                        PrintStringArray(m_GarageManager.ShowFilteredPlateNumbers((GarageLogic.eVehicleStatus)StatusFilter));
                    }
                    break;
                case eMenuOptions.ChangeVehicleStatus:
                    string plateNumber = getValidPlateNumberFromUser();
                    GarageLogic.eVehicleStatus newStatus = getValidVehicleStatusFromUser();
                    bool isValid = false;
                    while (isValid==false)
                    {
                        isValid = true;
                        try
                        {
                            m_GarageManager.ChangeVehicleStatus(plateNumber, newStatus);
                        }
                        catch (ArgumentException AE)
                        {
                            Console.WriteLine(AE.Message);
                            isValid = false;
                            plateNumber = getValidPlateNumberFromUser();
                        }
                    }
                    break;
                case eMenuOptions.PumpVehicleWheels:
                    plateNumber = getValidPlateNumberFromUser();
                    isValid = false;
                    while (isValid == false)
                    {
                        isValid = true;
                        try
                        {
                            m_GarageManager.InflateWheels(plateNumber);
                        }
                        catch (ArgumentException AE)
                        {
                            Console.WriteLine(AE.Message);
                            isValid = false;
                            plateNumber = getValidPlateNumberFromUser();
                        }
                    }
                    break;
                //case eMenuOptions.ReFuelVehicle:
                //    //ask from user 
                //    m_GarageManager.ReFuel();
                //    break;
                //case eMenuOptions.ReChargeVehicle:
                //    //ask from user 
                //    m_GarageManager.ReCharge(//params);
                //    break;
                case eMenuOptions.ViewVehicleInfo:
                    plateNumber = getValidPlateNumberFromUser();
                    isValid = false;
                    while (isValid == false)
                    {
                        isValid = true;
                        try
                        {
                            Console.WriteLine(m_GarageManager.GetVehicleDetails(plateNumber));
                        }
                        catch (ArgumentException AE)
                        {
                            Console.WriteLine(AE.Message);
                            isValid = false;
                            plateNumber = getValidPlateNumberFromUser();
                        }
                    }
                    break;
                case eMenuOptions.Exit:
                    ExitMenu();
                    break;
                default:
                    break;
            }
        }

        private string[] NewVehicleInfoFromUser()
        {
            const int k_NumOfData = 4;
            string[] newVehicleInfo = new string[k_NumOfData];

            Console.Write("Please enter vehicle owner name: ");
            string ownerName = Console.ReadLine();

            while (ownerName == string.Empty)
            {
                Console.Write("Invalid Name!, Please try again: ");
                ownerName = Console.ReadLine();
            }
            newVehicleInfo[0] = ownerName;

            Console.Write("Please enter vehicle owner phone number: ");
            string ownerPhone = Console.ReadLine();
            int phoneNumber;
            bool isValidOwnerPhone = false;

            if (ownerPhone != string.Empty)
            {
                isValidOwnerPhone = int.TryParse(ownerPhone, out phoneNumber);
            }

            while (isValidOwnerPhone == false)
            {
                Console.Write("Invalid Phone Number! please try again: ");
                ownerPhone = Console.ReadLine();
                if (ownerPhone != string.Empty)
                {
                    isValidOwnerPhone = int.TryParse(ownerPhone, out phoneNumber);
                }
            }
            newVehicleInfo[1] = ownerPhone;
            Console.WriteLine("Please enter the vehicle type : (1-Fuel Car, 2-Electric Car, 3-Fuel MotorBike, 4-Electric MotorBike, 5-Truck)");
            string vehicleType = Console.ReadLine();
            int chosenNumber;
            bool isValidVehicleType = false;

            if (vehicleType != string.Empty)
            {
                isValidVehicleType = int.TryParse(vehicleType, out chosenNumber);
                if (isValidVehicleType == true)
                {
                    isValidVehicleType = chosenNumber >= 1 && chosenNumber <= 5;
                }
            }

            while (isValidVehicleType == false)
            {
                Console.Write("Invalid input! please try again: ");
                vehicleType = Console.ReadLine();
                if (vehicleType != string.Empty)
                {
                    isValidVehicleType = int.TryParse(vehicleType, out chosenNumber);
                    if (isValidVehicleType == true)
                    {
                        isValidVehicleType = chosenNumber >= 1 && chosenNumber <= 5;
                    }
                }
            }
            newVehicleInfo[2] = vehicleType;
            Console.Write("Please enter license plate number: ");
            string plateNumber = Console.ReadLine();

            while (plateNumber == string.Empty)
            {
                Console.Write("Invalid plate number! please try again: ");
                plateNumber = Console.ReadLine();
            }
            newVehicleInfo[3] = plateNumber;

            return newVehicleInfo;
        }

        private void ManageNewVehicleExtraInfoFromUser(string i_PlateNumber)
        {
            const int k_NumOfInputStrings = 6;
            Console.WriteLine(m_GarageManager.VehiclesStorage[i_PlateNumber].Vehicle.MoreInfoMessage());
            string[] extraVehicleInfo = Console.ReadLine().Split(',');
            while (extraVehicleInfo.Length != k_NumOfInputStrings)
            {
                if (extraVehicleInfo.Length > k_NumOfInputStrings)
                {
                    Console.WriteLine("There are too many parameters, Please try again:");
                }
                else
                {
                    Console.WriteLine("There are not enough parameters, Please try again:");
                }
                extraVehicleInfo = Console.ReadLine().Split(',');
            }
            m_GarageManager.VehiclesStorage[i_PlateNumber].Vehicle.AddInfo(extraVehicleInfo);
            //handle exceptions here
        }

        private int CheckFilterValidity(string i_UserInput)
        {
            bool isValid = int.TryParse(i_UserInput, out int isFiltered);
            if (isValid == true)
            {
                isValid = isFiltered == k_Yes || isFiltered == k_No;
            }
            while (isValid == false)
            {
                Console.Write("Invalid Input! please try again (1-Yes,2-No): ");
                i_UserInput = Console.ReadLine();
                isValid = int.TryParse(i_UserInput, out isFiltered);
                if (isValid == true)
                {
                    isValid = isFiltered == k_Yes || isFiltered == k_No;
                }
            }

            return isFiltered;
        }

        private int CheckStatusFilterValitidy(string i_UserInput)
        {
            bool isValid = int.TryParse(i_UserInput, out int StatusFilter);
            if (isValid == true)
            {
                isValid = StatusFilter <= 3 || StatusFilter >= 1;
            }
            while (isValid == false)
            {
                Console.Write("Invalid Input! please try again (1-In Progress, 2-Fixed, 3-Paid): ");
                i_UserInput = Console.ReadLine();
                isValid = int.TryParse(i_UserInput, out StatusFilter);
                if (isValid == true)
                {
                    isValid = StatusFilter <= 3 || StatusFilter >= 1;
                }
            }

            return StatusFilter;
        }

        private void PrintStringArray(List<string> i_StringList)
        {
            foreach(string str in i_StringList)
            {
                Console.WriteLine(str);
            }
        }

        private string getValidPlateNumberFromUser()
        {
            Console.Write("Please enter vehicle plate number: ");
            string plateNumber=Console.ReadLine();
        
                while (plateNumber == string.Empty)
                {
                    Console.Write("Invalid input!, Please try again");
                    plateNumber = Console.ReadLine();
                }

            return plateNumber;
        }
        private GarageLogic.eVehicleStatus getValidVehicleStatusFromUser()
        {
            Console.Write("Please enter the new status (1-In Progress, 2-Fixed, 3-Paid): ");
            string userInput = Console.ReadLine();
            int chosenStatus=CheckStatusFilterValitidy(userInput);

            return (GarageLogic.eVehicleStatus)chosenStatus;
        }

        
        

        private void ExitMenu()
        {
            const int k_ValidExit = 1;
            Console.WriteLine("Thanks for using our system, see you next time!");
            Environment.Exit(k_ValidExit);
        }

    }
}
   

