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

        internal static void RunMenu()
        {
            const int k_UntilTheUserChoseExit = 1;
            while (k_UntilTheUserChoseExit)
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

        internal static void ManageUserChoice(eMenuOptions i_MenuOptions)
        {
            switch (i_MenuOptions)
            {
                case eMenuOptions.AddVechile:
                    //ask for info 
                    m_GarageManager.InsertVehicle(); //enter info 
                    break;
                case eMenuOptions.ViewFilteredVehicleList:
                    //Let user decide 
                    if (//not filtered)
                    {
                        m_GarageManager.ShowAllPlateNumbers();
                    }
                    else
                    {
                        m_GarageManager.ShowFilteredPlateNumbers(//filter);
                    }
                        break;
                case eMenuOptions.ChangeVehicleStatus:
                    //ask from user 
                    m_GarageManager.ChangeVehicleStatus(//params);
                    break;
                case eMenuOptions.PumpVehicleWheels:
                    //ask from user 
                    m_GarageManager.InflateWheels(//params);
                    break;
                case eMenuOptions.ReFuelVehicle:
                    //ask from user 
                    m_GarageManager.ReFuel(//params);
                    break;
                case eMenuOptions.ReChargeVehicle:
                    //ask from user 
                    m_GarageManager.ReCharge(//params);
                    break;
                case eMenuOptions.ViewVehicleInfo:
                    //ask from user 
                    m_GarageManager.GetVehicleDetails(//params);
                    break;
                case eMenuOptions.Exit:
                    ExitMenu();
                    break;
                default:
                    break;
            }
            
        }
    }
}

   

