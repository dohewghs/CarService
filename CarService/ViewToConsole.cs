using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    internal class ViewToConsole : IView
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void DisplayMessage(string message)
        {
            Console.Write(message);
        }

        public void DisplayMessageEndl(string message)
        {
            Console.WriteLine(message);
        }
        public string GetUserInput(string message)
        {
            return Console.ReadLine();
        }
    }
}
