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

        public void Write(string message)
        {
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
        public string ReadLine(string message)
        {
            return Console.ReadLine();
        }
    }
}
