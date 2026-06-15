using Car_Dealership.Parser;
namespace Car_Dealership.Menu;

public class ParseMenu
{
    public static void Show(AutoPark park)
    {
        bool inParseMenu = true;
        while (inParseMenu)
        {
            Console.WriteLine("\n ДОБАВЛЕНИЕ ЧЕРЕЗ ПАРСИНГ ");
            Console.WriteLine("1. Добавить одну машину из строки");
            Console.WriteLine("2. Добавить несколько машин (массовый парсинг)");
            Console.WriteLine("3. Показать примеры форматов");
            Console.WriteLine("4. Назад в главное меню");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    SingleVehicleParser.ParseAndAdd(park);
                    break;

                case "2":
                    MultipleVehiclesParser.ParseAndAddMultiple(park);
                    break;

                case "3":
                    ParseExamples.Show();
                    break;

                case "4":
                    inParseMenu = false;
                    break;

                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }

}