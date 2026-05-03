using System.Text.Json;
using Car_Dealership.Models;
using Car_Dealership.Models.Data;

namespace Car_Dealership;

/// <summary>
/// Деньги и тачки
/// </summary>
public class AutoPark
{   
    private Storage? _fleets;
    private double _balance => _fleets.Balance;

    public AutoPark()
    {
        _fleets = new Storage();
    }
    public Storage Storage => _fleets; // чтобы посмотреть

    public void InitCar()
    {
        string jsonString = File.ReadAllText(Directory.GetCurrentDirectory()+"\\base.json");
        _fleets = JsonSerializer.Deserialize<Storage>(jsonString);
    }

    // Покупка
    public void Add(Car vihicleBase)
    {
        if (_balance >= vihicleBase.Price)
        {
            _fleets.Balance -= vihicleBase.Price;
            _fleets.Data.Add(vihicleBase);
            Console.WriteLine($"Машина {vihicleBase.Model} добавлена в гараж. Остаток {_balance} руб.");
        }
        else
        {
            Console.WriteLine($"Недостаточно средств.Остаток {_balance} руб.");
        }
    }

    public void Delete(Guid id)
    {
        var info = _fleets.Data.FirstOrDefault(с => с.Id == id);
        if (info != null)
        { 
            _fleets.Balance += info.Price;
            _fleets.Data.Remove(info);
            Console.WriteLine($"Успешно продано: {info.Model}. Баланс: {_balance} руб.");
        }
        else
        {
            Console.WriteLine("Машина не найдена");
        }
    }
        
    // Просмотр
    public void Print()
    {
        foreach (var fleet in _fleets.Data)
        {
            foreach (var fleet1 in _fleets.Data)
            {
                if (fleet.Type > fleet1.Type)
                {

                }
            }
        }
        
        
        
        Console.WriteLine("Ваш автопарк");
        if (_fleets.Data.Count == 0)
        {
            Console.WriteLine("Пусто.");
        }
        else
        {
            foreach (var c in _fleets.Data)
            {
                c.DisplayInfo();
            }
        }

        Console.WriteLine($"Баланс: {_balance} руб.");
    }
}