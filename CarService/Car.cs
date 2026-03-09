using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal class Car : Vehicle
    {
        public Car(Engine _engine, string _brand = "", string _model = "", int _year = 0, double _basePrice = 0) : 
            base(_engine, _brand, _model, _year, _basePrice)
        {
        }
    }
}
