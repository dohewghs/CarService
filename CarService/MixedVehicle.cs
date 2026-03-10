using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal class MixedVehicle : Vehicle
    {
        double loadCapacity;

        public MixedVehicle(string _brand = "", string _model = "", int _year = 0, double _basePrice = 0, double _loadCapacity = 0, Engine _engine = null) :
            base(_brand, _model, _year, _basePrice, _engine)
        {
            this.loadCapacity = _loadCapacity;
        }
    }
}
