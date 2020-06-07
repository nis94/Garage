using System;

namespace Ex03.ConsoleUI
{
    public class Program
    {
        public static void Main()
        {
            GarageMenu GM = new GarageMenu();

            Console.WriteLine("---WELLCOME TO THE AMAZING GARAGE---");
            GM.RunMenu(); 
        }
    }
}
