using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        eColor m_Color;
        eNumOfDoors m_NumOfDoors;

        internal Car(eVehicleType i_VehicleType, string i_plateNumber) : base(4, 32, i_VehicleType, i_plateNumber)
        {
            if (i_VehicleType.Equals(eVehicleType.ElectricCar)) 
            {
                m_Engine = new ElectricEngine(2.1f);
            }
            else
            {
                m_Engine = new FuelEngine(60f, eFuelType.Octan96);
            }
        }

        public override List<string> MoreInfoMessage()
        {
            List<string> AskForInfoMsg = base.MoreInfoMessage();
            AskForInfoMsg.Add("Color (1-Red, 2-White, 3-Black, 4-Silver)");
            AskForInfoMsg.Add("Number Of Doors(2 - 5)");

            return AskForInfoMsg;
        }

        public override void AddInfo(List<string> i_ExtraInfo) 
        {
            base.AddInfo(i_ExtraInfo);
            if (int.Parse(i_ExtraInfo[4])<=4&& int.Parse(i_ExtraInfo[4])>=1)
            {
                m_Color = (eColor)int.Parse(i_ExtraInfo[4]);
            }
            else
            {
                throw new ArgumentException("No such color option!, Please enter details again");
            }

            if (int.Parse(i_ExtraInfo[5]) <= 5 && int.Parse(i_ExtraInfo[5]) >= 2)
            {
                m_NumOfDoors = (eNumOfDoors)int.Parse(i_ExtraInfo[5]);
            }
            else
            {
                throw new ArgumentException("No such number of doors!, Please enter details again");
            }

        }

        public override string CreateDetails()
        { 
            string InfoMsg = string.Format(
@"{0}
Color: {1}
Number Of Doors: {2}",
                base.CreateDetails(), m_Color, m_NumOfDoors);

            return InfoMsg;
        }

        internal eColor Color 
        { 
            get
            {
                return m_Color;
            }
            set
            {
                m_Color = value;
            }
        }
        internal eNumOfDoors NumOfDoors 
        {
            get
            {
                return m_NumOfDoors;
            }
            set
            {
                m_NumOfDoors = value;
            }
        }

    }
}

