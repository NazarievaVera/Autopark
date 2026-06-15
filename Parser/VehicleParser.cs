using System.Text.RegularExpressions;
using Car_Dealership.Models;
using NLog;

namespace Car_Dealership.Parser;

public static class VehicleParser
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    // парсинг информации о машине из строки 
    public static Info? ParseVehicle(this string input)
    {
        logger.Debug($"Парсинг (split): '{input}'");

        // Пример формата: "Car:Lada Vesta:2020:1500000"
        var parts = input.Split(':');
        if (parts.Length < 4)
        {
            logger.Warn(
                $"Неверный формат данных (split). Ожидается минимум 4 части, получено: {parts.Length}. Строка: '{input}'");
            Console.WriteLine("Неверный формат данных");
            return null;
        }

        try
        {
            string type = parts[0].Trim().ToLower();
            string model = parts[1].Trim();
            int year = int.Parse(parts[2].Trim());
            decimal price = decimal.Parse(parts[3].Trim());

            Info? vehicle = type switch
            {
                "car" => new Car(model, year, price),
                "truck" when parts.Length >= 5 =>
                    new Truck(model, year, price),
                "bus" when parts.Length >= 5 =>
                    new Bus(model, year, price),
                _ => null
            };
            if (vehicle != null)
            {
                logger.Info($"Распарсено (split): {vehicle.Type.GetTypeName()} | {model} ({year}) | {price:N0} руб.");
            }
            else
            {
                logger.Warn($"Неизвестный тип ТС: '{type}' в строке: '{input}'");
            }

            return vehicle;
        }
        catch (Exception ex)
        {
            logger.Error(ex, $"Ошибка парсинга (split) строки: '{input}'");
            Console.WriteLine($" Ошибка парсинга: {ex.Message}");
            return null;
        }
    }
    // парсинг с помощью регулярных выражений 
    public static Info? ParseVehicleWithRegex(this string input)
    {
        logger.Debug($"Парсинг (regex): '{input}'");

        // Формат: "Car: Lada Vesta (2020) - 1500000 руб."
        var carPattern = @"^(Car|Truck|Bus):\s*(.+?)\s*\((\d{4})\)\s*-\s*(\d+)\s*руб\.?";

        var match = Regex.Match(input, carPattern, RegexOptions.IgnoreCase);

        if (!match.Success)
        {
            logger.Warn($"Не удалось распознать формат (regex). Строка: '{input}'");
            Console.WriteLine("Не удалось распознать формат");
            return null;
        }

        try
        {
            string type = match.Groups[1].Value.ToLower();
            string model = match.Groups[2].Value.Trim();
            int year = int.Parse(match.Groups[3].Value);
            decimal price = decimal.Parse(match.Groups[4].Value);

            Info? vehicle = type switch
            {
                "car" => new Car(model, year, price),
                "truck" => new Truck(model, year, price),
                "bus" => new Bus(model, year, price),
                _ => null
            };
            if (vehicle != null)
            {
                logger.Info($"Распарсено (regex): {vehicle.Type.GetTypeName()} | {model} ({year}) | {price:N0} руб.");
            }

            return vehicle;
        }
        catch (Exception ex)
        {
            logger.Error(ex, $"Ошибка парсинга (regex) строки: '{input}'");
            Console.WriteLine($"Ошибка парсинга: {ex.Message}");
            return null;
        }
    }
}