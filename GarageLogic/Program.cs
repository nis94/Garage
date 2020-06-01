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
            Motorbike NirMB = VehicleCreator.CreateNewVehicle(eVehicleType.FuelMotorbike, "205489651") as Motorbike;
            Console.WriteLine(NirMB.MoreInfoMessage());
            string[] str_arr = { "JoyMax", "5.4", "2", "250", "23.4", "Mischlen" };
            NirMB.AddInfo(str_arr);

            Console.ReadLine();
        }
    }
}
