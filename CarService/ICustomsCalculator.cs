using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal interface ICustomsCalculator
    {
        double CalculateCustoms(Vehicle vehicle);
    }


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


    internal class UACustomsCalculator : ICustomsCalculator
    {
        private const double exciseCoefitient = 0.2;
        private const double percentForCustoms = 0.2;
        public double CalculateCustoms(Vehicle vehicle)
        {
            int currentYear = DateTime.Now.Year;

            int vehicleAge = currentYear - vehicle.Year;
            if (vehicleAge <= 0)
                vehicleAge = 1;

            double vehicleEngineVolume = vehicle.Engine.Volume;

            double excise = exciseCoefitient * vehicleEngineVolume * vehicleAge;

            double customs = vehicle.BasePrice * percentForCustoms;

            double tax = 0.2 * (vehicle.BasePrice + excise + customs);

            return excise + customs + tax;
        }
    }


    internal class USACustomsCalculator : ICustomsCalculator
    {
        private const double fixedFee = 25.0;
        private const double ecoTaxCoefficient = 0.12;
        private const double salesTaxRate = 0.07;
        public double CalculateCustoms(Vehicle vehicle)
        {
            double dutyRate = vehicle switch
            {
                Truck => 0.25,
                MixedVehicle => 0.10,
                Car => 0.025,
                _ => 0.05
            };

            double importTax = dutyRate * vehicle.BasePrice;

            double ecoTax = vehicle.BasePrice * ecoTaxCoefficient;

            double taxableBase = vehicle.BasePrice + importTax + ecoTax + fixedFee;

            double salesTax = taxableBase * salesTaxRate;

            return importTax + ecoTax + salesTax + fixedFee;

        }
    }
}
