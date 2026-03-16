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

            Vehicle vehicle = MakeVehicle(parts[0].ToLower());

            if (vehicle == null)
                throw new Exception("Unspecified car type");

            vehicle.Read(parts);

            return vehicle;
        }

        public static Vehicle MakeVehicle(string line)
        {
            switch (line)
            {
                case "car":
                    return new Car();
                case "truck":
                    return new Truck();
                case "mixed":
                    return new MixedVehicle();
                default:
                    return null;
            }
        }
    }


    internal class VehicleService
    {
        private List<Vehicle> vehicles;

        public VehicleService()
        {
            vehicles = new List<Vehicle>();
        }
        public List<Vehicle> GetAll() => vehicles;
        public void LoadFromFile(string filePath)
        {
            if (!File.Exists(filePath))
                return;

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                vehicles.Add(VehicleFactory.Create(line));
            }
        }
        public void Add(Vehicle vehicle) => vehicles.Add(vehicle);
    }
}
