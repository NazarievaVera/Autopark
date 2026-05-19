using Car_Dealership.Models;
namespace Car_Dealership;

public partial class AutoPark
{
    // Просмотр
    public void Print()
    {
        Console.WriteLine("Ваш автопарк");
        if (_vehicles.Count == 0)
        {
            Console.WriteLine("Пусто.");
        }
        else
        {
            foreach (var c in _vehicles)
            {
                c.DisplayInfo();
            }
        }

        Console.WriteLine($"Баланс: {_balance} руб.");
    }
}