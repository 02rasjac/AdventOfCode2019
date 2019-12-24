using System;
using System.IO;

namespace Day1
{
    class Program
    {
        static private int totalFuel = 0;

        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("Input.txt");
            string filerow = "";

            while ((filerow = sr.ReadLine()) != null)
            {
                int mass = int.Parse(filerow);
                CalculateFuelReq(mass);
            }

            Console.WriteLine("Total Fuel: " + totalFuel);

            Console.ReadLine();
        }

        static void CalculateFuelReq(int mass)
        {
            int fuel = 0;
            fuel += (mass / 3) - 2;

            if (fuel > 0)
            {
                totalFuel += fuel;

                CalculateFuelReq(fuel);
            }
        }
    }
}
