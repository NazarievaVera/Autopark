using Car_Dealership.Models;

namespace Car_Dealership;

public partial class AutoPark
{
    // Покупка
    public void Add(Info info)
    {
        // если хотябы 1 совпадает
        if (_vehicles.Any(v => v.InternalId == info.InternalId))
        {
            Console.WriteLine($"Машина с системным ID {info.InternalId} уже в автопарке. ");
            return;
        }

        if (_balance >= info.Price)
        {
            _balance -= info.Price;
            _vehicles.Add(info);
            Console.WriteLine($"№ {info.SerialNumber} {info.Model} добавлена в гараж. Остаток {_balance} руб.");
        }
        else
        {
            Console.WriteLine($"Недостаточно средств.Остаток {_balance:N0} руб.");
        }
    }

    public void AddRandomVehicle()
    {
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
            Add(vehicle);
        }
        else
        {
            Console.WriteLine("Покупка отменена.");
        }
    }
    public void AddRandomCar()
    {
        Car car = Creating_vechicle.GenerateRandomCar();
        Console.WriteLine($"\nСлучайная легковая: {car.Model} ({car.Year}) - {car.Price:N0} руб.");
        Console.Write("Купить? (y/n): ");
        if (Console.ReadLine()?.ToLower() == "y")
            Add(car);
        else
            Console.WriteLine("Отменено.");
    }
    public void AddRandomTruck()
    {
        Truck truck = Creating_vechicle.GenerateRandomTruck();
        Console.WriteLine($"\nСлучайный грузовик: {truck.Model} ({truck.Year}) - {truck.Price:N0} руб.");
        Console.Write("Купить? (y/n): ");
        if (Console.ReadLine()?.ToLower() == "y")
            Add(truck);
        else
            Console.WriteLine("Отменено.");
    }
    public void AddRandomBus()
    {
        Bus bus = Creating_vechicle.GenerateRandomBus();
        Console.WriteLine($"\nСлучайный автобус: {bus.Model} ({bus.Year}) - {bus.Price:N0} руб.");
        Console.Write("Купить? (y/n): ");
        if (Console.ReadLine()?.ToLower() == "y")
            Add(bus);
        else
            Console.WriteLine("Отменено.");
    }
}