namespace Car_Dealership.Parser;

public static class ParseExamples
{
    public static void Show()
    {
        Console.WriteLine("\n ПРИМЕРЫ ФОРМАТОВ ");
        Console.WriteLine();
        Console.WriteLine("Легковая машина:");
        Console.WriteLine("  Car: Toyota Camry (2020) - 2500000 руб.");
        Console.WriteLine("  Car: Lada Vesta (2021) - 1500000 руб.");
        Console.WriteLine();
        Console.WriteLine("Грузовик:");
        Console.WriteLine("  Truck: Kamaz 5490 (2019) - 8000000 руб.");
        Console.WriteLine("  Truck: Volvo FH16 (2020) - 12000000 руб.");
        Console.WriteLine();
        Console.WriteLine("Автобус:");
        Console.WriteLine("  Bus: LiAZ 5256 (2018) - 6000000 руб.");
        Console.WriteLine("  Bus: Mercedes Sprinter (2021) - 4500000 руб.");
        Console.WriteLine();
        Console.WriteLine("Нажмите любую клавишу для продолжения...");
        Console.ReadKey();
    }
}