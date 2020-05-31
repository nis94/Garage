using System;
using System.Collections.Generic;

namespace GarageLogic
{
    internal class Motorbike : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineDisplacement;

        public Motorbike(eLicenseType i_LicenseType, int i_EngineDisplacement, string i_Model, eEngineType i_EngineType, string i_LicensNumber, float i_EnergyPresentage, 
            float i_MaxAirPressure, string i_ManufacturerName) : base(i_Model, i_LicensNumber, i_EnergyPresentage, 2, 30, i_ManufacturerName, i_EngineType)
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
