using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace CarService
{
    internal class App
    {
        private CarSelection carSelection;
        private IView view;
        private VehicleService vehicleService;
        public App(IView _view, VehicleService _service, CarSelection _selection)
        {
            this.carSelection = _selection;
            this.vehicleService = _service;
            this.view = _view;
        }
        public void Run()
        {
            this.vehicleService.LoadFromFile("..\\..\\..\\..\\DataSet.txt");

            bool isRunning = true;

            while (isRunning)
            {
                ShowOptions();

                int option = view.InputOptionInRange(1, 4);

                switch (option)
                {
                    case 1:
                        this.view.Clear();
                        this.carSelection.Run(vehicleService.GetAll());
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
        
        private void ShowOptions()
        {
            this.view.WriteLine("1. Go to car selection.");
            this.view.WriteLine("2. Add vehicle to dataset.");
            this.view.WriteLine("3. Show dataset.");
            this.view.WriteLine("4. Close program.");
        }
        private void AddCarFromInput()
        {
            string line = this.view.ReadLine("Enter vehicle data (Type|Brand|Model|Year|Price|EngVol|EngType|ExtraField) :");

            try
            {
                Vehicle vehicle = VehicleFactory.Create(line);

                this.vehicleService.Add(vehicle);
            }
            catch (Exception ex)
            {
                this.view.WriteLine($"Error: {ex.Message}");
            }
        }

        private void ShowDataSet()
        {
            foreach (Vehicle vehicle in this.vehicleService.GetAll())
            {
                this.view.WriteLine(vehicle.ToUIString());
            }
        }
    }
}
