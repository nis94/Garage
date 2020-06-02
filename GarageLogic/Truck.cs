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

        public static new string MoreInfoMessage()
        {
            string AskForInfoMsg = string.Format(
                @"{0}
                5) Is Carrying Hazardous Materials? (1 = Yes, 2 = No)
                6) ChargeDisplacement",
                Vehicle.MoreInfoMessage());

            return AskForInfoMsg;
        }

        public new void AddInfo(string[] i_ExtraInfo) // To Do : add Exeptions/IfElse
        {
            (this as Vehicle).AddInfo(i_ExtraInfo);
            m_IsCarryingHazardousMaterials = bool.Parse(i_ExtraInfo[4]);
            m_ChargeDisplacement = float.Parse(i_ExtraInfo[5]);
        }

        public new string ToString()
        {
            string InfoMsg = string.Format(@"
                {0}
                5) Is Carrying Hazardous Materials?: {1}
                6) Charge Displacement Size: {2}",
                (this as Vehicle).ToString(), m_IsCarryingHazardousMaterials, m_ChargeDisplacement);

            return InfoMsg;
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
