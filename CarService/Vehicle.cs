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


        public Engine GetEngine() => this.engine;
        public double GetBasePrice() => this.basePrice;
        public int GetYear() => this.year;

        public virtual string ToFileString()
        {
            return $"{brand}|{model}|{year}|{basePrice}|{engine}";
        }

        public void Read(string[] parts)
        {
            if (parts.Length < 7)
                throw new Exception("Not enough data in the row");

            MakeFrom(parts);
        }

        protected virtual void MakeFrom(string[] parts)
        {
            this.brand = parts[1];
            this.model = parts[2];
            this.year = int.Parse(parts[3]);
            this.basePrice = double.Parse(parts[4]);

            double engineVolume = double.Parse(parts[5]);
            EngineType engineType = (EngineType)Enum.Parse(typeof(EngineType), parts[6]);

            Engine _engine = new Engine(engineVolume, engineType);
            
            this.engine = _engine;
        }
    }
}
