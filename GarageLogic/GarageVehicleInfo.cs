using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class GarageVehicleInfo
    {
        private string m_OwnerName;
        private string m_OwnerPhoneNumber;
        private eVehicleStatus m_VehicleStatus;
        private Vehicle m_Vehicle;

        public GarageVehicleInfo(string i_OwnerName, string i_OwnerPhone, Vehicle i_Vehicle)
        {
            m_OwnerName = i_OwnerName;
            m_OwnerPhoneNumber = i_OwnerPhone;
            m_VehicleStatus = eVehicleStatus.InProgress;
            m_Vehicle = i_Vehicle;  // ??? DeepClone ???
        }

        public eVehicleStatus Status
        {
            get 
            {
                return m_VehicleStatus;
            }
            set 
            {
                m_VehicleStatus = value; 
            }
        }

        public string OwnerName
        {
            get 
            {
                return m_OwnerName; 
            }
            set
            {
                m_OwnerName = value;
            }
        }

        public string PhoneNumber
        {
            get 
            { 
                return m_OwnerPhoneNumber;
            }
            set
            {
                m_OwnerPhoneNumber = value;
            }
        }

        public Vehicle Vehicle
        {
            get
            { 
                return m_Vehicle;
            }
            set 
            { 
                m_Vehicle = value;
            }
        }

    }
} 
    
