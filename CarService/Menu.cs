using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal class Menu
    {
        public static void Run()
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
                        //додати машину до датасету
                        break;
                    case 3:
                        //показати датасет
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


    }
}
