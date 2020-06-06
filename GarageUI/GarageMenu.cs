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

        internal void RunMenu()
        {
            const bool k_IsUserChoseExit = true;

            while (k_IsUserChoseExit == true)
            {
                Console.WriteLine("---WELLCOME TO THE AMAZING GARAGE---");
                string i_Menu = string.Format(@"Please select one of the options by entering the representing number: 
1. Add New Vehicle 
2. View Filtered Vehicle List
3. Change Vehicle Status
4. Pump Vehicle Wheels
5. ReFuel Vehicle
6. ReCharge Vehicle
7. View Vehicle Details
8. Exit Garage");
                Console.WriteLine(i_Menu);
                string i_UserInput = Console.ReadLine();
                while (int.Parse(i_UserInput) < 1 || int.Parse(i_UserInput) > 8)
                {
                    Console.WriteLine("Please choose a number from the menu again");
                    i_UserInput = Console.ReadLine();
                }
                ManageUserChoice((eMenuOptions)int.Parse(i_UserInput));
            }
        }

        internal void ManageUserChoice(eMenuOptions i_MenuOptions)
        {
            switch (i_MenuOptions)
            {
                case eMenuOptions.AddVechile:
                    string[] NewVehicleInfo = NewVehicleInfoFromUser();
                    m_GarageManager.InsertVehicle(NewVehicleInfo[0], NewVehicleInfo[1], (GarageLogic.eVehicleType)int.Parse(NewVehicleInfo[2]), NewVehicleInfo[3]);
                    break;
                //case eMenuOptions.ViewFilteredVehicleList:
                //    //Let user decide 
                //    if (//not filtered)
                //    {
                //        m_GarageManager.ShowAllPlateNumbers();
                //    }
                //    else
                //    {
                //        m_GarageManager.ShowFilteredPlateNumbers(//filter);
                //    }
                //    break;
                //case eMenuOptions.ChangeVehicleStatus:
                //    //ask from user 
                //    m_GarageManager.ChangeVehicleStatus(//params);
                //    break;
                //case eMenuOptions.PumpVehicleWheels:
                //    //ask from user 
                //    m_GarageManager.InflateWheels(//params);
                //    break;
                //case eMenuOptions.ReFuelVehicle:
                //    //ask from user 
                //    m_GarageManager.ReFuel(//params);
                //    break;
                //case eMenuOptions.ReChargeVehicle:
                //    //ask from user 
                //    m_GarageManager.ReCharge(//params);
                //    break;
                //case eMenuOptions.ViewVehicleInfo:
                //    //ask from user 
                //    m_GarageManager.GetVehicleDetails(//params);
                //    break;
                //case eMenuOptions.Exit:
                //    ExitMenu();
                //    break;
                default:
                    break;
            }
        }

        private static string[] NewVehicleInfoFromUser()
        {
            string[] newVehicleInfo = null;

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

            while (isValidOwnerPhone==false)  
            {
               Console.Write("Invalid Phone Number! please try again: ");
                ownerPhone = Console.ReadLine();
                if (ownerPhone != string.Empty)
                {
                    isValidOwnerPhone = int.TryParse(ownerPhone, out phoneNumber);
                }
            }
            newVehicleInfo[1] = ownerPhone;
            Console.WriteLine("Please enter the vehicle type : 1-Fuel Car, 2-Electric Car, 3-Fuel MotorBike, 4-Electric MotorBike, 5-Truck");
            string vehicleType = Console.ReadLine();
            int chosenNumber;
            bool isValidVehicleType = false;

            if (vehicleType != string.Empty)
            {
                isValidVehicleType = int.TryParse(ownerPhone, out chosenNumber);
                if(isValidVehicleType==true)
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
            Console.Write("Please enter license plate number");
            string plateNumber = Console.ReadLine();

            while (plateNumber == string.Empty)
            {
                Console.Write("Invalid plate number! please try again: ");
                plateNumber = Console.ReadLine();
            }
            newVehicleInfo[3] = plateNumber;

            return newVehicleInfo;
        }


    }
}
   

