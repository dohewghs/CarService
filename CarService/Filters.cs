using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CarService
{
    internal class Filters
    {
        private string brand;
        private string model;
        private Interval yearInterval;
        private Interval priceInterval;
        private Interval engVolumeInterval;
        private EngineType engineType;

        private IView view;
        private IUserController userController;
        public Filters()
        {
            this.brand = string.Empty;
            this.model = string.Empty;
            this.yearInterval = new Interval(1990, 2010);
            this.priceInterval = new Interval(0, 5000);
            this.engVolumeInterval = new Interval(1000, 2000);
            this.engineType = EngineType.petrol;

            this.view = new ViewToConsole();
            this.userController = new ConsoleUserController();
        }

        public void ShowFilters(string text)
        {
            this.view.WriteLine(text);
            this.view.WriteLine($"Brand: {this.brand}");
            this.view.WriteLine($"Model: {this.model}");
            this.view.WriteLine($"Year: {this.yearInterval.Lower}-{this.yearInterval.Upper}");
            this.view.WriteLine($"Engine type: {this.engineType}");
            this.view.WriteLine($"Engine volume: {this.engVolumeInterval.Lower}-{this.engVolumeInterval.Upper}" );
            this.view.WriteLine($"Price: {this.priceInterval.Lower}-{this.priceInterval.Upper}");
        }

        public bool IsSuitable(Vehicle vehicle)
        {
            if (vehicle == null ||
                vehicle.Engine.Type != this.engineType ||
                !this.yearInterval.IsInInterval(vehicle.Year) ||
                !this.priceInterval.IsInInterval(vehicle.BasePrice) ||
                !this.engVolumeInterval.IsInInterval(vehicle.Engine.Volume)
                )
            {
                return false;
            }

            if (this.model != string.Empty && this.model != vehicle.Model ||
                this.brand != string.Empty && this.brand != vehicle.Brand
                )
            {
                return false;
            }

            return true;
        }
        public void Change()
        {
            this.view.Clear();

            this.view.WriteLine("1. Brand \n2. Model\n3. Year\n4. Engine type\n5. Engine volume\n6. Price");

            int option = Reader.InputOptionInRange(1, 6);

            switch (option)
            {
                case 1:
                    EnterBrand();
                    break;
                case 2:
                    EnterModel();
                    break;
                case 3:
                    EnterYear();
                    break;
                case 4:
                    EnterEngineType();
                    break;
                case 5:
                    EnterVolume();
                    break;
                case 6:
                    EnterPrice();
                    break;
                default:
                    break;
            }
        }

        private void EnterBrand()
        {
            this.view.Write("Enter Brand: ");

            this.brand = new string(Console.ReadLine());
        }
        private void EnterModel()
        {
            this.view.Write("Enter model: ");
            this.model = this.userController.ReadLine();
        }
        private void EnterYear()
        {
            this.view.WriteLine("Enter Interval: ");
            string str = this.userController.ReadLine();
            string[] parts = str.Split(' ');
            this.yearInterval.Lower = int.Parse(parts[0]);
            this.yearInterval.Upper = int.Parse(parts[1]);
        }
        private void EnterEngineType()
        {
            this.view.Write("Enter engine type: ");
            this.engineType = Enum.Parse<EngineType>(Console.ReadLine());
        }
        private void EnterVolume()
        {
            this.view.WriteLine("Enter Interval: ");
            string str = Console.ReadLine();
            string[] parts = str.Split(' ');
            this.engVolumeInterval.Lower = int.Parse(parts[0]);
            this.engVolumeInterval.Upper = int.Parse(parts[1]);
        }
        private void EnterPrice()
        {
            this.view.WriteLine("Enter Interval: ");
            string str = Console.ReadLine();
            string[] parts = str.Split(' ');
            this.priceInterval.Lower = int.Parse(parts[0]);
            this.priceInterval.Upper = int.Parse(parts[1]);
        }
    }
}
