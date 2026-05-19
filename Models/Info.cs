namespace Car_Dealership.Models;
using System.Threading;
public abstract class Info
{
    public string InternalId { get; }
    public int SerialNumber { get; set; }
    public string Model { get; }
    public VehicleType Type { get; }
    public decimal Price { get; }
    public int Year { get; }
        
    private static int _nextSerialNumber = 0; //счетчик
 
    public Info(string model, int year,decimal price, VehicleType type)
    {
        InternalId = Guid.NewGuid().ToString();
        SerialNumber = Interlocked.Increment(ref _nextSerialNumber);
        Model = model;
        Price = price;
        Year = year;
        Type = type;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"№: {SerialNumber} {Type.GetTypeName()} | {Model} ({Year} г.) | Цена: {Price}");
            
    }
    public bool MatchesInternalId(string id) => InternalId == id; // Для поиска по id
    
}