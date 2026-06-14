using Car_Dealership.Models;
namespace Car_Dealership.Parser;

public static class SingleVehicleParser
{
    public static void ParseAndAdd(AutoPark park)
    {
        Console.WriteLine("\nВведите данные о машине:");
        Console.WriteLine("Формат: Тип: Модель (Год) - Цена руб.");
        Console.Write("> ");
        
        string input = Console.ReadLine();
        
        if (string.IsNullOrWhiteSpace(input))
        {
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
                park.Add(vehicle);
            }
            else
            {
                Console.WriteLine("Добавление отменено.");
            }
        }
        else
        {
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

