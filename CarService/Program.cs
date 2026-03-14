using CarService;

class Program
{
    public static int Main(string[] args)
    {
        IView view = new ViewToConsole();
        VehicleService service = new VehicleService();
        ICustomsCalculator customsCals = new UACustomsCalculator();
        ISurchargeStrategy surcharge = new SurchargeStrategyPercent();

        CarSelection selection = new CarSelection(view, customsCals, surcharge);

        App menu = new App(view, service, selection);

        menu.Run();
        return 0;
    }
}