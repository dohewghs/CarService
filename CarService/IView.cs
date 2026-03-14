using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    internal interface IView
    {
        void Write(string text);
        void WriteLine(string text);
        void Clear();
    }
}
