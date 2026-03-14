using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    internal class ConsoleUserController : IUserController
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
