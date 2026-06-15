using Car_Dealership.Models;
using NLog;

namespace Car_Dealership;

public static class Creating_vechicle
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    private static readonly Random _random = new Random();

    public static Info GenerateRandomVehicle()
    {
        logger.Info("Генерация случайного транспортного средства");
        int chance = _random.Next(0, 100);
        logger.Debug($"Шанс выпал: {chance} (0-39: Car, 40-69: Truck, 70-99: Bus)");

        Info vehicle = chance switch
        {
            < 40 => GenerateRandomCar(),
            < 70 => GenerateRandomTruck(),
            _ => GenerateRandomBus()
        };
        logger.Info(
            $"Сгенерировано: {vehicle.Type.GetTypeName()} | {vehicle.Model} ({vehicle.Year}) | {vehicle.Price:N0} руб.");
        return vehicle;
    }

    public static Car GenerateRandomCar()
    {
        try
        {
            string model = Car.Models[_random.Next(Car.Models.Length)];
            int price = _random.Next(Car.PriceRange.min, Car.PriceRange.max + 1);
            int year = _random.Next(2015, 2027);
            logger.Debug($"Легковая: {model} ({year}) | Цена: {price:N0} руб.");

            return Car.Create(model, year, price);
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Ошибка при генерации легковой машины");
            throw;
        }
    }

    public static Bus GenerateRandomBus()
    {
        try
        {
            string model = Bus.Models[_random.Next(Bus.Models.Length)];
            int price = _random.Next(Bus.PriceRange.min, Bus.PriceRange.max + 1);
            int year = _random.Next(2012, 2027);
            int passengers = _random.Next(20, 80);
            logger.Debug($"Автобус: {model} ({year}) | Цена: {price:N0} руб.");

            return Bus.Create(model, year, price, passengers);
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Ошибка при генерации автобуса");
            throw;
        }
    }


    public static Truck GenerateRandomTruck()
    {
        try
        {
            string model = Truck.Models[_random.Next(Truck.Models.Length)];
            int price = _random.Next(Truck.PriceRange.min, Truck.PriceRange.max + 1);
            int year = _random.Next(2010, 2027);
            int capacity = _random.Next(5, 40);
            logger.Debug($"Грузовик: {model} ({year}) | Цена: {price:N0} руб. ");

            return Truck.Create(model, year, price, capacity);
        }
        catch (Exception ex)
        {
            logger.Error(ex, "Ошибка при генерации грузовика");
            throw;
        }
    }
}