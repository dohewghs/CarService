using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    internal interface IView
    {
        string GetUserInput(string message);
        void DisplayMessageEndl(string message);
        void DisplayMessage(string message);
        void Clear();
    }
}
