using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    internal class Motorbike : Vehicle
    {
        private eLicenseType m_LicenseType;
        private int m_EngineDisplacement;

        public Motorbike(eVehicleType i_VehicleType, string i_plateNumber) : base(2, 30, i_VehicleType, i_plateNumber)
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

        public override string MoreInfoMessage()
        {
            string AskForInfoMsg = string.Format(
@"{0}
License Type: (1-A, 2-A1, 3-AA, 4-B)
EngineDisplacement: ",
               base.MoreInfoMessage());

            return AskForInfoMsg;
        }

        public override void AddInfo(string[] i_ExtraInfo) // To Do : add Exeptions/IfElse
        {
            base.AddInfo(i_ExtraInfo);
            m_LicenseType = (eLicenseType)int.Parse(i_ExtraInfo[4]);
            m_EngineDisplacement = int.Parse(i_ExtraInfo[5]);
        }

        public override string CreateDetails()
        {
            string InfoMsg = string.Format(
@"{0}
License Type: {1}
Engine Displacement Size: {2}",
                base.CreateDetails(), m_LicenseType, m_EngineDisplacement);

            return InfoMsg;
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
