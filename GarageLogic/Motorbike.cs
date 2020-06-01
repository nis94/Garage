using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Motorbike : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineDisplacement;

        public Motorbike(eVehicleType i_VehicleType, string i_plateNumber) : base(2, 30, i_VehicleType, i_plateNumber)
        {

            if (i_VehicleType.Equals(eVehicleType.ElectricMotorbike)) 
            {
                m_Engine = new ElectricEngine(1.2f);
            }
            else
            {
                m_Engine = new FuelEngine(7f, eFuelType.Octan95);
            }
        }

        public override string MoreInfoMessage()
        {
            string Message = string.Format(@"Please enter the following information, (after every detail press ENTER):
                1) Model name
                2) Current Energy Capacity
                3) License Type: (1-A, 2-A1, 3-AA, 4-B)
                4) EngineDisplacement 
                5) Current Air Pressure(0-32)
                6) Wheels Manufacturer Name");

            return Message;
        }

        public override void AddInfo(string[] i_ExtraInfo) // To Do : add Exeptions/IfElse
        {
            m_ModelName = i_ExtraInfo[0];
            m_Engine.CurrentEnergyCapacity = float.Parse(i_ExtraInfo[1]);
            m_EnergyPresentage = (m_Engine.CurrentEnergyCapacity / m_Engine.MaxEnergyCapacity) * 100;
            m_LicenseType = (eLicenseType)int.Parse(i_ExtraInfo[2]);
            m_EngineDisplacement = int.Parse(i_ExtraInfo[3]);
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.CurrentAirPresuure = float.Parse(i_ExtraInfo[4]);
                wheel.ManufacturerName = i_ExtraInfo[5];
            }
        }

        public eLicenseType LicenseType
        {
            get
            {
                return m_LicenseType;
            }
            set
            {
                m_LicenseType = value;
            }
        }

        public int EngineDisplacement
        {
            get
            {
                return m_EngineDisplacement;
            }
            set
            {
                m_EngineDisplacement = value;
            }
        }
    }
}
