using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    internal static class ViewExtensions
    {
        public static int InputOptionInRange(this IView view, int low, int upp)
        {
            while (true)
            {
                int value = view.ReadInt("Your option: ");

                if (low <= value && value <= upp)
                {
                    return value;
                }

                Console.WriteLine($"Enter a number in [{low}, {upp}]");
            }

        }
        public static int ReadInt(this IView view, string text)
        {
            while (true)
            {
                view.Write(text);
                string input = view.ReadLine("");
                int value;
                if (int.TryParse(input, out value))
                {
                    return value;
                }
                view.WriteLine("Invalid input. Enter a number");
            }
        }


    }
}
