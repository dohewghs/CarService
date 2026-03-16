using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    internal interface ISurchargeStrategy
    {
        double CalculateSurcharge(Vehicle vehicle);
    }


    internal class SurchargeStrategyPercent : ISurchargeStrategy
    {
        double percent;

        public SurchargeStrategyPercent(double percent = 0.1)
        {
            this.percent = percent;
        }
        public double CalculateSurcharge(Vehicle vehicle)
        {
            return this.percent * vehicle.BasePrice;
        }
    }
}
