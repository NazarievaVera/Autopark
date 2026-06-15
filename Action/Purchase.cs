using Car_Dealership.Models;

namespace Car_Dealership;

public partial class AutoPark
{
    // Покупка
    public void Add(Info info)
    {
        logger.Info($"Попытка покупки: {info.Model} ({info.Type.GetTypeName()}) за {info.Price:N0} руб.");
        
        // если хотябы 1 совпадает
        if (_vehicles.Any(v => v.InternalId == info.InternalId))
        {
            logger.Warn($"Дубликат! Машина {info.Model} (ID: {info.InternalId}) уже в автопарке");
            Console.WriteLine($"Машина с системным ID {info.InternalId} уже в автопарке. ");
            return;
        }

        if (_balance >= info.Price)
        {
            _balance -= info.Price;
            _vehicles.Add(info);
            logger.Info($"Куплено: №{info.SerialNumber} {info.Model} ({info.Type.GetTypeName()}) за {info.Price:N0} руб. Остаток: {_balance:N0} руб.");
            Console.WriteLine($"№ {info.SerialNumber} {info.Model} добавлена в гараж. Остаток {_balance} руб.");
        }
        else
        {
            logger.Warn($"Недостаточно средств для {info.Model}. Нужно: {info.Price:N0} руб., есть: {_balance:N0} руб. (не хватает {info.Price - _balance:N0} руб.)");
            Console.WriteLine($"Недостаточно средств.Остаток {_balance:N0} руб.");
        }
    }

    public void AddRandomVehicle()
    {
        logger.Info("Дилер предлагает случайное транспортное средство");
        Info vehicle = Creating_vechicle.GenerateRandomVehicle();

        Console.WriteLine($"\n Предложение дилера:");
        Console.WriteLine($"   Модель: {vehicle.Model}");
        Console.WriteLine($"   Тип: {vehicle.Type.GetTypeName()}");
        Console.WriteLine($"   Год: {vehicle.Year}");
        Console.WriteLine($"   Цена: {vehicle.Price:N0} руб.");

        Console.Write("\nКупить? (y/n): ");
        string answer = Console.ReadLine()?.ToLower();

        if (answer == "y" || answer == "yes" || answer == "да")
        {
            logger.Info($"Пользователь согласился купить: {vehicle.Model} ({vehicle.Type.GetTypeName()}) за {vehicle.Price:N0} руб.");
            Add(vehicle);
        }
        else
        {
            logger.Info($"Пользователь отказался от предложения: {vehicle.Model} ({vehicle.Type.GetTypeName()}) за {vehicle.Price:N0} руб.");
            Console.WriteLine("Покупка отменена.");
        }
    }
    public void AddRandomCar()
    {
        logger.Info("Дилер предлагает случайную легковую машину");
        Car car = Creating_vechicle.GenerateRandomCar();
        Console.WriteLine($"\nСлучайная легковая: {car.Model} ({car.Year}) - {car.Price:N0} руб.");
        Console.Write("Купить? (y/n): ");
        if (Console.ReadLine()?.ToLower() == "y")
        {
            logger.Info($"Пользователь согласился купить легковую: {car.Model} за {car.Price:N0} руб.");
            Add(car);
        }
        else
        {
            logger.Info($"Пользователь отказался от легковой: {car.Model} за {car.Price:N0} руб.");
            Console.WriteLine("Отменено.");
        }
    }
    public void AddRandomTruck()
    {
        logger.Info("Дилер предлагает случайный грузовик");
        Truck truck = Creating_vechicle.GenerateRandomTruck();
        Console.WriteLine($"\nСлучайный грузовик: {truck.Model} ({truck.Year}) - {truck.Price:N0} руб.");
        Console.Write("Купить? (y/n): ");
        if (Console.ReadLine()?.ToLower() == "y")
        {
            logger.Info($"Пользователь согласился купить грузовик: {truck.Model} за {truck.Price:N0} руб.");
            Add(truck);
        }
        else
        {
            logger.Info($"Пользователь отказался от грузовика: {truck.Model} за {truck.Price:N0} руб.");
            Console.WriteLine("Отменено.");
        }
    }
    public void AddRandomBus()
    {
        logger.Info("Дилер предлагает случайный автобус");
        Bus bus = Creating_vechicle.GenerateRandomBus();
        Console.WriteLine($"\nСлучайный автобус: {bus.Model} ({bus.Year}) - {bus.Price:N0} руб.");
        Console.Write("Купить? (y/n): ");
        if (Console.ReadLine()?.ToLower() == "y")
        {
            logger.Info(
                $"Пользователь согласился купить автобус: {bus.Model} за {bus.Price:N0} руб.");
            Add(bus);
        }
        else
        {
            logger.Info($"Пользователь отказался от автобуса: {bus.Model} за {bus.Price:N0} руб.");
            Console.WriteLine("Отменено.");
        }
    }
}