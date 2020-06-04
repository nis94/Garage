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
            GarageVehicleInfo NewVehicleData = new GarageVehicleInfo(i_OwnerName, i_OwnerPhone, i_NewVehicle); //what to do with it?//
            //need to add the obj to the dictionary
        }

        public string ShowAllPlateNumbers(bool i_IsFilteredByStatus) // המתודה גם יוצרת את הרשימה? 
        {
            StringBuilder ListOfPlateNumbers = new StringBuilder(string.Empty);
            StringBuilder ListOfInProgress = new StringBuilder(string.Empty);
            StringBuilder ListOfFixed = new StringBuilder(string.Empty);
            StringBuilder ListOfPaid = new StringBuilder(string.Empty);

            if (i_IsFilteredByStatus == true)
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

                ListOfPlateNumbers.Append(ListOfInProgress.Append(ListOfFixed).Append(ListOfPaid)); //מה קורה פה? משרשר את כל הסטרינג בילדרים אחד לשני?
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

        public void ChangeVehicleStatus(string i_PlateNumber, eVehicleStatus i_NewVehicleStatus)
        {
            if (m_VehiclesStorage.ContainsKey(i_PlateNumber) == true)
            {
                m_VehiclesStorage[i_PlateNumber].Status = i_NewVehicleStatus;

            }
            //else part-  exception???

        }

        public void InflateWheels(string i_PlateNumber)
        {
            if (m_VehiclesStorage.ContainsKey(i_PlateNumber) == true)
            {
                float max = m_VehiclesStorage[i_PlateNumber].Vehicle.Wheels[0].MaxAirPressure;

                foreach (var item in m_VehiclesStorage[i_PlateNumber].Vehicle.Wheels) //run on all the wheels of the viechle
                {
                    item.CurrentAirPresuure = max;
                }
            }
            //else part- exception
        }

        public void Fuel(string i_PlateNumber, eFuelType i_FuelType, float i_FuelAmount)
        {
            if (m_VehiclesStorage.ContainsKey(i_PlateNumber) == true)
            {
                Vehicle currentVehicle = m_VehiclesStorage[i_PlateNumber].Vehicle;
                if (currentVehicle.Engine.Type == eEngineType.Fuel)
                {
                    FuelEngine currentEngine = currentVehicle.Engine as FuelEngine;
                    if (currentEngine.FuelType == i_FuelType)
                    {
                        if (currentEngine.CurrentEnergyCapacity + i_FuelAmount <= currentEngine.MaxEnergyCapacity)
                        {
                            currentEngine.ReFuel(i_FuelAmount);
                            currentVehicle.EnergyPresentage = (currentEngine.CurrentEnergyCapacity / currentEngine.MaxEnergyCapacity) * 100;
                        }

                        //else exception of execeeding the maximum capacity
                    } 
                    //else exception of fueltype mismatch
                }
                //else exception of engine mismatch
             }
            //else exception of vehicle not exist in system
        }

        public void Charge (string i_PlateNumber, float i_MinutesAmount)
        {
            if (m_VehiclesStorage.ContainsKey(i_PlateNumber) == true)
            {
                Vehicle currentVehicle = m_VehiclesStorage[i_PlateNumber].Vehicle;
                if (currentVehicle.Engine.Type == eEngineType.Electric)
                {
                    ElectricEngine currentEngine = currentVehicle.Engine as ElectricEngine;
                    if (currentEngine.CurrentEnergyCapacity + i_MinutesAmount <= currentEngine.MaxEnergyCapacity)
                    {
                        currentEngine.ReCharge(i_MinutesAmount);
                        currentVehicle.EnergyPresentage = (currentEngine.CurrentEnergyCapacity / currentEngine.MaxEnergyCapacity) * 100;
                    }
                    //else exception of exceeding maximum capacity
                }
                //else Exception of engine mismatch
            }
            //else exception of vehicle not exist in system
        }

        public string GetVehicleDetails (string i_PlateNumber)
        {
           string DetailsMsg = CreateVehicleDetails(i_PlateNumber);
           return DetailsMsg; 
        
        }

        public string CreateVehicleDetails (string i_PlateNumber)
        {
            if (m_VehiclesStorage.ContainsKey(i_PlateNumber) == true)
            {
                GarageVehicleInfo currentVehicleInfo = m_VehiclesStorage[i_PlateNumber]; 

                string Details = string.Format(@"
            1) Plate number: {0}
            2) ")
        }








    }
}
