using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class FuelEngine : Engine
    {
        private readonly eFuelType r_FuelType; 

        public FuelEngine(float i_MaxTankCapacity, eFuelType i_FuelType) : base(i_MaxTankCapacity, eEngineType.Fuel)
        {
            r_FuelType = i_FuelType; 
        }

        public eFuelType FuelType
        {
            get { return r_FuelType;  }
        }

        internal void ReFuel(float i_NumberOfLittersToAdd)
        {
            float updatedCurrentCapacity = m_CurrentEnergyCapacity + i_NumberOfLittersToAdd;
            if (updatedCurrentCapacity > r_MaxEnergyCapacity)
            {
                Console.WriteLine("Exceeding maximum battery charge"); //to do throw exception
            }
            else
            {
                m_CurrentEnergyCapacity = updatedCurrentCapacity;
            }
        }
    }
}
