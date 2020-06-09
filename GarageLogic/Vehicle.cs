using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected readonly string r_PlateNumber;
        protected readonly eVehicleType r_VehicleType;
        protected string m_ModelName;
        protected float m_EnergyPercentage;
        protected List<Wheel> m_Wheels;
        protected Engine m_Engine;

        public Vehicle(int i_NumOfWheels, float i_MaxAirPressure, eVehicleType i_VehicleType, string i_PlateNumber)
        {
            r_PlateNumber = i_PlateNumber;
            m_Wheels = new List<Wheel>();
            r_VehicleType = i_VehicleType;

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                Wheel wheel = new Wheel(i_MaxAirPressure);
                m_Wheels.Add(wheel);
            }
        }

        public virtual List<string> MoreInfoMessage()
        {
            List<string> AskForInfoMsg = new List<string>();

            AskForInfoMsg.Add("Model name");
            AskForInfoMsg.Add("Amount Of Energy Left");
            AskForInfoMsg.Add("Current Air Pressure");
            AskForInfoMsg.Add("Wheels Manufacturer Name");

            return AskForInfoMsg;
        }

        public virtual void AddInfo(List<string> i_ExtraInfo)
        {
            if (i_ExtraInfo[0] != string.Empty)
            {
                m_ModelName = i_ExtraInfo[0];
            }
            else
            {
                throw new FormatException("Model name can't be empty string! Please enter details again");
            }

            if (float.Parse(i_ExtraInfo[1]) >= 0 && float.Parse(i_ExtraInfo[1]) <= m_Engine.MaxEnergyCapacity)
            {
                m_Engine.CurrentEnergyCapacity = float.Parse(i_ExtraInfo[1]);
                m_EnergyPercentage = (m_Engine.CurrentEnergyCapacity / m_Engine.MaxEnergyCapacity) * 100;
            }
            else
            {
                throw new ValueOutOfRangeException(0, m_Engine.MaxEnergyCapacity, "Current energy capacity");
            }

            if (float.Parse(i_ExtraInfo[2]) < 0 || float.Parse(i_ExtraInfo[2]) > m_Wheels[0].MaxAirPressure)
            {
                throw new ValueOutOfRangeException(0, m_Wheels[0].MaxAirPressure, "Current air pressure capacity");
            }
            else if (i_ExtraInfo[3] == string.Empty)
            {
                throw new FormatException("Wheels manufacture name can't be empty string! Please enter details again");
            }
            else
            {
                foreach (Wheel wheel in m_Wheels)
                {
                    wheel.CurrentAirPresuure = float.Parse(i_ExtraInfo[2]);
                    wheel.ManufacturerName = i_ExtraInfo[3];
                }
            }
        }

        public virtual string CreateDetails()
        {
            string InfoMsg =
                string.Format(
@"Model name: {0}
Amount Of Energy Left: {1}% 
Current Air Pressure: {2}
Wheels Manufacturer Name: {3}",
                m_ModelName,
                m_EnergyPercentage,
                m_Wheels[0].CurrentAirPresuure,
                m_Wheels[0].ManufacturerName);

            return InfoMsg;
        }

        public string Model
        {
            get
            {
                return m_ModelName;
            }
        }

        public string LicensNumber
        {
            get
            {
                return r_PlateNumber;
            }
        }

        public float EnergyPresentage
        {
            get
            {
                return m_EnergyPercentage;
            }

            set
            {
                m_EnergyPercentage = value;
            }
        }

        public Engine Engine
        {
            get
            {
                return m_Engine;
            }
        }

        public List<Wheel> Wheels
        {
            get
            {
                return m_Wheels;
            }
        }
    }
}