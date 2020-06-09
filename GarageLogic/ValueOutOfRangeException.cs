using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class ValueOutOfRangeException : Exception
    {
        private const string m_ExceptionMessage = "The {0} must be between {1} and {2}";

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, string i_StringFromOutSide)
            : base(string.Format(m_ExceptionMessage, i_StringFromOutSide, i_MinValue, i_MaxValue))
        {
        }
    }
}
