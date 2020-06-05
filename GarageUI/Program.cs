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
            Motorbike Nir = VehicleCreator.CreateNewVehicle(eVehicleType.FuelMotorbike, "205489651") as Motorbike;
            Car Liran = VehicleCreator.CreateNewVehicle(eVehicleType.ElectricCar, "111111111") as Car;
            Truck Boaz = VehicleCreator.CreateNewVehicle(eVehicleType.Truck, "123456789") as Truck;

            string[] nir_str_arr = { "JoyMax", "5.4", "23.4", "Mischlen", "2", "250" };
            Nir.AddInfo(nir_str_arr);

            string[] liran_str_arr = { "fiat", "1.7", "30", "Romina", "1", "4" };
            Liran.AddInfo(liran_str_arr);

            string[] boaz_str_arr = { "TATA", "20", "18", "Pompa", "true", "500" };
            Boaz.AddInfo(boaz_str_arr);

            GarageManager GM = new GarageManager();

            //1
            GM.InsertVehicle("nir", "0502603287", eVehicleType.FuelMotorbike, "205489651");
            GM.InsertVehicle("liran", "0528615483", eVehicleType.ElectricCar, "111111111");
            GM.InsertVehicle("boaz", "0523233500", eVehicleType.Truck, "123456789");

            ////----------------------------------------------------FIX FOR TEST--------------------------------------------------------------------
            GM.VehiclesStorage["205489651"].Vehicle = Nir;
            GM.VehiclesStorage["111111111"].Vehicle = Liran;
            GM.VehiclesStorage["123456789"].Vehicle = Boaz;
            //--------------------------------------------------------------------------------------------------------------------------------------

            //2+3
            foreach (string str in GM.ShowAllPlateNumbers())
            {
                Console.WriteLine(str + " ");
            }

            GM.ChangeVehicleStatus("111111111", eVehicleStatus.Paid);

            foreach (string str in GM.ShowFilteredPlateNumbers(eVehicleStatus.InProgress))
            {
                Console.WriteLine(str + " ");
            }
            foreach (string str in GM.ShowFilteredPlateNumbers(eVehicleStatus.Fixed))
            {
                Console.WriteLine(str + " ");
            }
            foreach (string str in GM.ShowFilteredPlateNumbers(eVehicleStatus.Paid))
            {
                Console.WriteLine(str + " ");
            }

            //4
            GM.InflateWheels("123456789");

            //5+6
            GM.ReFuel("205489651", eFuelType.Octan95, 1.6f);
            GM.ReCharge("111111111", 0.4f);


            //7
            Console.WriteLine(GM.GetVehicleDetails("205489651"));
            Console.WriteLine(GM.GetVehicleDetails("111111111"));
            Console.WriteLine(GM.GetVehicleDetails("123456789"));
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(Nir.CreateDetails());

            Console.ReadLine();
        }
    }
}
