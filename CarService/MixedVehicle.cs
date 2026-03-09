using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal class MixedVehicle
    {
        double loadCapacity;

        public MixedVehicle(string _brand = "", string _model = "", int _year = 0, double _basePrice = 0, double _loadCapacity, Engine _engine = null) :
            base(_engine, _brand, _model, _year, _basePrice)
        {
            this.loadCapacity = _loadCapacity;
        }
    }
}
