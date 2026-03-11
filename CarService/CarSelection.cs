using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    internal class CarSelection
    {
        private List<bool> suitableVehicles;
        private Vehicle choosenVehicle;
        public void Run(List<Vehicle> list)
        {
            this.suitableVehicles = new List<bool>(list.Count);

            bool isRunning = true;
            while (isRunning)
            {
                ShowChoosenVehicle(this.choosenVehicle);
                ShowFilters();
                ShowOption();
                ShowList(list);

                Console.SetCursorPosition(Console.GetCursorPosition().Left - list.Count, 0);
                int option = InputOptionInRange(1, 4);

                switch (option)
                {
                    case 1:

                        break;
                    case 2:

                        break;
                    case 3:
                        
                        break;
                    case 4:

                        break;
                    default:
                        break;
                }

            }
        }

        private void ShowChoosenVehicle(Vehicle vehicle)
        {
            Console.Write("Choosen vehicle: ");
            string? vehicleText = (vehicle == null) ? "" : vehicle.ToString();

            Console.WriteLine(vehicleText);
        }
        private void ShowOption()
        {
            Console.WriteLine("1. Change filters.");
            Console.WriteLine("2. Choose car.");
            Console.WriteLine("3. Calculate full price.");
            Console.WriteLine("4. Go back.");
        }

        private void ShowList(List<Vehicle> list)
        {
            for(int i=0; i<list.Count; ++i)
            {
                Console.WriteLine(i + "." + list[i].ToString());
            }
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
    }
}
