using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Car_Dealership.Models;
using NLog;

namespace Car_Dealership
{
    public class Save_file
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        // чтобы сохранять машины и деньги вместе
        private class SaveData
        {
            public List<Info> Vehicles { get; set; }
            public decimal Balance { get; set; }
        }

        // Метод сохранения
        public static void Save(AutoPark park, string path)
        {
            try
            {
                logger.Info($"Начало сохранения автопарка в файл: {path}");
                // 1. Собираем данные в упаковку
                var data = new SaveData
                {
                    Vehicles = park.Vehicles,
                    Balance = park.Balance
                };

                // 2. Превращаем в JSON
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };
                string jsonString = JsonSerializer.Serialize(data, options);
                logger.Debug(
                    $"Размер JSON: {jsonString.Length} символов, машин: {data.Vehicles.Count}, баланс: {data.Balance:N0} руб.");

                // 3. Пишем в файл
                File.WriteAllText(path, jsonString);

                string fullPath = Path.GetFullPath(path);
                logger.Info($"Файл успешно сохранён: {fullPath} ({new FileInfo(fullPath).Length} байт)");
                Console.WriteLine($"\n Файл сохранён: {Path.GetFullPath(path)}");
            }
            catch (Exception ex)
            {
                logger.Error(ex, $" Ошибка сохранения в файл: {path}");
                Console.WriteLine($"\n Ошибка сохранения: {ex.Message}");
            }
        }

        // Метод загрузки
        public static bool Load(AutoPark park, string path)
        {
            if (!File.Exists(path))
            {
                logger.Warn($"Файл сохранения не найден: {Path.GetFullPath(path)}");
                return false;
            }

            try
            {
                logger.Info($"Начало загрузки из файла: {path}");
                // открывает по пути, читает полностью и записывает в переменную
                string jsonString = File.ReadAllText(path);

                logger.Debug($"Размер файла: {jsonString.Length} символов");
                
                var options = new JsonSerializerOptions
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                var data = JsonSerializer.Deserialize<SaveData>(jsonString);

                if (data != null)
                {
                    // Передаем данные обратно в AutoPark
                    park.LoadData(data.Vehicles, data.Balance);
                    return true;
                }
                logger.Warn($"Файл {path} пустой или содержит некорректные данные");
                return false;
            }
            catch (Exception ex)
            {
                logger.Error(ex, $"Ошибка загрузки из файла: {path}");
                Console.WriteLine($"\n Ошибка загрузки: {ex.Message}");
                return false;
            }
        }
    }
}