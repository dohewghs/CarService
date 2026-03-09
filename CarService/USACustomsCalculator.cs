using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal class USACustomsCalculator : ICustomsCalculator
    {
        private const double fixedFee = 25.0; // Фіксований збір за оформлення
        private const double ecoTaxCoefficient = 0.12;  // Наприклад, для США це Gas Guzzler Tax
        private const double salesTaxRate = 0.07;       // Середній податок з продажу (ПДВ)
        double CalculateCustoms(Vehicle vehicle)
        {
            double dutyRate = vehicle switch
            {
                Truck => 0.25,      
                MixedVehicle => 0.10,      
                Car => 0.025,       
                _ => 0.05           
            };

            double importTax = dutyRate * vehicle.GetBasePrice();

            double ecoTax = vehicle.GetEngine().GetVolume() * ecoTaxCoefficient;

            double taxableBase = vehicle.GetBasePrice() + importTax + ecoTax + fixedFee;

            double salesTax = taxableBase * salesTaxRate;

            return importTax + ecoTax + salesTax + fixedFee;

        }
    }
}
