using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
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
