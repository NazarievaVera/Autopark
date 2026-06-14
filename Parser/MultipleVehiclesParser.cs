using Car_Dealership.Models;
namespace Car_Dealership.Parser;

public class MultipleVehiclesParser
{
    public static void ParseAndAddMultiple(AutoPark park)
    {
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
            Console.WriteLine(" Ничего не введено!");
            return;
        }

        var vehicles = new List<Info>();
        foreach (var input in inputs)
        {
            var vehicle = input.ParseVehicle();
            if (vehicle != null)
            {
                vehicles.Add(vehicle);
            }
        }
        DisplayParsedVehicles(vehicles, inputs.Count);

        if (vehicles.Count > 0)
        {
            Console.Write("\nДобавить все в автопарк? (y/n): ");
            if (Console.ReadLine()?.ToLower() == "y")
            {
                foreach (var vehicle in vehicles)
                {
                    park.Add(vehicle);
                }

                Console.WriteLine($"Добавлено {vehicles.Count} машин!");
            }
            else
            {
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
