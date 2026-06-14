using Car_Dealership.Models;

namespace Car_Dealership;

public partial class AutoPark
{
    public void Delete(int serialNumber)
    {
        var info = _vehicles.FirstOrDefault(c => c.SerialNumber == serialNumber);

        if (info != null)
        {
            _balance += info.Price;
            _vehicles.Remove(info); // уделение 

            for (int i = 0; i < _vehicles.Count; i++)
            {
                _vehicles[i].SerialNumber = i + 1;
            }

            Console.WriteLine($"Успешно продано: {info.Model}. Баланс: {_balance:N0} руб.");
        }
        else
        {
            Console.WriteLine($"Машина под номером {serialNumber} не найдена");
        }
    }
}