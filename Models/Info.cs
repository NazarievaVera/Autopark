namespace Car_Dealership.Models;

using System.Threading;
using System.Text.Json.Serialization;

[JsonDerivedType(typeof(Car), typeDiscriminator: "Car")]
[JsonDerivedType(typeof(Bus), typeDiscriminator: "Bus")]
[JsonDerivedType(typeof(Truck), typeDiscriminator: "Truck")]
[JsonPolymorphic(TypeDiscriminatorPropertyName = "$type")]
public abstract class Info
{
    [JsonInclude] public string InternalId { get; }
    [JsonInclude] public int SerialNumber { get; set; }
    [JsonInclude] public string Model { get; }
    public abstract VehicleType Type { get; }
    [JsonInclude] public decimal Price { get; }
    [JsonInclude] public int Year { get; }

    private static int _nextSerialNumber = 0; //счетчик

    //конструктор для создания 
    public Info(string model, int year, decimal price)
    {
        InternalId = Guid.NewGuid().ToString();
        SerialNumber = Interlocked.Increment(ref _nextSerialNumber);
        Model = model;
        Price = price;
        Year = year;
    }

    [JsonConstructor]
    protected Info(string internalId, int serialNumber, string model, decimal price, int year)
    {
        InternalId = internalId;
        SerialNumber = serialNumber;
        Model = model;
        Price = price;
        Year = year;

        _nextSerialNumber = Math.Max(_nextSerialNumber, serialNumber);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"№: {SerialNumber} {Type.GetTypeName()} | {Model} ({Year} г.) | Цена: {Price}");
    }

    public bool MatchesInternalId(string id) => InternalId == id; // Для поиска по id
}