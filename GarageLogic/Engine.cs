using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageLogic
{
    public abstract class Engine
    {
        protected float m_CurrentEnergyCapacity;
        protected readonly float r_MaxEnergyCapacity;
        protected readonly eEngineType r_EngineType;

        public Engine(float i_MaxCapacity, eEngineType i_Type)
        {
            r_MaxEnergyCapacity = i_MaxCapacity;
            r_EngineType = i_Type;
        }

        public float CurrentCapacity
        {
            get { return m_CurrentEnergyCapacity; }
            set { m_CurrentEnergyCapacity = value; }
        }

        public float MaxCapacity
        {
            get { return r_MaxEnergyCapacity; }
        }
        public eEngineType Type
        {
            get { return r_EngineType; }
        }
    }
}
