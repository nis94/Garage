using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentEnergyCapacity;
        protected readonly float r_MaxEnergyCapacity;
        protected readonly eEngineType r_EngineType;

        public Engine(float i_MaxEnergyCapacity, eEngineType i_EngineType)
        {
            r_MaxEnergyCapacity = i_MaxEnergyCapacity;
            r_EngineType = i_EngineType;
        }

        public float CurrentEnergyCapacity
        {
            get { return m_CurrentEnergyCapacity; }
            set { m_CurrentEnergyCapacity = value; }
        }

        public float MaxEnergyCapacity
        {
            get { return r_MaxEnergyCapacity; }
        }
        public eEngineType Type
        {
            get { return r_EngineType; }
        }
    }
}
