using System.Text.RegularExpressions;
using NLog;

namespace Car_Dealership.Parser;

public static class PriceYearParser
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    
    //  Парсинг цены из строки 
    public static decimal? ParsePrice(this string input)
    {
        logger.Debug($"Парсинг цены из: '{input}'");

        // Удаляем пробелы и "руб."
        var pattern = @"([\d\s]+)\s*руб\.?";
        var match = Regex.Match(input, pattern);

        if (match.Success)
        {
            string priceStr = match.Groups[1].Value.Replace(" ", "");
            if (decimal.TryParse(priceStr, out decimal price))
            {
                logger.Debug($"Цена распарсена: {price:N0} руб.");
                return price;
            }
        }

        logger.Warn($"Не удалось распарсить цену из строки: '{input}'");
        return null;
    }

    // парсинг года из строки
    public static int? ParseYear(this string input)
    {
        logger.Debug($"Парсинг года из: '{input}'");
        
        // Ищем год в формате (2020) или 2020 г.
        var pattern = @"\b(19|20)\d{2}\b";
        var match = Regex.Match(input, pattern);

        if (match.Success && int.TryParse(match.Value, out int year))
        {
            logger.Debug($"Год распарсен: {year}");
            return year;
        }
        logger.Warn($"Не удалось распарсить год из строки: '{input}'");
        return null;
    }
}