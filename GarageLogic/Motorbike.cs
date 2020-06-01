using System;
using System.Collections.Generic;

namespace GarageLogic
{
    internal class Motorbike : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineDisplacement;

        public Motorbike(eLicenseType i_LicenseType, int i_EngineDisplacement, string i_Model, eEngineType i_EngineType,
            string i_LicensNumber, string i_WheelManufacturerName) : base(i_Model, i_LicensNumber, 2, 30, i_WheelManufacturerName, i_EngineType)
        {
            m_LicenseType = i_LicenseType;
            m_EngineDisplacement = i_EngineDisplacement;

            if (i_EngineType.Equals(eEngineType.Electric)) // TO DO - override the Equals method
            {
                m_Engine = new ElectricEngine(1.2f);
            }
            else
            {
                m_Engine = new FuelEngine(7f, eFuelType.Octan95);
            }
            m_EnergyPresentage = (m_Engine.MaxEnergyCapacity / m_Engine.CurrentEnergyCapacity) * 100;
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
