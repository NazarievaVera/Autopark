using System.Text.RegularExpressions;
using Car_Dealership.Models;

namespace Car_Dealership;

public static partial class Extensions
{
    // парсинг информации о машине из строки 
    public static Info? ParseVehicle(this string input)
    {
        // Пример формата: "Car:Lada Vesta:2020:1500000"
        
        var parts = input.Split(':');
        if (parts.Length < 4)
        {
            Console.WriteLine("Неверный формат данных");
            return null;
        }

        try
        {
            string type = parts[0].Trim().ToLower();
            string model = parts[1].Trim();
            int year = int.Parse(parts[2].Trim());
            decimal price = decimal.Parse(parts[3].Trim());

            return type switch
            {
                "car" => new Car(model, year, price),
                "truck" when parts.Length >= 5 => 
                    new Truck(model, year, price),
                "bus" when parts.Length >= 5 => 
                    new Bus(model, year, price),
                _ => null
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($" Ошибка парсинга: {ex.Message}");
            return null;
        }
    }

    // парсинг с помощью регулярных выражений 
    public static Info? ParseVehicleWithRegex(this string input)
    {
        // Формат: "Car: Lada Vesta (2020) - 1500000 руб."
        var carPattern = @"^(Car|Truck|Bus):\s*(.+?)\s*\((\d{4})\)\s*-\s*(\d+)\s*руб\.?";
        
        var match = Regex.Match(input, carPattern, RegexOptions.IgnoreCase);
        
        if (!match.Success)
        {
            Console.WriteLine("Не удалось распознать формат");
            return null;
        }

        try
        {
            string type = match.Groups[1].Value.ToLower();
            string model = match.Groups[2].Value.Trim();
            int year = int.Parse(match.Groups[3].Value);
            decimal price = decimal.Parse(match.Groups[4].Value);

            return type switch
            {
                "car" => new Car(model, year, price),
                "truck" => new Truck(model, year, price), 
                "bus" => new Bus(model, year, price),     
                _ => null
            };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка парсинга: {ex.Message}");
            return null;
        }
    }

    //  Парсинг цены из строки 
    public static decimal? ParsePrice(this string input)
    {
        // Удаляем пробелы и "руб."
        var pattern = @"([\d\s]+)\s*руб\.?";
        var match = Regex.Match(input, pattern);
        
        if (match.Success)
        {
            string priceStr = match.Groups[1].Value.Replace(" ", "");
            if (decimal.TryParse(priceStr, out decimal price))
            {
                return price;
            }
        }
        
        return null;
    }

    // парсинг года из строки
    public static int? ParseYear(this string input)
    {
        // Ищем год в формате (2020) или 2020 г.
        var pattern = @"\b(19|20)\d{2}\b";
        var match = Regex.Match(input, pattern);
        
        if (match.Success && int.TryParse(match.Value, out int year))
        {
            return year;
        }
        
        return null;
    }

    // Массовый парсинг списка машин 
    public static List<Info> ParseVehiclesList(this string[] inputs)
    {
        var vehicles = new List<Info>();
        
        foreach (var input in inputs)
        {
            var vehicle = input.ParseVehicleWithRegex();
            if (vehicle != null)
            {
                vehicles.Add(vehicle);
            }
        }
        
        return vehicles;
    }

    // Добавление распаршенной машины в автопарк 
    public static bool AddFromText(this AutoPark park, string input)
    {
        var vehicle = input.ParseVehicleWithRegex();
        if (vehicle != null)
        {
            // используем существующий метод Add
            return true; 
        }
        return false;
    }
}