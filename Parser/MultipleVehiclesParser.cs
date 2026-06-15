using Car_Dealership.Models;
namespace Car_Dealership.Parser;
using NLog;

public class MultipleVehiclesParser
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    public static void ParseAndAddMultiple(AutoPark park)
    {
        logger.Info("Запущен массовый парсинг машин");
        Console.WriteLine("\nВведите данные о машинах (каждая с новой строки):");
        Console.WriteLine("Для завершения введите пустую строку или 'end'");
        Console.WriteLine();

        var inputs = new List<string>();

        while (true)
        {
            Console.Write("> ");
            string line = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(line) || line.ToLower() == "end")
                break;

            inputs.Add(line);
        }

        if (inputs.Count == 0)
        {
            logger.Warn("Массовый парсинг отменён: пользователь ничего не ввёл");
            Console.WriteLine(" Ничего не введено!");
            return;
        }

        logger.Info($"Введено строк для парсинга: {inputs.Count}");
        
        var vehicles = new List<Info>();
        foreach (var input in inputs)
        {
            var vehicle = input.ParseVehicle();
            if (vehicle != null)
            {
                vehicles.Add(vehicle);
            }
        }
        
        if (vehicles.Count == inputs.Count)
        {
            logger.Info($"Все строки успешно распарсены: {vehicles.Count} машин");
        }
        else if (vehicles.Count > 0)
        {
            logger.Warn($"Распарсено частично: {vehicles.Count} из {inputs.Count} (ошибок: {inputs.Count - vehicles.Count})");
        }
        else
        {
            logger.Error($"Не удалось распарсить ни одну строку из {inputs.Count}");
        }
        
        DisplayParsedVehicles(vehicles, inputs.Count);

        if (vehicles.Count > 0)
        {
            Console.Write("\nДобавить все в автопарк? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                logger.Info($"Пользователь согласился добавить {vehicles.Count} машин в автопарк");
                foreach (var vehicle in vehicles)
                {
                    park.Add(vehicle);
                }
                logger.Info($" Успешно добавлено {vehicles.Count} машин в автопарк");
                Console.WriteLine($"Добавлено {vehicles.Count} машин!");
            }
            else
            {
                logger.Info($"Пользователь отменил добавление {vehicles.Count} машин");
                Console.WriteLine("Добавление отменено.");
            }
        }
    }

    private static void DisplayParsedVehicles(List<Info> vehicles, int totalCount)
    {
        Console.WriteLine($"\n Успешно распарсено: {vehicles.Count} из {totalCount}");

        if (vehicles.Count > 0)
        {
            Console.WriteLine("\nРаспознанные машины:");
            int index = 1;
            foreach (var v in vehicles)
            {
                Console.WriteLine($"{index++}. {v.Type.GetTypeName()} | {v.Model} ({v.Year}) - {v.Price:N0} руб.");
            }
        }
    }
}
