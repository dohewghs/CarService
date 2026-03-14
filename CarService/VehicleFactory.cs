using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    internal class VehicleFactory
    {
        public static Vehicle Create(string line)
        {
            string[] parts = line.Split('|');

            Vehicle vehicle;

            switch (parts[0].ToLower())
            {
                case "car":
                    vehicle = new Car();
                    break;
                case "truck":
                    vehicle = new Truck();
                    break;
                case "mixed":
                    vehicle = new MixedVehicle();
                    break;
                default:
                    vehicle = null;
                    break;
            }

            if (vehicle == null)
                throw new Exception("Unspecified car type");

            vehicle.Read(parts);

            return vehicle;
        }
    }
}
