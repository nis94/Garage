using System;
using System.Collections.Generic;

namespace GarageLogic
{
    internal class Motorbike : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineDisplacement;

        public Motorbike(eLicenseType i_LicenseType, int i_EngineDisplacement, string i_Model, eEngineType i_EngineType,
            string i_LicensNumber, string i_WheelManufacturerName, float i_CurrentEnergyCapacity) : base(i_Model, i_LicensNumber, 2, 30, i_WheelManufacturerName)
        {
            m_LicenseType = i_LicenseType;
            m_EngineDisplacement = i_EngineDisplacement;

            if (i_EngineType.Equals(eEngineType.Electric)) 
            {
                m_Engine = new ElectricEngine(1.2f, i_CurrentEnergyCapacity);
            }
            else
            {
                m_Engine = new FuelEngine(7f, i_CurrentEnergyCapacity, eFuelType.Octan95);
            }
            m_EnergyPresentage = (m_Engine.CurrentEnergyCapacity / m_Engine.MaxEnergyCapacity) * 100;
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
