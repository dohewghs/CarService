using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal class Vehicle
    {
        private string brand;
        private string model;
        private int year;
        private double basePrice;

        private Engine engine;

        public Vehicle(string _brand = "", string _model = "", int _year = 0, double _basePrice = 0, Engine _engine = null)
        {
            this.engine = _engine;

            this.brand = _brand;
            this.model = _model;
            this.year = _year;
            this.basePrice = _basePrice;
        }
        
    }
}
