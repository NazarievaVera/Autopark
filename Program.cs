using System.Text.Json;
using Car_Dealership;
using Car_Dealership.Extensions;
using Car_Dealership.Models;

Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.InputEncoding = System.Text.Encoding.UTF8;
        
var park = new AutoPark();
park.InitCar();
var isRunning = true;

while (isRunning)
{
    Console.WriteLine(" АВТОПАРК: ");
    Console.WriteLine("1. Посмотреть автопарк");
    Console.WriteLine("2. Продать машину (по ID)");
    Console.WriteLine("3. Купить новую машину ");
    Console.WriteLine("0. Выход");
    Console.Write("Выберите действие (0-3): ");

    string s = Console.ReadLine();

    switch (s)
    {
        case "1":
            park.Print();
            break;

        case "2":
            Console.Write("Введите ID машины для продажи: ");
            string idToDelete = Console.ReadLine();
            park.Delete(Guid.Parse(idToDelete));
            break;

        case "3":
            var car4 = new Car(Guid.NewGuid(), "New Lada", 2020, 3452000);
            Console.WriteLine($"Предложение дилера: {car4.Type.VehicleTypeToString()} {car4.Model} за {car4.Price}");
            Console.Write("Купить? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                park.Add(car4);
            }
            else
            {
                Console.WriteLine("Покупка отменена.");
            }

            break;

        case "0":
            var options = new JsonSerializerOptions 
            { 
                WriteIndented = true // Чтобы JSON в файле был красивым и читаемым, а не в одну строку
            };

            // 2. Сериализуем объект _fleets обратно в строку
            string updatedJson = JsonSerializer.Serialize(park.Storage, options);

            // 3. Записываем строку в тот же файл (он будет перезаписан)
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "base.json");
            File.WriteAllText(filePath, updatedJson);
                    
            isRunning = false;
            Console.WriteLine("До свидания!");
                    
            break;
        default:
            Console.WriteLine("Неверный ввод. Попробуйте снова.");
            break;
    }
}