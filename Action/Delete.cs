using Car_Dealership.Models;

namespace Car_Dealership;

public partial class AutoPark
{
    public void Delete(int serialNumber)
    {
        logger.Info($"Попытка продажи машины №{serialNumber}");
        var info = _vehicles.FirstOrDefault(c => c.SerialNumber == serialNumber);

        if (info != null)
        {
            _balance += info.Price;
            _vehicles.Remove(info); // уделение 
            
            logger.Debug($"Перенумерация {_vehicles.Count} машин после удаления");
            for (int i = 0; i < _vehicles.Count; i++)
            {
                _vehicles[i].SerialNumber = i + 1;
            }
            logger.Info($"Продано: {info.Model} ({info.Type.GetTypeName()}) за {info.Price:N0} руб. Баланс: {_balance:N0} руб.");
            Console.WriteLine($"Успешно продано: {info.Model}. Баланс: {_balance:N0} руб.");
        }
        else
        {
            logger.Warn($"Машина №{serialNumber} не найдена в автопарке. Всего машин: {_vehicles.Count}");
            Console.WriteLine($"Машина под номером {serialNumber} не найдена");
        }
    }
}