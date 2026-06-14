using Car_Dealership;
using Car_Dealership.Models;
using Car_Dealership.Menu;
using NLog;

class Program
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    static void Main(string[] args)
    {
        //logger.Info("NLog работает!");
        //logger.Debug("Отладочное сообщение");

        AutoPark park = new AutoPark(10000000);
        park.InitCar();

        var lada = new Car("New Lada", 2020, 3_450_000);
        MainMenu.Show(park);
    }
}