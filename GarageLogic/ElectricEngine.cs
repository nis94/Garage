using System;

namespace Ex03.GarageLogic
{
    public class ElectricEngine : Engine
    { 
        public ElectricEngine( float i_MaxBatteryCapacity) : base(i_MaxBatteryCapacity, eEngineType.Electric)
        {
        }

        internal void ReCharge(float i_NumberOfHoursToAdd)
        {
            float updatedCurrentCapacity = m_CurrentEnergyCapacity + i_NumberOfHoursToAdd;

            m_CurrentEnergyCapacity = updatedCurrentCapacity;
        }
    }
}
