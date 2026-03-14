using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal class Vehicle
    {
        public string Brand { get; private set; }
        public string Model { get; private set; }
        public int Year { get; private set; }
        public double BasePrice { get; private set; }

        public Engine Engine { get; private set; }

        public Vehicle(string _brand = "", string _model = "", int _year = 0, double _basePrice = 0, Engine _engine = null)
        {
            this.Engine = _engine;

            this.Brand = _brand;
            this.Model = _model;
            this.Year = _year;
            this.BasePrice = _basePrice;
        }


        public virtual string ToFileString()
        {
            return $"{Brand}|{Model}|{Year}|{BasePrice}|{Engine}";
        }

        public virtual string ToUIString()
        {
            return $"{Brand} {Model} {Year} {BasePrice}$ {Engine.ToUIString()}";
        }
        public void Read(string[] parts)
        {
            if (parts.Length < 7)
                throw new Exception("Not enough data in the row");

            MakeFrom(parts);
        }
        protected virtual void MakeFrom(string[] parts)
        {
            this.Brand = parts[1];
            this.Model = parts[2];
            this.Year = int.Parse(parts[3]);
            this.BasePrice = double.Parse(parts[4]);

            double engineVolume = double.Parse(parts[5]);
            EngineType engineType = (EngineType)Enum.Parse(typeof(EngineType), parts[6]);

            Engine _engine = new Engine(engineVolume, engineType);
            
            this.Engine = _engine;
        }
    }
}
