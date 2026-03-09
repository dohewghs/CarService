using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal interface ICustomsCalculator
    {
        double CalculateCustoms(Vehicle vehicle);
    }
}
