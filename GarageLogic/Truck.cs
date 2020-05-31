using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    internal class Truck : Vehicle
    {
        bool m_IsCarryingHazardousMaterials;
        float m_ChargeDisplacement;

        public Truck(bool i_IsCarryingHazardousMaterials, float i_ChargeDisplacement, string i_Model, eEngineType i_EngineType, string i_LicensNumber, float i_EnergyPresentage,
            float i_MaxAirPressure, string i_ManufacturerName) : base(i_Model, i_LicensNumber, i_EnergyPresentage, 16, 28, i_ManufacturerName, i_EngineType)
        {
            m_IsCarryingHazardousMaterials = i_IsCarryingHazardousMaterials;
            m_ChargeDisplacement = i_ChargeDisplacement;
            m_Engine = new FuelEngine(120f, eFuelType.Soler);
        }


        public bool IsCarryingHazardousMaterials
        {
            get
            {
                return m_IsCarryingHazardousMaterials;
            }
            set
            {
                m_IsCarryingHazardousMaterials = value;
            }
        }

        public float ChargeDisplacement
        {
            get
            {
                return m_ChargeDisplacement;
            }
            set
            {
                m_ChargeDisplacement = value;
            }
        }

    }

}
