using Car_Dealership;
using Car_Dealership.Models;

class Program
{
    static void Main(string[] args)
    {
        AutoPark park = new AutoPark(10000000);
        park.InitCar();

        var lada = new Car("New Lada", 2020, 3_450_000);
        bool isRunning = true;

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
                    Console.Write("Введите № машины для продажи: ");
                    // проверка на ввод
                    string input = Console.ReadLine();
                    if (int.TryParse(input, out int numToDelete)) // преобразуем строку в число
                    {
                        park.Delete(numToDelete);
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: нужно ввести число!");
                    }

                    break;

                case "3":
                    Console.WriteLine($"Предложение дилера: Легкова New Lada за 3 450 000");
                    Console.Write("Купить? (y/n): ");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        park.Add(lada);
                    }
                    else
                    {
                        Console.WriteLine("Покупка отменена.");
                    }

                    break;

                case "0":
                    // Вызываем сохранение через отдельный класс
                    Save_file.Save(park, "save.json");

                    isRunning = false;
                    Console.WriteLine("До свидания!");
                    break;
                default:
                    Console.WriteLine("Неверный ввод. Попробуйте снова.");
                    break;
            }
        }
    }
}