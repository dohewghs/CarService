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

        public CarSelection()
        {
            suitableVehicles = new List<bool>();
            choosenVehicle = null;
            filters = new Filters();
        }
        public void Run(List<Vehicle> list)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                MakeAvailableList(list);

                ShowChoosenVehicle(this.choosenVehicle);
                filters.ShowFilters("Filters: ");
                ShowAvailableCars(list);
                ShowOption();

                int option = Reader.InputOptionInRange(0, 3);

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
            Console.Write("Choosen vehicle: ");
            string? vehicleText = (vehicle == null) ? "" : vehicle.ToUIString();

            Console.WriteLine(vehicleText);
        }
        private void ShowOption()
        {
            Console.WriteLine("1. Change filters.");
            Console.WriteLine("2. Choose car.");
            Console.WriteLine("3. CalculatePrice.");
            Console.WriteLine("0. Go back.");
        }
        private void ShowAvailableCars(List<Vehicle> list)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                if (this.suitableVehicles[i])
                {
                    Console.WriteLine(i + "." + list[i].ToUIString());

                }
            }
        }
        private void ChooseVehicle(List<Vehicle> list)
        {
            int index = Reader.ReadInt("Enter index of car you want: ");

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
    }
}
