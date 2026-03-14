using CarService;

class Program
{
    public static int Main(string[] args)
    {
        IView view = new ViewToConsole();
        VehicleService service = new VehicleService();
        CarSelection selection = new CarSelection();

        App menu = new App(view, service, selection);

        menu.Run();
        return 0;
    }
}