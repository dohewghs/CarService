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
        private static bool IsInInterval(int value, int low, int upp)
        {
            return (value >= low && value <= upp);
        }

        private void AddCarFromInput()
        {
            Vehicle temp;
            Console.WriteLine("Enter type of vehicle (car, truck, mixed): ");
            string type = Console.ReadLine();

            switch (type.ToLower())
            {
                case "car":
                    temp = new Car();
                    break;
                case "truck":
                    temp = new Truck();
                    break;
                case "mixed":
                    temp = new MixedVehicle();
                    break;
                default:
                    break;
            }

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
