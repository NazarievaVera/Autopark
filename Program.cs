using Car_Dealership;
using Car_Dealership.Models;
using Car_Dealership.Menu;
using NLog;

class Program
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    static void Main(string[] args)
    {
        logger.Info("Программа запущена");
        logger.Debug($"Версия: Car Dealership v1.0");
        try
        {
            AutoPark park = new AutoPark(10000000);
            logger.Info($"Автопарк создан с балансом: {park.Balance:N0} руб.");

            park.InitCar();
            logger.Info("Инициализация начальных машин завершена");

            var lada = new Car("New Lada", 2020, 3_450_000);
            MainMenu.Show(park);

            logger.Info("Программа завершена");
        }

        catch (Exception ex)
        {
            logger.Error(ex, "Критическая ошибка в программе");
            Console.WriteLine($" Критическая ошибка: {ex.Message}");
        }
    }
}