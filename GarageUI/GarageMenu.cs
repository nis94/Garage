using System;
using System.Collections.Generic;
using Ex02.ConsoleUtils;

namespace Ex03.ConsoleUI
{
    public class GarageMenu
    {
        private readonly GarageLogic.GarageManager r_GarageManager = new GarageLogic.GarageManager();
        private const int k_Yes = 1;
        private const int k_No = 2;

        internal void RunMenu()
        {
            const bool k_IsUserChoseExit = true;
            const int k_MinMenuOption = 1;
            const int k_MaxMenuOption = 8;

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
8. Exit Garage");
                Console.Write("Please select one of the options by entering the representing number: ");
                Console.WriteLine(i_Menu);
                string userInput = Console.ReadLine();
                bool isValid = int.TryParse(userInput, out int chosenNumber);
                if (isValid == true)
                {
                    isValid = chosenNumber >= k_MinMenuOption && chosenNumber <= k_MaxMenuOption;
                }
                while (isValid == false)
                {
                    Console.Write("Invalid input! Please choose a number from the menu again: ");
                    userInput = Console.ReadLine();
                    isValid = int.TryParse(userInput, out chosenNumber);
                    if (isValid == true)
                    {
                        isValid = chosenNumber >= k_MinMenuOption && chosenNumber <= k_MaxMenuOption;
                    }
                }
                manageUserChoice((eMenuOptions)int.Parse(userInput));
            }
        }

        private void manageUserChoice(eMenuOptions i_MenuOptions)
        {
            switch (i_MenuOptions)
            {
                case eMenuOptions.AddVechile:
                    manageNewVehicleAddition();
                    Screen.Clear();
                    break;
                case eMenuOptions.ViewFilteredVehicleList:
                    manageFilteredVehicleList();
                    break;
                case eMenuOptions.ChangeVehicleStatus:
                    manageVehicleStatusChange();
                    Screen.Clear();
                    break;
                case eMenuOptions.InflateVehicleWheels:
                    manageWheelsInflation();
                    Screen.Clear();
                    break;
                case eMenuOptions.ReFuelVehicle:
                    manageReFuel();
                    Screen.Clear();
                    break;
                case eMenuOptions.ReChargeVehicle:
                    manageReCharge();
                    Screen.Clear();
                    break;
                case eMenuOptions.ViewVehicleInfo:
                    manageVehicleInfo();
                    break;
                case eMenuOptions.Exit:
                    exitMenu();
                    break;
                default:
                    break;
            }
        }

        private void manageNewVehicleAddition()
        {
            try
            {
                string[] newVehicleInfo = newVehicleInfoFromUser();
                r_GarageManager.InsertVehicle(newVehicleInfo[0], newVehicleInfo[1], (GarageLogic.eVehicleType)int.Parse(newVehicleInfo[2]), newVehicleInfo[3]);
                manageNewVehicleExtraInfoFromUser(newVehicleInfo[3]);
            }
            catch (ArgumentException AE)
            {
                Console.WriteLine(AE.Message);
                if (returnToMainMenu() == true)
                {
                    RunMenu();
                }
            }
        }

        private string[] newVehicleInfoFromUser()
        {
            const int k_NumOfData = 4;
            string[] newVehicleInfo = new string[k_NumOfData];

            newVehicleInfo[0] = getValidOwnername();
            newVehicleInfo[1] = getValidOwnerPhoneNumber();
            newVehicleInfo[2] = getValidVehicalType();
            newVehicleInfo[3] = getValidPlateNumberFromUser();

            return newVehicleInfo;
        }

        private void manageNewVehicleExtraInfoFromUser(string i_PlateNumber)
        {
            bool isValid = false;
            List<string> requestMoreDetails;

            while (isValid == false)
            {
                isValid = true;
                try
                {
                    requestMoreDetails = r_GarageManager.VehiclesStorage[i_PlateNumber].Vehicle.MoreInfoMessage();
                    List<string> extraVehicleInfo = getExtraVehicleInfoFromUser(requestMoreDetails);
                    r_GarageManager.VehiclesStorage[i_PlateNumber].Vehicle.AddInfo(extraVehicleInfo);
                }
                catch(FormatException FE)
                {
                    Console.WriteLine(FE.Message);
                    isValid = false;
                }
                catch (ArgumentException AE)
                {
                    Console.WriteLine(AE.Message);
                    isValid = false;
                }
                catch (GarageLogic.ValueOutOfRangeException VOORE)
                {
                    Console.WriteLine(VOORE.Message);
                    isValid = false;
                }
            }
        }

        private void manageFilteredVehicleList()
        {
            Console.Write("Would you wish to filter by vehicle status? (1-Yes,2-No): ");
            string userInput = Console.ReadLine();
            int isFiltered = checkFilterValidity(userInput);

            if (isFiltered == k_No)
            {
                printStringArray(r_GarageManager.ShowAllPlateNumbers());
            }
            else
            {
                Console.Write("Please choose vehicle status filter(1-In Progress, 2-Fixed, 3-Paid): ");
                userInput = Console.ReadLine();
                int StatusFilter = checkStatusFilterValitidy(userInput);
                printStringArray(r_GarageManager.ShowFilteredPlateNumbers((GarageLogic.eVehicleStatus)StatusFilter));
            }
            Console.WriteLine(Environment.NewLine);
        }

        private void manageVehicleStatusChange()
        {
            string plateNumber = getValidPlateNumberFromUser();
            GarageLogic.eVehicleStatus newStatus = getValidVehicleStatusFromUser();
            bool isValid = false;
            while (isValid == false)
            {
                isValid = true;
                try
                {
                    r_GarageManager.ChangeVehicleStatus(plateNumber, newStatus);
                }
                catch (ArgumentException AE)
                {
                    Console.WriteLine(AE.Message);
                    isValid = false;
                    if (returnToMainMenu() == true)
                    {
                        break;
                    }
                    plateNumber = getValidPlateNumberFromUser();
                }
            }
            Console.WriteLine(Environment.NewLine);
        }

        private void manageWheelsInflation()
        {
            string plateNumber = getValidPlateNumberFromUser();
            bool isValid = false;

            while (isValid == false)
            {
                isValid = true;
                try
                {
                    r_GarageManager.InflateWheels(plateNumber);
                }
                catch (ArgumentException AE)
                {
                    Console.WriteLine(AE.Message);
                    isValid = false;
                    if (returnToMainMenu() == true)
                    {
                        break;
                    }
                    plateNumber = getValidPlateNumberFromUser();
                }
            }
        }

        private void manageReFuel()
        {
            bool isValid = false;
            string plateNumber;
            GarageLogic.eFuelType fuelType;
            float fuelAmount;

            while (isValid == false)
            {
                isValid = true;
                plateNumber = getValidPlateNumberFromUser();
                fuelType = getValidFuelTypeFromUser();
                fuelAmount = getValidEnergyAmountFromUser();

                try
                {
                    r_GarageManager.ReFuel(plateNumber, fuelType, fuelAmount);
                }
                catch (GarageLogic.ValueOutOfRangeException VOORE)
                {
                    Console.WriteLine(VOORE.Message);
                    isValid = false;
                    if (returnToMainMenu() == true)
                    {
                        break;
                    }
                }
                catch (ArgumentException AE)
                {
                    Console.WriteLine(AE.Message);
                    isValid = false;
                    if (returnToMainMenu() == true)
                    {
                        break;
                    }
                }
            }
        }

        private void manageReCharge()
        {
            bool isValid = false;
            string plateNumber;
            float fuelAmount;

            while (isValid == false)
            {
                isValid = true;
                plateNumber = getValidPlateNumberFromUser();
                fuelAmount = getValidEnergyAmountFromUser();

                try
                {
                    r_GarageManager.ReCharge(plateNumber, fuelAmount);
                }
                catch (GarageLogic.ValueOutOfRangeException VOORE)
                {
                    Console.WriteLine(VOORE.Message);
                    isValid = false;
                    if (returnToMainMenu() == true)
                    {
                        break;
                    }
                }
                catch (ArgumentException AE)
                {
                    Console.WriteLine(AE.Message);
                    isValid = false;
                    if (returnToMainMenu() == true)
                    {
                        break;
                    }
                }
            }
        }

        private void manageVehicleInfo()
        {
            string plateNumber = getValidPlateNumberFromUser();
            bool isValid = false;

            while (isValid == false)
            {
                isValid = true;
                try
                {
                    Console.WriteLine(r_GarageManager.GetVehicleDetails(plateNumber));
                }
                catch (ArgumentException AE)
                {
                    Console.WriteLine(AE.Message);
                    isValid = false;
                    if (returnToMainMenu() == true)
                    {
                        break;
                    }
                    plateNumber = getValidPlateNumberFromUser();
                }
            }
            Console.WriteLine(Environment.NewLine);
        }

        private int checkFilterValidity(string i_UserInput)
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

        private int checkStatusFilterValitidy(string i_FilterToCheck)
        {
            bool isValid = int.TryParse(i_FilterToCheck, out int statusFilter);
            if (isValid == true)
            {
                isValid = statusFilter <= 3 || statusFilter >= 1;
            }
            while (isValid == false)
            {
                Console.Write("Invalid Input! please try again (1-In Progress, 2-Fixed, 3-Paid): ");
                i_FilterToCheck = Console.ReadLine();
                isValid = int.TryParse(i_FilterToCheck, out statusFilter);
                if (isValid == true)
                {
                    isValid = statusFilter <= 3 || statusFilter >= 1;
                }
            }

            return statusFilter;
        }

        private void printStringArray(List<string> i_StringList)
        {
            foreach(string str in i_StringList)
            {
                Console.WriteLine(str);
            }
        }

        private List<string> getExtraVehicleInfoFromUser(List<string> i_RequestStrArr)
        {
            List<string> inputStrArr = new List<string>(i_RequestStrArr.Count);
            int index = 1;

            foreach(string request in i_RequestStrArr)
            {
                Console.Write(string.Format("{0}) {1}: ",index++,request));
                inputStrArr.Add(Console.ReadLine());
            }

            return inputStrArr;
        }

        private string getValidOwnername()
        {
            Console.Write("Please enter vehicle owner name: ");
            string ownerName = Console.ReadLine();

            while (ownerName == string.Empty)
            {
                Console.Write("Invalid Name!, Please try again: ");
                ownerName = Console.ReadLine();
            }
            return ownerName;
        }

        private string getValidOwnerPhoneNumber()
        {
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

            return ownerPhone;
        }

        private string getValidVehicalType()
        {
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

            return vehicleType;
        }

        private string getValidPlateNumberFromUser()
        {
            Console.Write("Please enter vehicle plate number: ");
            string plateNumber=Console.ReadLine();
        
                while (plateNumber == string.Empty)
                {
                    Console.Write("Invalid input!, Please try again: ");
                    plateNumber = Console.ReadLine();
                }

            return plateNumber;
        }

        private GarageLogic.eVehicleStatus getValidVehicleStatusFromUser()
        {
            Console.Write("Please enter the new status (1-In Progress, 2-Fixed, 3-Paid): ");
            string userInput = Console.ReadLine();
            int chosenStatus=checkStatusFilterValitidy(userInput);

            return (GarageLogic.eVehicleStatus)chosenStatus;
        }

        private GarageLogic.eFuelType getValidFuelTypeFromUser()
        {
            Console.Write("Please enter the fuel type (1-Soler, 2-Octan95, 3-Octan96, 4-Octan98): "); 
            string userInput = Console.ReadLine();
            bool isValid = int.TryParse(userInput, out int fuelType);
            if (isValid == true)
            {
                isValid = fuelType <= 4 && fuelType >= 1;
            }
            while (isValid == false)
            {
                Console.Write("Invalid input!, please try again (1-Soler, 2-Octan95, 3-Octan96, 4-Octan98): ");
                userInput = Console.ReadLine();
                isValid = int.TryParse(userInput, out fuelType);
                if (isValid == true)
                {
                    isValid = fuelType <= 4 && fuelType >= 1;
                }
            }

            return (GarageLogic.eFuelType)fuelType;
        }

        private float getValidEnergyAmountFromUser()
        {
            bool isValid = false;
            float fuelAmount = 0;

            Console.Write("Please enter energy addition amount: ");
            while (isValid == false)
            {
                isValid =true;
                string i_UserInput = Console.ReadLine();
                try
                {
                    fuelAmount = float.Parse(i_UserInput);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Only Numbers Allowed!");
                    isValid = false;
                }
            }

            return fuelAmount;
        }
        
        private bool returnToMainMenu()
        {
            bool toReturn = false;

            Console.Write(string.Format(@"Please choose one of this options:
1 - Try Again
2 - Return to main menu
"));
            string userInput = Console.ReadLine();
            while (userInput != "1" && userInput != "2") 
            {
                Console.Write("Invalid input!, Please choose '1' or '2': ");
                userInput = Console.ReadLine();
            }
            if (userInput == "2")
            {
                toReturn = true;
                Screen.Clear();
            }

            return toReturn;
        }

        private void exitMenu()
        {
            const int k_ValidExit = 1;
            Screen.Clear();
            Console.WriteLine("Thanks for using our system, See you next time!");
            Environment.Exit(k_ValidExit);
        }
    }
} 
   

