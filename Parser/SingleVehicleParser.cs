using Car_Dealership.Models;
namespace Car_Dealership.Parser;
using NLog;

public static class SingleVehicleParser
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    public static void ParseAndAdd(AutoPark park)
    {
        logger.Info("Запущен парсинг одной машины");
        
        Console.WriteLine("\nВведите данные о машине:");
        Console.WriteLine("Формат: Тип: Модель (Год) - Цена руб.");
        Console.Write("> ");
        
        string input = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(input))
        {
            logger.Warn("Парсинг отменён: пользователь ввёл пустую строку");
            Console.WriteLine("Пустой ввод!");
            return;
        }

        var vehicle = input.ParseVehicleWithRegex();
        
        if (vehicle != null)
        {
            DisplayVehicleInfo(vehicle);
            
            Console.Write("\nДобавить в автопарк? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                logger.Info($"Пользователь согласился добавить: {vehicle.Model} ({vehicle.Type.GetTypeName()})");
                park.Add(vehicle);
            }
            else
            {
                logger.Info($"Пользователь отменил добавление: {vehicle.Model} ({vehicle.Type.GetTypeName()})");
                Console.WriteLine("Добавление отменено.");
            }
        }
        else
        {
            logger.Warn($"Не удалось распарсить строку: '{input}'");
            Console.WriteLine("Не удалось распознать данные.");
        }
    }

    private static void DisplayVehicleInfo(Info vehicle)
    {
        Console.WriteLine($"\n Распознано:");
        Console.WriteLine($"   Тип: {vehicle.Type.GetTypeName()}");
        Console.WriteLine($"   Модель: {vehicle.Model}");
        Console.WriteLine($"   Год: {vehicle.Year}");
        Console.WriteLine($"   Цена: {vehicle.Price:N0} руб.");
    }
}

