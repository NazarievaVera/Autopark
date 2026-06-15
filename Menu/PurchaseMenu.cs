namespace Car_Dealership.Menu;

public class PurchaseMenu
{
    public static void Show(AutoPark park)
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
                    inPurchaseMenu = false; //выход из подменю
                    break;

                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }
}