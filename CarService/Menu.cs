using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CarService
{
    internal class Menu
    {
        private List<Vehicle> vehicles;

        public Menu()
        {
            this.vehicles = new List<Vehicle>();
        }
        public Menu(List<Vehicle> vehicles)
        {
            this.vehicles = vehicles;
        }

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                ShowOptions();
                int option = InputOptionInRange(1, 4);

                switch (option)
                {
                    case 1:
                        // перехід до вибору авто
                        break;
                    case 2:
                        AddCarFromInput();
                        break;
                    case 3:
                        ShowDataSet();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void ShowOptions()
        {
            Console.WriteLine("1. Go to car selection.");
            Console.WriteLine("2. Add vehicle to dataset.");
            Console.WriteLine("3. Show dataset.");
            Console.WriteLine("4. Close program.");
        }
        private static int InputOptionInRange(int low, int upp)
        {
            while (true)
            {
                int value = ReadInt("Your option: ");

                if (IsInInterval(value, low, upp))
                {
                    return value;
                }

                Console.WriteLine($"Enter a number in [{low}, {upp}]");
            }

        }
        private static int ReadInt(string text)
        {
            while (true)
            {
                Console.Write(text);
                string input = Console.ReadLine();
                int value;
                if (int.TryParse(input, out value))
                {
                    return value;
                }
                Console.WriteLine("Invalid input. Enter a number");
            }
        }
        private static double ReadDouble(string text)
        {
            while (true)
            {
                Console.Write(text);
                string input = Console.ReadLine();
                double value;
                if (double.TryParse(input, out value))
                {
                    return value;
                }
                Console.WriteLine("Invalid input. Enter a number");
            }
        }
        private static string ReadString(string text)
        {
            Console.Write(text);
            return Console.ReadLine() ?? "";
        }
        private static bool IsInInterval(int value, int low, int upp)
        {
            return (value >= low && value <= upp);
        }

        private void AddCarFromInput()
        {
            Console.WriteLine("Enter vehicle data (Type|Brand|Model|Year|Price|EngVol|EngType|ExtraField) :");

            string line = Console.ReadLine();

            string[] parts = line.Split('|');

            Vehicle vehicle;

            switch (parts[0].ToLower())
            {
                case "car":
                    vehicle = new Car();
                    break;
                case "truck":
                    vehicle = new Truck();
                    break;
                case "mixed":
                    vehicle = new MixedVehicle();
                    break;
                default:
                    vehicle = null;
                    break;
            }

            if (vehicle == null)
                throw new Exception("Unspecified car type");

            vehicle.Read(parts);

            this.vehicles.Add(vehicle);
        }

        
        private void ShowDataSet()
        {
            foreach (Vehicle vehicle in this.vehicles)
            {
                Console.WriteLine(vehicle);
            }
        }
    }
}
