using Car_Dealership.Models;

namespace Car_Dealership;

public partial class AutoPark
{
    // Просмотр
    public void Print()
    {
        Console.WriteLine("Ваш автопарк");
        int index = 1;
        if (_vehicles.Count == 0)
        {
            Console.WriteLine("Пусто.");
        }
        else
        {
            foreach (var c in _vehicles)
            {
                Console.WriteLine($"{index++}. {c.Type.GetTypeName()} | {c.Model} ({c.Year} г.) | Цена: {c.Price:N0} руб.");
            }
        }

        Console.WriteLine($"Баланс: {_balance:N0} руб.");
    }
}