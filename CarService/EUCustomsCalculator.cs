using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal class EUCustomsCalculator : ICustomsCalculator
    {
        private const double fixedCustoms = 15;
        private const double ecoTaxCoefitient = 0.15;
        private const double taxCoefitient = 0.2;
        public double CalculateCustoms(Vehicle vehicle)
        {
            double ecoTax = vehicle.Engine.Volume * ecoTaxCoefitient;

            double subTotal = ecoTax + fixedCustoms;

            double tax = taxCoefitient * subTotal;

            return tax + subTotal;
        }
    }
}
