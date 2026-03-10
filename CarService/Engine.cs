using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal class Engine
    {
        private double volume;
        private EngineType type;

        public Engine(double _volume = 0, EngineType _type = EngineType.petrol)
        {
            this.volume = _volume;
            this.type = _type;
        }

        public double GetVolume() => this.volume;

        public override string ToString() => $"{volume}|{type}";
    }

    internal enum EngineType
    {
        petrol,
        diesel,
        hybrid,
        electric
    }
}
