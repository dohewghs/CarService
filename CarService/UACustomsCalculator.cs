using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal class UACustomsCalculator : ICustomsCalculator
    {
        private const double exciseCoefitient = 1.0;
        private const double percentForCustoms = 0.2;
        public double CalculateCustoms(Vehicle vehicle)
        {
            int currentYear = DateTime.Now.Year;

            int vehicleAge = currentYear - vehicle.GetYear();
            if (vehicleAge <= 0)
                vehicleAge = 1;

            double vehicleEngineVolume = vehicle.GetEngine().GetVolume();

            double excise = exciseCoefitient * vehicleEngineVolume * vehicleAge;

            double customs = vehicle.GetBasePrice() * percentForCustoms;

            double tax = 0.2 * (vehicle.GetBasePrice() + excise + customs);

            return excise + customs + tax;
        }
    }
}
