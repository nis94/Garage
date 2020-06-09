using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class VehicleCreator
    {
        public static Vehicle CreateNewVehicle(eVehicleType i_VehicleType, string i_plateNumber)
        {
            Vehicle newVehicle = null;

            switch (i_VehicleType)
            {
                case eVehicleType.FuelCar:
                    newVehicle = new Car(eVehicleType.FuelCar, i_plateNumber);
                    break;
                case eVehicleType.ElectricCar:
                    newVehicle = new Car(eVehicleType.ElectricCar, i_plateNumber);
                    break;
                case eVehicleType.FuelMotorbike:
                    newVehicle = new Motorbike(eVehicleType.FuelMotorbike, i_plateNumber);
                    break;
                case eVehicleType.ElectricMotorbike:
                    newVehicle = new Motorbike(eVehicleType.ElectricMotorbike, i_plateNumber);
                    break;
                case eVehicleType.Truck:
                    newVehicle = new Truck(eVehicleType.Truck, i_plateNumber);
                    break;
                default:
                    break;
            }

            return newVehicle;
        }
    }
}
