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

        public Truck(bool i_IsCarryingHazardousMaterials, float i_ChargeDisplacement, string i_Model, string i_LicensNumber,
             string i_WheelManufacturerName, float i_CurrentEnergyCapacity) : base(i_Model, i_LicensNumber, 16, 28, i_WheelManufacturerName)
        {
            m_IsCarryingHazardousMaterials = i_IsCarryingHazardousMaterials;
            m_ChargeDisplacement = i_ChargeDisplacement;
            m_Engine = new FuelEngine(120f, i_CurrentEnergyCapacity, eFuelType.Soler);
            m_EnergyPresentage = (m_Engine.CurrentEnergyCapacity / m_Engine.MaxEnergyCapacity) * 100;
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
