using Car_Dealership;
using Car_Dealership.Models;
using NLog;

class Program
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();

    static void Main(string[] args)
    {
        logger.Info("NLog работает!");
        logger.Debug("Отладочное сообщение");

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
                    ShowPurchaseMenu(park);
                    break;

                case "0":
                    // вызываем сохранение через отдельный класс
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
    static void ShowPurchaseMenu(AutoPark park)
    {
        bool inPurchaseMenu = true;
        while (inPurchaseMenu)
        {
            Console.WriteLine("\n ПОКУПКА МАШИНЫ ");
            Console.WriteLine("1. Случайное транспортное средство");
            Console.WriteLine("2. Случайная легковая машина");
            Console.WriteLine("3. Случайный грузовик");
            Console.WriteLine("4. Случайный автобус");
            Console.WriteLine("5. Назад в главное меню");
            Console.Write("Выберите тип: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    park.AddRandomVehicle();
                    break;

                case "2":
                    park.AddRandomCar();
                    break;

                case "3":
                    park.AddRandomTruck();
                    break;

                case "4":
                    park.AddRandomBus();
                    break;

                case "5":
                    inPurchaseMenu = false;  //выход из подменю
                    break;

                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }
}