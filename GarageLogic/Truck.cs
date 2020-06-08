using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Truck : Vehicle
    {
        bool m_IsCarryingHazardousMaterials;
        float m_ChargeCapacity;

        internal Truck(eVehicleType i_VehicleType, string i_plateNumber) : base(16, 28, i_VehicleType, i_plateNumber)
        {
            m_Engine = new FuelEngine(120f, eFuelType.Soler);
        }

        public override List<string> MoreInfoMessage()
        {
            List<string> AskForInfoMsg = base.MoreInfoMessage();
            AskForInfoMsg.Add("Is Carrying Hazardous Materials? (true/false)");
            AskForInfoMsg.Add("Charge Capacity");
  
            return AskForInfoMsg;
        }

        public override void AddInfo(List<string> i_ExtraInfo)
        {
            base.AddInfo(i_ExtraInfo);
            if (i_ExtraInfo[4] == "true" || i_ExtraInfo[4] == "false")
            {
                m_IsCarryingHazardousMaterials = bool.Parse(i_ExtraInfo[4]);
            }
            else
            {
                throw new FormatException("Carrying Hazardous Materials can only chose 'true' or 'false', Please enter details again");
            }

            if (int.Parse(i_ExtraInfo[5]) >= 0)
            {
                m_ChargeCapacity = float.Parse(i_ExtraInfo[5]);
            }
            else
            {
                throw new ArgumentException("Charge capacity can't be negative!, Please enter details again");
            }
        }

        public override string CreateDetails()
        {
            string InfoMsg = string.Format(
@"{0}
Is Carrying Hazardous Materials?: {1}
Charge Capacity Size: {2}",
                base.CreateDetails(), m_IsCarryingHazardousMaterials, m_ChargeCapacity);

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

        public float ChargeCapacity
        {
            get
            {
                return m_ChargeCapacity;
            }
            set
            {
                m_ChargeCapacity = value;
            }
        }

    }

}
