using System;

namespace Ex03.GarageLogic
{
    public class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private readonly float r_MaxAirPressure; 

        public Wheel (float i_MaxAirPressure)
        {
            r_MaxAirPressure = i_MaxAirPressure;
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
            get 
            {
                return m_ManufacturerName;
            }
            set 
            { 
                m_ManufacturerName = value; 
            }
        }

        public float CurrentAirPresuure
        {
            get
            { 
                return m_CurrentAirPressure;
            }
            set
            {
                m_CurrentAirPressure = value;
            }
        }

        public float MaxAirPressure
        {
            get
            { 
                return r_MaxAirPressure; 
            }
        }
    }
}
