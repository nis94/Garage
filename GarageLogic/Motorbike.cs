using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class Motorbike : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineDisplacement;

        public Motorbike(eLicenseType eLicenseType, int i_EngineDisplacement, string i_Model, eEngineType i_EngineType, string i_LicensNumber,
            float i_EnergyPresentage, float i_MaxAirPressure, string i_ManufacturerName) : base(i_Model, i_LicensNumber, i_EnergyPresentage, 2, i_MaxAirPressure, i_ManufacturerName, i_EngineType)
        {
            if (i_EngineType.Equals(eEngineType.Electric))
            {
                m_Engine = new ElectricEngine(1.4f);
            }
            else
            {
                m_Engine = new FuelEngine(8f, eFuelType.Octan95);
            }
        }

        public int MyProperty { get; set; }
        public int MyProperty { get; set; }
    }
}
