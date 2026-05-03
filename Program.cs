using Car_Dealership;

class Program
{
    static void Main(string[] args)
    {
        AutoPark park = new AutoPark(10000000);
        park.InitCar();
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
                    Console.Write("Введите ID машины для продажи: ");
                    string idToDelete = Console.ReadLine();
                    park.Delete(idToDelete);
                    break;

                case "3":
                    Console.WriteLine($"Предложение дилера: Легкова New Lada за 3 450 000");
                    Console.Write("Купить? (y/n): ");
                    if (Console.ReadLine().ToLower() == "y")
                    {
                        var car4 = new Car("C004", "New Lada", 2020, 3450000);
                        park.Add(car4);
                    }
                    else
                    {
                        Console.WriteLine("Покупка отменена.");
                    }

                    break;

                case "0":
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