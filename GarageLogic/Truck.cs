using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        bool m_IsCarryingHazardousMaterials;
        float m_ChargeDisplacement;

        public Truck(eVehicleType i_VehicleType, string i_plateNumber) : base(16, 28, i_VehicleType, i_plateNumber)
        {
            m_Engine = new FuelEngine(120f, eFuelType.Soler);
        }

        public override string MoreInfoMessage()
        {
            string Message = string.Format(@"Please enter the following information, (after every detail press ENTER):
                1) Model name
                2) Current Energy Capacity
                3) Is Carrying Hazardous Materials? (1-Yes, 2-No)
                4) ChargeDisplacement 
                5) Current Air Pressure(0-32)
                6) Wheels Manufacturer Name");

            return Message;
        }

        public override void AddInfo(string[] i_ExtraInfo) // To Do : add Exeptions/IfElse
        {
            m_ModelName = i_ExtraInfo[0];
            m_Engine.CurrentEnergyCapacity = float.Parse(i_ExtraInfo[1]);
            m_EnergyPresentage = (m_Engine.CurrentEnergyCapacity / m_Engine.MaxEnergyCapacity) * 100;
            m_IsCarryingHazardousMaterials = bool.Parse(i_ExtraInfo[2]);
            m_ChargeDisplacement = float.Parse(i_ExtraInfo[3]);
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.CurrentAirPresuure = float.Parse(i_ExtraInfo[4]);
                wheel.ManufacturerName = i_ExtraInfo[5];
            }
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
