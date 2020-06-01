using System;

namespace GarageLogic
{
    public class Wheel
    {
        private readonly string r_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure; 

        public Wheel (float i_MaxAirPressure, string i_ManufacturerName)
        {
            r_MaxAirPressure = i_MaxAirPressure;
            r_ManufacturerName = i_ManufacturerName;
        }

        public void InflateWheel (float i_AmountOfAirToAdd)
        {
            float UpdatedAirPressure = i_AmountOfAirToAdd + m_CurrentAirPressure;
            if (UpdatedAirPressure > r_MaxAirPressure)
            {
                Console.WriteLine("Exceeding the Maximum Air pressure"); //to do exception
            }
            else
            {
                m_CurrentAirPressure = UpdatedAirPressure; 
            }

        }

        public string ManufacturerName
        {
            get { return r_ManufacturerName; }
        }

        public float CurrentAirPresuure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public float MaxAirPressure
        {
            get { return r_MaxAirPressure; }
        }
    }
}
