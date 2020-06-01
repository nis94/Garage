using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Program
    {
        public static void Main()
        {
            Motorbike Nir = new Motorbike(eLicenseType.A, 250, "JoyMax", eEngineType.Fuel, "A-054-89-165", "Ogja", 4f); // test
            Motorbike Liran = new Motorbike(eLicenseType.B, 500, "SunYoung", eEngineType.Electric, "B-352-64-433", "Branch", 0.5f); // test
            Car Leti = new Car(eColor.white, eNumOfDoors.four, "Ibiza", eEngineType.Fuel, "C-878-77-488", "Flot", 55f);
            Car Aya = new Car(eColor.red, eNumOfDoors.tow, "MiniCoper", eEngineType.Electric, "D-634-25-235", "Spla", 0.2f);
            Truck truck = new Truck(false, 200f, "TATA", "E-32-333-23", "Loopa", 100f);
                

            Console.ReadLine();
        }
    }
}
