using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal class Car : Vehicle
    {
        public Car(string _brand = "", string _model = "", int _year = 0, double _basePrice = 0, Engine _engine = null) : 
            base(_engine, _brand, _model, _year, _basePrice)
        {
        }
    }
}
