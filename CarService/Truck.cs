using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal class Truck : Vehicle
    {
        double loadCapacity;

        public Truck(string _brand = "", string _model = "", int _year = 0, double _basePrice = 0, double _loadCapacity = 0, Engine _engine = null) :
            base(_brand, _model, _year, _basePrice, _engine)
        {
            this.loadCapacity = _loadCapacity;
        }

        public override string ToFileString()
        {
            return base.ToFileString() + $"|{loadCapacity}";
        }
        protected override void MakeFrom(string[] parts)
        {
            base.MakeFrom(parts);

            this.loadCapacity = double.Parse(parts[7]);
        }
    }
}
