using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    internal interface IView
    {
        string ReadLine();
        void WriteLine(string message);
        void Write(string message);
        void Clear();
    }
}
