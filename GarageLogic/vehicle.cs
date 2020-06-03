using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        protected readonly string m_PlateNumber; 
        protected readonly eVehicleType r_VehicleType;
        protected string m_ModelName;
        protected float m_EnergyPresentage;
        protected List<Wheel> m_Wheels;
        protected Engine m_Engine; 

        public Vehicle(int i_NumOfWheels, float i_MaxAirPressure, eVehicleType i_VehicleType, string i_PlateNumber)
        {
            m_PlateNumber = i_PlateNumber;
            m_Wheels = new List<Wheel>();
            r_VehicleType = i_VehicleType;
            Wheel wheel = new Wheel(i_MaxAirPressure);

            for (int i = 0; i < i_NumOfWheels; i++)
            {
                m_Wheels.Add(wheel);
            }
        }

        protected static string MoreInfoMessage()
        {
            string AskForInfoMsg = string.Format(@"Please enter the following information, (after every detail press ENTER):
                1) Model name
                2) Current Energy 
                3) Current Air Pressure(0-32)
                4) Wheels Manufacturer Name");

            return AskForInfoMsg;
        }

        protected virtual void AddInfo(string[] i_ExtraInfo) // To Do : add Exeptions/IfElse
        {
            m_ModelName = i_ExtraInfo[0];
            m_Engine.CurrentEnergyCapacity = float.Parse(i_ExtraInfo[1]);
            m_EnergyPresentage = (m_Engine.CurrentEnergyCapacity / m_Engine.MaxEnergyCapacity) * 100;
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.CurrentAirPresuure = float.Parse(i_ExtraInfo[2]);
                wheel.ManufacturerName = i_ExtraInfo[3];
            }
        }

        protected virtual string PrintData()
        {
            string InfoMsg = string.Format(@"
                1) Model name: {0}
                2) Current Energy: {1} 
                3) Current Air Pressure: {2}
                4) Wheels Manufacturer Name: {3}",
                m_ModelName, m_EnergyPresentage, m_Wheels[0].CurrentAirPresuure, m_Wheels[0].ManufacturerName);

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
