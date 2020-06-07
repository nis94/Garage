using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public virtual string MoreInfoMessage()
        {
            string AskForInfoMsg = string.Format(@"
Please enter the following information, (Please Enter details divided with COMMAS without SPACES and finally press ENTER):
1) Model name
2) Current Energy 
3) Current Air Pressure
4) Wheels Manufacturer Name");

            return AskForInfoMsg;
        }

        public virtual void AddInfo(string[] i_ExtraInfo)
        {
            m_ModelName = i_ExtraInfo[0];
            m_Engine.CurrentEnergyCapacity = float.Parse(i_ExtraInfo[1]);
            m_EnergyPercentage = (m_Engine.CurrentEnergyCapacity / m_Engine.MaxEnergyCapacity) * 100;
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.CurrentAirPresuure = float.Parse(i_ExtraInfo[2]);
                wheel.ManufacturerName = i_ExtraInfo[3];
            }
        }

        public virtual string CreateDetails()
        {
            string InfoMsg = string.Format(
@"Model name: {0}
Current Energy percentage: {1} 
Current Air Pressure: {2}
Wheels Manufacturer Name: {3}",
                m_ModelName, m_EnergyPercentage, m_Wheels[0].CurrentAirPresuure, m_Wheels[0].ManufacturerName);

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
