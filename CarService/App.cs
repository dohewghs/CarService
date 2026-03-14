using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CarService
{
    internal class App
    {
        private List<Vehicle> vehicles;
        private CarSelection carSelection;
        private IView view;
        public App(IView _view, VehicleService _service, CarSelection _selection)
        {
            this.carSelection = _selection;
            this.view = _view;
        }
        public App(List<Vehicle> vehicles)
        {
            this.vehicles = vehicles;
            this.carSelection = new CarSelection();
        }

        public void Run()
        {
            ReadDataFrom("..\\..\\..\\..\\DataSet.txt");

            bool isRunning = true;

            while (isRunning)
            {
                

                ShowOptions();
                int option = Reader.InputOptionInRange(1, 4);

                switch (option)
                {
                    case 1:
                        this.view.Clear();
                        this.carSelection.Run(this.vehicles);
                        break;
                    case 2:
                        AddCarFromInput();
                        this.view.Clear();
                        break;
                    case 3:
                        ShowDataSet();
                        break;
                    case 4:
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }
        
        private void ReadDataFrom(string filePath)
        {
            if (!File.Exists(filePath))
            {
                this.view.WriteLine("File not found!");
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                Vehicle vehicle = MakeVehicle(line);
                this.vehicles.Add(vehicle);
            }
        }
        private void ShowOptions()
        {
            this.view.WriteLine("1. Go to car selection.");
            this.view.WriteLine("2. Add vehicle to dataset.");
            this.view.WriteLine("3. Show dataset.");
            this.view.WriteLine("4. Close program.");
        }
        private void AddCarFromInput()
        {
            this.view.WriteLine("Enter vehicle data (Type|Brand|Model|Year|Price|EngVol|EngType|ExtraField) :");

            string line = Console.ReadLine();

            Vehicle vehicle = MakeVehicle(line);

            this.vehicles.Add(vehicle);
        }

        private Vehicle MakeVehicle(string str)
        {
            string[] parts = str.Split('|');

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
        
        private void ShowDataSet()
        {
            foreach (Vehicle vehicle in this.vehicles)
            {
                this.view.WriteLine(vehicle.ToUIString());
            }
        }
    }
}
