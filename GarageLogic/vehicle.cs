using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        protected readonly string m_PlateNumber; // V
        protected readonly eVehicleType r_VehicleType;// V
        protected string m_ModelName;
        protected float m_EnergyPresentage;
        protected List<Wheel> m_Wheels;// V
        protected Engine m_Engine; //V

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

        public abstract string MoreInfoMessage(); 

        public abstract void AddInfo(string[] i_ExtraInfo);
        

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
