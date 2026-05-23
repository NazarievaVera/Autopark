using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Car_Dealership.Models;

namespace Car_Dealership
{
    public class Save_file
    {
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

                // 3. Пишем в файл
                File.WriteAllText(path, jsonString);
                Console.WriteLine($"\n Файл сохранён: {Path.GetFullPath(path)}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n Ошибка сохранения: {ex.Message}");
            }
        }

        // Метод загрузки
        public static bool Load(AutoPark park, string path)
        {
            if (!File.Exists(path)) return false;

            try
            {
                string jsonString = File.ReadAllText(path);

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

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n Ошибка загрузки: {ex.Message}");
                return false;
            }
        }
    }
}