using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    class Car : Vehicle
    {
        eColor m_Color;
        eNumOfDoors m_NumOfDoors;

        public Car(eColor i__Color, eNumOfDoors i_NumOfDoors, int i_EngineDisplacement, string i_Model, eEngineType i_EngineType, string i_LicensNumber, float i_EnergyPresentage,
            float i_MaxAirPressure, string i_WheelManufacturerName) : base(i_Model, i_LicensNumber, 4, 32, i_WheelManufacturerName, i_EngineType)
        {
            m_Color=i__Color;
            m_NumOfDoors=i_NumOfDoors;
            if (i_EngineType.Equals(eEngineType.Electric)) // TO DO - override the Equals method
            {
                m_Engine = new ElectricEngine(2.1f);
            }
            else
            {
                m_Engine = new FuelEngine(60f, eFuelType.Octan96);
            }
            m_EnergyPresentage = (m_Engine.MaxEnergyCapacity / m_Engine.CurrentEnergyCapacity) * 100;
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

