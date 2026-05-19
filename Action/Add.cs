using Car_Dealership.Models;
namespace Car_Dealership;
public partial class AutoPark
{
    // Покупка
    public void Add(Info info)
    {
        // если хотябы 1 совпадает
        if (_vehicles.Any(v => v.InternalId == info.InternalId))
        {
            Console.WriteLine($"Машина с системным ID {info.InternalId} уже в автопарке. ");
            return;
        }

        if (_balance >= info.Price)
        {
            _balance -= info.Price;
            _vehicles.Add(info);
            Console.WriteLine($"№ {info.SerialNumber} {info.Model} добавлена в гараж. Остаток {_balance} руб.");
        }
        else
        {
            Console.WriteLine($"Недостаточно средств.Остаток {_balance} руб.");
        }
    }
}