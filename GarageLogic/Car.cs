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

        public override string MoreInfoMessage()
        {
            string Message = string.Format(@"Please enter the following information, (after every detail press ENTER):
                1) Model name
                2) Current Energy Capacity
                3) Color: (1-Red, 2-White, 3-Black, 4-Silver)
                4) Number Of Doors (2-5) 
                5) Current Air Pressure(0-32)
                6) Wheels Manufacturer Name");

            return Message;
        }

        public override void AddInfo(string[] i_ExtraInfo) // To Do : add Exeptions/IfElse
        {
            m_ModelName = i_ExtraInfo[0];
            m_Engine.CurrentEnergyCapacity = float.Parse(i_ExtraInfo[1]);
            m_EnergyPresentage = (m_Engine.CurrentEnergyCapacity / m_Engine.MaxEnergyCapacity) * 100;
            m_Color = (eColor)int.Parse(i_ExtraInfo[2]);
            m_NumOfDoors = (eNumOfDoors)int.Parse(i_ExtraInfo[3]);
            foreach (Wheel wheel in m_Wheels)
            {
                wheel.CurrentAirPresuure = float.Parse(i_ExtraInfo[4]);
                wheel.ManufacturerName = i_ExtraInfo[5];
            }
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

