using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private Dictionary<string, GarageVehicleInfo> m_VehiclesStorage = new Dictionary<string, GarageVehicleInfo>();

        public void InsertVehicle(string i_OwnerName, string i_OwnerPhone, eVehicleType i_VehicleType, string i_plateNumber)
        {
            foreach (var item in m_VehiclesStorage)
            {
                if (item.Key == i_plateNumber)
                {
                    // print Error message ---> (1)Exception? (2)return value? 
                    item.Value.Status = eVehicleStatus.InProgress;
                    break;
                }
            }

            Vehicle i_NewVehicle = VehicleCreator.CreateNewVehicle(i_VehicleType, i_plateNumber);
            GarageVehicleInfo NewVehicleData = new GarageVehicleInfo(i_OwnerName, i_OwnerPhone, i_NewVehicle);
        }

        public string ShowAllPlateNumbers(bool i_IsFilteredByStatus)
        {
            StringBuilder ListOfPlateNumbers = new StringBuilder(string.Empty);
            StringBuilder ListOfInProgress = new StringBuilder(string.Empty);
            StringBuilder ListOfFixed = new StringBuilder(string.Empty);
            StringBuilder ListOfPaid = new StringBuilder(string.Empty);

            if (i_IsFilteredByStatus==true)
            {
                foreach (var item in m_VehiclesStorage)
                {
                    if (item.Value.Status == eVehicleStatus.InProgress)
                    {
                        ListOfInProgress.Append(item.Key);
                    }
                    else if (item.Value.Status == eVehicleStatus.Fixed)
                    {
                        ListOfFixed.Append(item.Key);
                    }
                    else
                    {
                        ListOfPaid.Append(item.Key);
                    }
                }

                ListOfPlateNumbers.Append(ListOfInProgress.Append(ListOfFixed).Append(ListOfPaid));
            }
            else 
            {
                foreach (var item in m_VehiclesStorage)
                {
                 ListOfPlateNumbers.Append(item.Key); 
                }
            }

            return ListOfPlateNumbers.ToString();
        }









    }
}
