using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class VehicleCreator
    {
        public static Vehicle CreateNewVehicle(eVehicleType i_VehicleType, string i_plateNumber)
        {
            Vehicle o_NewVehicle = null;

            switch(i_VehicleType)
            {
                case eVehicleType.FuelCar:
                    o_NewVehicle = new Car(eVehicleType.FuelCar, i_plateNumber);
                    break;
                case eVehicleType.ElectricCar:
                    o_NewVehicle = new Car(eVehicleType.ElectricCar, i_plateNumber);
                    break;
                case eVehicleType.FuelMotorbike:
                    o_NewVehicle = new Motorbike(eVehicleType.FuelMotorbike, i_plateNumber);
                    break;
                case eVehicleType.ElectricMotorbike:
                    o_NewVehicle = new Motorbike(eVehicleType.ElectricMotorbike, i_plateNumber);
                    break;
                case eVehicleType.Truck:
                    o_NewVehicle = new Truck(i_plateNumber);
                    break;
                default:
                    break;

            }




            if (i_VehicleType == (int)eVehicleType)
            {
                o_NewVehicle = new Car(eVehicleType.Car, i_plateNumber);
            }
            else if (i_VehicleType == (int)eVehicleType.ElectricCar)
            {
                o_NewVehicle = new Car(eVehicleType.ElectricCar, i_plateNumber);
            }
            else if (i_VehicleType == (int)eVehicleType.MotorBike)
            {
                o_NewVehicle = new MotorBike(eVehicleType.MotorBike, i_plateNumber);
            }
            else if (i_VehicleType == (int)eVehicleType.ElectricMotorBike)
            {
                o_NewVehicle = new MotorBike(eVehicleType.ElectricMotorBike, i_plateNumber);
            }
            else if (i_VehicleType == (int)eVehicleType.Truck)
            {
                o_NewVehicle = new Truck(i_plateNumber);
            }

            return o_NewVehicle;
        }
    }
}

