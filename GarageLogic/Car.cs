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

        public Car(eColor i__Color, eNumOfDoors i_NumOfDoors, string i_Model, eEngineType i_EngineType, string i_PlateNumber,
             string i_WheelManufacturerName, float i_CurrentEnergyCapacity, eVehicleType i_VehicleType)
            : base(i_Model, i_PlateNumber, 4, 32, i_WheelManufacturerName, i_VehicleType)
        {
            m_Color=i__Color;
            m_NumOfDoors=i_NumOfDoors;
            if (i_EngineType.Equals(eEngineType.Electric)) 
            {
                m_Engine = new ElectricEngine(2.1f, i_CurrentEnergyCapacity);
            }
            else
            {
                m_Engine = new FuelEngine(60f, i_CurrentEnergyCapacity, eFuelType.Octan96);
            }
            m_EnergyPresentage = (m_Engine.CurrentEnergyCapacity / m_Engine.MaxEnergyCapacity) * 100;
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

