using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CarService
{
    internal class CarSelection
    {
        private List<bool> suitableVehicles;
        private Vehicle choosenVehicle;
        private Filters filters;

        private ISurchargeStrategy surcharge;
        private ICustomsCalculator customsCalculator;
        private IView view;
        public CarSelection(IView _view, ICustomsCalculator _calculator, ISurchargeStrategy _surcharge)
        {
            this.view = _view;
            this.customsCalculator = _calculator;
            this.surcharge = _surcharge;

            this.suitableVehicles = new List<bool>();
            this.filters = new Filters(_view); 
        }
        public void Run(List<Vehicle> list)
        {
            bool isRunning = true;
            while (isRunning)
            {
                this.view.Clear();

                MakeAvailableList(list);

                ShowChoosenVehicle(this.choosenVehicle);
                filters.ShowFilters("Filters: ");
                ShowAvailableCars(list);
                ShowOption();

                int option = this.view.InputOptionInRange(0, 3);

                switch (option)
                {
                    case 0:
                        isRunning = false;
                        break;
                    case 1:
                        filters.Change();
                        break;
                    case 2:
                        ChooseVehicle(list);
                        break;
                    case 3:
                        FinalPrice();
                        break;
                    default:
                        break;
                }

            }
        }
        private void MakeAvailableList(List<Vehicle> list)
        {
            this.suitableVehicles.Clear();
            this.suitableVehicles = new List<bool>(list.Count+1);

            for (int i = 0; i < list.Count; i++)
            {
                bool isSuitable = filters.IsSuitable(list[i]);
                this.suitableVehicles.Add(isSuitable);
            }
        }
        private void ShowChoosenVehicle(Vehicle vehicle)
        {
            this.view.Write("Choosen vehicle: ");
            string? vehicleText = (vehicle == null) ? "" : vehicle.ToUIString();

            this.view.WriteLine(vehicleText);
        }
        private void ShowOption()
        {
            this.view.WriteLine("1. Change filters.");
            this.view.WriteLine("2. Choose car.");
            this.view.WriteLine("3. CalculatePrice.");
            this.view.WriteLine("0. Go back.");
        }
        private void ShowAvailableCars(List<Vehicle> list)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                if (this.suitableVehicles[i])
                {
                    this.view.WriteLine(i + "." + list[i].ToUIString());

                }
            }
        }
        private void ChooseVehicle(List<Vehicle> list)
        {
            int index = this.view.ReadInt("Enter index of car you want: ");

            if (index < 0 || index >= list.Count)
            {
                return;
            }

            if (!this.suitableVehicles[index])
            {
                return;
            }

            this.choosenVehicle = list[index];
        }

        private void FinalPrice()
        {
            if (this.choosenVehicle == null)
                return;

            double customs = this.customsCalculator.CalculateCustoms(this.choosenVehicle);
            double extraFromSeller = this.surcharge.CalculateSurcharge(this.choosenVehicle);
            double total = choosenVehicle.BasePrice + customs + extraFromSeller;

            this.view.WriteLine("---Total Price---");
            this.view.WriteLine($"{this.choosenVehicle.Brand} {this.choosenVehicle.Model} {this.choosenVehicle.Year}");
            this.view.WriteLine($"Base price: {this.choosenVehicle.BasePrice}");
            this.view.WriteLine($"Customs: {customs}");
            this.view.WriteLine($"Surcharge: {extraFromSeller}");
            this.view.WriteLine($"Total is {total}");

            this.view.WriteLine("\nPress enter to continue...");
            this.view.ReadLine();
        }
    }
}
