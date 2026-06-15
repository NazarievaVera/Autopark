using Car_Dealership.Models;

namespace Car_Dealership;

public partial class AutoPark
{
    // Просмотр
    public void Print()
    {
        logger.Info($"Просмотр автопарка: {_vehicles.Count} машин, баланс: {_balance:N0} руб.");
        Console.WriteLine("Ваш автопарк");
        
        if (_vehicles.Count == 0)
        {
            logger.Warn("Пользователь просмотрел пустой автопарк");
            Console.WriteLine("Пусто.");
        }
        else
        {
            int index = 1;
            foreach (var c in _vehicles)
            {
                Console.WriteLine($"{c.SerialNumber}: {c.Type.GetTypeName()} | {c.Model} ({c.Year} г.) | Цена: {c.Price:N0} руб.");
            }
        }

        Console.WriteLine($"Баланс: {_balance:N0} руб.");
    }
}