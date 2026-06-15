using Car_Dealership.Models;

namespace Car_Dealership.Menu;

public class MainMenu
{
    public static void Show(AutoPark park)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.WriteLine("\n АВТОПАРК ");
            Console.WriteLine("1. Посмотреть автопарк");
            Console.WriteLine("2. Продать машину (по №)");
            Console.WriteLine("3. Купить новую машину");
            Console.WriteLine("4. Добавить машину через парсинг");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие (0-4): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    park.Print();
                    break;

                case "2":
                    HandleDeleteVehicle(park);
                    break;

                case "3":
                    PurchaseMenu.Show(park);
                    break;

                case "4":
                    ParseMenu.Show(park);
                    break;

                case "0":
                    Save_file.Save(park, "save.json");
                    isRunning = false;
                    Console.WriteLine("До свидания!");
                    break;

                default:
                    Console.WriteLine("Неверный ввод.");
                    break;
            }
        }
    }

    private static void HandleDeleteVehicle(AutoPark park)
    {
        Console.Write("Введите № машины для продажи: ");
        string input = Console.ReadLine();

        if (int.TryParse(input, out int numToDelete))
        {
            park.Delete(numToDelete);
        }
        else
        {
            Console.WriteLine("Ошибка: нужно ввести число!");
        }
    }
}

