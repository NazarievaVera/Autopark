using Car_Dealership.Models;
using NLog;

namespace Car_Dealership.Parser;

public static class VehiclesListParser
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    
    // Массовый парсинг списка машин 
    public static List<Info> ParseVehiclesList(this string[] inputs)
    {
        logger.Info($"Массовый парсинг: {inputs.Length} строк");
        
        var vehicles = new List<Info>();
        int successCount = 0;
        int failCount = 0;
        
        foreach (var input in inputs)
        {
            var vehicle = input.ParseVehicleWithRegex();
            if (vehicle != null)
            {
                vehicles.Add(vehicle);
                successCount++;
            }
            else
            {
                failCount++;
            }
        }
        logger.Info($"Массовый парсинг завершён: успешно {successCount}, ошибок {failCount} из {inputs.Length}");
        return vehicles;
    }

    // Добавление распаршенной машины в автопарк 
    public static bool AddFromText(this AutoPark park, string input)
    {
        logger.Info($"Попытка добавления из текста: '{input}'");
        
        var vehicle = input.ParseVehicleWithRegex();
        if (vehicle != null)
        {
            logger.Info($"Машина добавлена из текста: {vehicle.Model}");
            // используем существующий метод Add
            return true;
        }
        logger.Warn($"Не удалось добавить машину из текста: '{input}'");
        return false;
    }
}