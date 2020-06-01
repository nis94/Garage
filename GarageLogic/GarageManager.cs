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

        
        //public void InsertVehicle(string i_OwnerName, string i_OwnerPhone, int i_VehicleType, string i_plateNumber)
        //{
        //    GarageVehicleInfo newVehicleData = new GarageVehicleInfo(i_OwnerName, i_OwnerPhone);
        //    i_NewVehicleData.Vehicle = Creation.CreateNewVehicle(i_VehicleType, i_plateNumber);
        //    Storage.Add(i_plateNumber, i_NewVehicleData);
        //}

    }
}
