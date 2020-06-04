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

        public List<string> ShowAllPlateNumbers(bool i_IsFilteredByStatus)
        {
            List<string> o_ListOfPlateNumbers = new List<string>();

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

                o_ListOfPlateNumbers.Append(ListOfInProgress.Append(ListOfFixed).Append(ListOfPaid));
            }
            else 
            {
                foreach (var item in m_VehiclesStorage)
                {
                 o_ListOfPlateNumbers.Append(item.Key); 
                }
            }

            return o_ListOfPlateNumbers;
        }

        public void ChangeVehicleStatus(string i_PlateNumber, eVehicleStatus i_VehicleStatus)
        {
            foreach (var item in m_VehiclesStorage)
            {
                ListOfPlateNumbers.Append();
            }
        }
    }









    }
}
