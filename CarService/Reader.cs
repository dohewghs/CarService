using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal class Reader
    {
        public static int InputOptionInRange(int low, int upp)
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
        public static int ReadInt(string text)
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
