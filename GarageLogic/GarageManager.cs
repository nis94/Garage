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
            bool isExist = false;
            foreach (string key in m_VehiclesStorage.Keys)
            {
                if (key == i_plateNumber)
                {
                    throw new ArgumentException("Vehicle Already in the garage!");
                    m_VehiclesStorage[key].Status = eVehicleStatus.InProgress;
                    break;
                }
            }

            if (isExist == false)
            {
                Vehicle i_NewVehicle = VehicleCreator.CreateNewVehicle(i_VehicleType, i_plateNumber);
                // BUG!!!-----> Show To Liran
                GarageVehicleInfo NewVehicleData = new GarageVehicleInfo(i_OwnerName, i_OwnerPhone, i_NewVehicle);
                m_VehiclesStorage.Add(i_plateNumber, NewVehicleData);
            }
        }

        public List<string> ShowAllPlateNumbers()
        {
            List<string> PlateNumbersList = new List<string>();

            foreach (string key in m_VehiclesStorage.Keys)
            {
                PlateNumbersList.Add(key);
            }

            return PlateNumbersList;
        }

        public List<string> ShowFilteredPlateNumbers(eVehicleStatus i_VehicleStatus)
        {
            List<string> PlateNumbersList = new List<string>();

            foreach (string key in m_VehiclesStorage.Keys)
            {
                if (m_VehiclesStorage[key].Status == i_VehicleStatus)
                {
                    PlateNumbersList.Add(key);
                }
            }


            return PlateNumbersList;
        }

        public void ChangeVehicleStatus(string i_PlateNumber, eVehicleStatus i_NewVehicleStatus)
        {
            if (m_VehiclesStorage.ContainsKey(i_PlateNumber) == true)
            {
                m_VehiclesStorage[i_PlateNumber].Status = i_NewVehicleStatus;
            }
            else
            {
                throw new ArgumentException("Vehicle does not exist in the garage!");
            }
        }

        public void InflateWheels(string i_PlateNumber)
        {
            if (m_VehiclesStorage.ContainsKey(i_PlateNumber) == true)
            {
                float max = m_VehiclesStorage[i_PlateNumber].Vehicle.Wheels[0].MaxAirPressure;

                foreach (Wheel wheel in m_VehiclesStorage[i_PlateNumber].Vehicle.Wheels) 
                {
                    wheel.CurrentAirPresuure = max;
                }
            }
            else
            {
                throw new ArgumentException("Vehicle does not exist in the garage!");
            }
        }

        public void ReFuel(string i_PlateNumber, eFuelType i_FuelType, float i_FuelAmount)
        { 
            if (m_VehiclesStorage.ContainsKey(i_PlateNumber) == true)
            {
                Vehicle currentVehicle = m_VehiclesStorage[i_PlateNumber].Vehicle;

                if (currentVehicle.Engine.Type == eEngineType.Fuel)
                {
                    FuelEngine currentEngine = currentVehicle.Engine as FuelEngine;
                    if (currentEngine.FuelType == i_FuelType)
                    {
                        if (currentEngine.CurrentEnergyCapacity + i_FuelAmount <= currentEngine.MaxEnergyCapacity)  //###BUG!!!!! X<=X go to else part
                        {
                            currentEngine.ReFuel(i_FuelAmount);
                            currentVehicle.EnergyPresentage = (currentEngine.CurrentEnergyCapacity / currentEngine.MaxEnergyCapacity) * 100;
                        }
                        else
                        {
                            throw new ValueOutOfRangeException(0, currentEngine.MaxEnergyCapacity - currentEngine.CurrentEnergyCapacity, "Exceeding the maximum tank capacity!");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Fuel type mismatch!");
                    }
                }
                else
                {
                    throw new ArgumentException("Engine Type mismatch!");
                }
            }
            else
            {
                throw new ArgumentException("Vehicle does not exist in the garage!");
            }
        }

        public void ReCharge(string i_PlateNumber, float i_MinutesAmount)
        {

            if (m_VehiclesStorage.ContainsKey(i_PlateNumber) == true)
            {
                Vehicle currentVehicle = m_VehiclesStorage[i_PlateNumber].Vehicle;
                if (currentVehicle.Engine.Type == eEngineType.Electric)
                {
                    ElectricEngine currentEngine = currentVehicle.Engine as ElectricEngine;
                    if (currentEngine.CurrentEnergyCapacity + i_MinutesAmount <= currentEngine.MaxEnergyCapacity) //###BUG!!!!! X<=X go to else part
                    {
                        currentEngine.ReCharge(i_MinutesAmount);
                        currentVehicle.EnergyPresentage = (currentEngine.CurrentEnergyCapacity / currentEngine.MaxEnergyCapacity) * 100;
                    }
                    else
                    {
                        throw new ValueOutOfRangeException(0, currentEngine.MaxEnergyCapacity - currentEngine.CurrentEnergyCapacity, "Exceeding the maximum charge capacity!");
                    }
                }
                else
                {
                    throw new ArgumentException("Engine Type mismatch!");
                }
            }
            else
            {
                throw new ArgumentException("Vehicle does not exist in the garage!");
            }
        }

        public string GetVehicleDetails(string i_PlateNumber)
        {
            string DetailsMsg = CreateVehicleDetails(i_PlateNumber);
            
            return DetailsMsg;
        }

        private string CreateVehicleDetails(string i_PlateNumber)
        {
            if (m_VehiclesStorage.ContainsKey(i_PlateNumber) == true)
            {
                GarageVehicleInfo currentVehicleInfo = m_VehiclesStorage[i_PlateNumber];
                Vehicle currentvehicle = currentVehicleInfo.Vehicle;

                string Details = string.Format(@"
Owner Name is: {0}
OWner phone number is: {1}
Vehicle status is: {2}
{3}",
            currentVehicleInfo.OwnerName, currentVehicleInfo.PhoneNumber, currentVehicleInfo.Status, currentvehicle.CreateDetails());

                return Details;
            }
            else
            {
                throw new ArgumentException("Vehicle does not exist in the garage!");
            }
        }

        public Dictionary<string, GarageVehicleInfo> VehiclesStorage
        {
            get { return m_VehiclesStorage; }
        }
    }
}