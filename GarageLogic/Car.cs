using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        eColor m_Color;
        eNumOfDoors m_NumOfDoors;

        public Car(eVehicleType i_VehicleType, string i_plateNumber) : base(4, 32, i_VehicleType, i_plateNumber)
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

        public static new string MoreInfoMessage()
        {
            string AskForInfoMsg = string.Format(
                @"{0}
                5) Color: (1 = Red, 2 = White, 3 = Black, 4 = Silver)
                6) Number Of Doors(2 - 5)",
                Vehicle.MoreInfoMessage());

            return AskForInfoMsg;
        }
      
        public new void AddInfo(string[] i_ExtraInfo) // To Do : add Exeptions/IfElse
        {
            (this as Vehicle).AddInfo(i_ExtraInfo);
            m_Color = (eColor)int.Parse(i_ExtraInfo[4]);
            m_NumOfDoors = (eNumOfDoors)int.Parse(i_ExtraInfo[5]);
        }

        public new string ToString()
        { 
            string InfoMsg = string.Format(@"
                {0}
                5) Color: {1}
                6) Number Of Doors: {2}",
                (this as Vehicle).ToString(), m_Color, m_NumOfDoors);

            return InfoMsg;
        }

        public eColor Color 
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
        public eNumOfDoors NumOfDoors 
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

