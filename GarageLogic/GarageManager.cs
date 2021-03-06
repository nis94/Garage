﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class GarageManager
    {
        private readonly Dictionary<string, GarageVehicleInfo> r_VehiclesStorage = new Dictionary<string, GarageVehicleInfo>();

        public void InsertVehicle(string i_OwnerName, string i_OwnerPhone, eVehicleType i_VehicleType, string i_plateNumber)
        {
            bool isExist = false;
            foreach (string key in r_VehiclesStorage.Keys)
            {
                if (key == i_plateNumber)
                {
                    r_VehiclesStorage[key].Status = eVehicleStatus.InProgress;
                    throw new ArgumentException("Vehicle already in the garage! Changing vehicle status to 'In-Progress'");
                }
            }

            if (isExist == false)
            {
                Vehicle i_NewVehicle = VehicleCreator.CreateNewVehicle(i_VehicleType, i_plateNumber);
                GarageVehicleInfo NewVehicleData = new GarageVehicleInfo(i_OwnerName, i_OwnerPhone, i_NewVehicle);
                r_VehiclesStorage.Add(i_plateNumber, NewVehicleData);
            }
        }

        public List<string> ShowAllPlateNumbers()
        {
            List<string> PlateNumbersList = new List<string>();

            foreach (string key in r_VehiclesStorage.Keys)
            {
                PlateNumbersList.Add(key);
            }

            return PlateNumbersList;
        }

        public List<string> ShowFilteredPlateNumbers(eVehicleStatus i_VehicleStatus)
        {
            List<string> PlateNumbersList = new List<string>();

            foreach (string key in r_VehiclesStorage.Keys)
            {
                if (r_VehiclesStorage[key].Status == i_VehicleStatus)
                {
                    PlateNumbersList.Add(key);
                }
            }

            return PlateNumbersList;
        }

        public void ChangeVehicleStatus(string i_PlateNumber, eVehicleStatus i_NewVehicleStatus)
        {
            if (r_VehiclesStorage.ContainsKey(i_PlateNumber) == true)
            {
                r_VehiclesStorage[i_PlateNumber].Status = i_NewVehicleStatus;
            }
            else
            {
                throw new ArgumentException("Vehicle does not exist in the garage!");
            }
        }

        public void InflateWheels(string i_PlateNumber)
        {
            if (r_VehiclesStorage.ContainsKey(i_PlateNumber) == true)
            {
                float max = r_VehiclesStorage[i_PlateNumber].Vehicle.Wheels[0].MaxAirPressure;

                foreach (Wheel wheel in r_VehiclesStorage[i_PlateNumber].Vehicle.Wheels) 
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
            if (r_VehiclesStorage.ContainsKey(i_PlateNumber) == true)
            {
                Vehicle currentVehicle = r_VehiclesStorage[i_PlateNumber].Vehicle;

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
                        else
                        {
                            throw new ValueOutOfRangeException(0, currentEngine.MaxEnergyCapacity - currentEngine.CurrentEnergyCapacity, "Additional amount ");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Fuel type mismatch!");
                    }
                }
                else
                {
                    throw new ArgumentException("Engine Type mismatch!, Please Enter Fueled Car Plate Number");
                }
            }
            else
            {
                throw new ArgumentException("Vehicle does not exist in the garage!");
            }
        }

        public void ReCharge(string i_PlateNumber, float i_MinutesAmount)
        { 
            if (r_VehiclesStorage.ContainsKey(i_PlateNumber) == true)
            {
                Vehicle currentVehicle = r_VehiclesStorage[i_PlateNumber].Vehicle;
                if (currentVehicle.Engine.Type == eEngineType.Electric)
                {
                    ElectricEngine currentEngine = currentVehicle.Engine as ElectricEngine;
                    if (currentEngine.CurrentEnergyCapacity + i_MinutesAmount <= currentEngine.MaxEnergyCapacity) 
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
                    throw new ArgumentException("Engine Type mismatch! Please Enter Electric Car Plate Number");
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
            if (r_VehiclesStorage.ContainsKey(i_PlateNumber) == true)
            {
                GarageVehicleInfo currentVehicleInfo = r_VehiclesStorage[i_PlateNumber];
                Vehicle currentvehicle = currentVehicleInfo.Vehicle;

                string Details = string.Format(
                    @"
Owner Name is: {0}
OWner phone number is: {1}
Vehicle status is: {2}
{3}",
            currentVehicleInfo.OwnerName,
            currentVehicleInfo.PhoneNumber,
            currentVehicleInfo.Status,
            currentvehicle.CreateDetails());

                return Details;
            }
            else
            {
                throw new ArgumentException("Vehicle does not exist in the garage!");
            }
        }

        public Dictionary<string, GarageVehicleInfo> VehiclesStorage
        {
            get { return r_VehiclesStorage; }
        }
    }
}