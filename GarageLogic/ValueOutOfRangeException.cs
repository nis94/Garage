using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private const string m_ExceptionMessage = "The value must be between {0} and {1}";
        private float m_MinValue;
        private float m_MaxValue;

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_StringFromOutSide)
            : base(string.Format(m_ExceptionMessage, i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MinValue;
        }
    }
}
