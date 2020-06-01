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
