using System;
using System.Collections.Generic;
using System.Text;

namespace CarService
{
    internal class Engine
    {
        public double Volume { get; private set; }
        public EngineType Type { get; private set; }

        public Engine(double _volume = 0, EngineType _type = EngineType.petrol)
        {
            this.Volume = _volume;
            this.Type = _type;
        }

        public double GetVolume() => this.Volume;

        public override string ToString() => $"{Volume}|{Type}";

        public string ToUIString() => $"{Volume} {Type}";
    }

    internal enum EngineType
    {
        petrol,
        diesel,
        hybrid,
        electric
    }
}
