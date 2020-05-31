using System;

namespace GarageLogic
{
    public class ElectricEngine : Engine
    {
        public ElectricEngine( float i_MaxCapacity): base(i_MaxCapacity, eEngineType.Electric)
        {
        }
        internal void ReCharge(float i_NumberOfHoursToAdd)
        {
            float updatedCurrentCapacity = m_CurrentEnergyCapacity + i_NumberOfHoursToAdd;
            if (updatedCurrentCapacity > r_MaxEnergyCapacity)
            {
                Console.WriteLine("Exceeding maximum battery charge"); //to do exception
            }
            else
            {
                m_CurrentEnergyCapacity = updatedCurrentCapacity;
            }
        }
    }
}
