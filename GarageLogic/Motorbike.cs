using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Motorbike : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineCapacity;

        internal Motorbike(eVehicleType i_VehicleType, string i_plateNumber) : base(2, 30, i_VehicleType, i_plateNumber)
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

        public override List<string> MoreInfoMessage()
        {
            List<string> AskForInfoMsg = base.MoreInfoMessage();
            AskForInfoMsg.Add("License Type (1-A, 2-A1, 3-AA, 4-B)");
            AskForInfoMsg.Add("Engine Capacity");

            return AskForInfoMsg;
        }

        public override void AddInfo(List<string> i_ExtraInfo) 
        {
            base.AddInfo(i_ExtraInfo);
            if (int.Parse(i_ExtraInfo[4]) <= 4 && int.Parse(i_ExtraInfo[4]) >= 1)
            {
                m_LicenseType = (eLicenseType)int.Parse(i_ExtraInfo[4]);
            }
            else
            {
                throw new ArgumentException("No such option!, Please enter details again");
            }

            if (int.Parse(i_ExtraInfo[5]) >= 0) 
            {
                m_EngineCapacity = int.Parse(i_ExtraInfo[5]);
            }
            else
            {
                throw new ArgumentException("Engine capacity can't be negative!, Please enter details again");
            }
        }

        public override string CreateDetails()
        {
            string InfoMsg = string.Format(
@"{0}
License Type: {1}
Engine Capacity: {2}",
                base.CreateDetails(),
                m_LicenseType,
                m_EngineCapacity);

            return InfoMsg;
        }

        internal eLicenseType LicenseType
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

        public int EngineCapacity
        {
            get
            {
                return m_EngineCapacity;
            }

            set
            {
                m_EngineCapacity = value;
            }
        }
    }
}
