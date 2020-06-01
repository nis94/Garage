using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        protected readonly string r_Model;
        protected readonly string m_PlateNumber;
        protected float m_EnergyPresentage;
        protected List<Wheel> m_Wheels;
        protected Engine m_Engine;
        protected readonly eVehicleType r_VehicleType;

        public Vehicle(string i_Model, string i_PlateNumber, int i_NumOfWheels, float i_MaxAirPressure, 
            string i_WheelManufacturerName, eVehicleType i_VehicleType)
        {
            r_Model = i_Model;
            m_PlateNumber = i_PlateNumber;
            m_Wheels = new List<Wheel>();
            r_VehicleType = i_VehicleType;
            Wheel wheel = new Wheel(i_MaxAirPressure, i_WheelManufacturerName);

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_Wheels.Add(wheel);
            }
        }

        public string VehicleDetails()
        {
            StringBuilder io_VehicleData = new StringBuilder();
            string i_Data = string.Format(@"Plate Number : {0}
Vehicle Model: {1}
Energy Presentage: {2}
Wheels Manufacturer Name: {3}
Current Wheel air pressure: {4}
Engine Type: {5}", m_PlateNumber, m_ModelName, m_RemainingEnergyPrecent, m_Wheels[0].ManufacturerName, m_Wheels[0].CurrentAirPressure, m_Engine.Type);

            io_VehicleData.Append(i_Data);

            FuleEngine FuelToCompare = Engine as FuleEngine;
            if (FuelToCompare != null)
            {
                eFuelType i_FuelType = FuelToCompare.eFuelType;
                io_VehicleData.Append(Environment.NewLine + "Fuel Type: " + i_FuelType);
            }

            return io_VehicleData.ToString();
        }

        public string Model
        {
            get
            {
                return r_Model;
            }
        }

        public string LicensNumber
        {
            get
            {
                return m_PlateNumber;
            }
        }

        public float EnergyPresentage
        {
            get
            {
                return m_EnergyPresentage;
            }
            set
            {
                m_EnergyPresentage = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }

        public Wheel this[int i]
        {
            get
            {
                return m_Wheels[i];
            }
            set
            {
                m_Wheels[i] = value;
            }
        }
    }
}
