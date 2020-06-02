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
            Console.WriteLine(Motorbike.MoreInfoMessage());
            string[] str_arr = { "JoyMax", "5.4", "23.4", "Mischlen", "2", "250" };
            NirMB.AddInfo(str_arr);
            Console.WriteLine(NirMB.ToString());

            Console.ReadLine();
        }
    }
}
