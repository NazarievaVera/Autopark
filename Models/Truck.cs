using System.Text.Json.Serialization;

namespace Car_Dealership.Models;

public class Truck : Info
{
    public override VehicleType Type => VehicleType.Truck;

    internal static readonly string[] Models =
    {
        "Kamaz 5490", "Volvo FH16", "Scania R-Series", "Mercedes Actros",
        "MAN TGX", "DAF XF", "Iveco Stralis", "Kamaz 65115"
    };

    internal static readonly (int min, int max) PriceRange = (3_000_000, 8_000_000);

    public Truck(string model, int year, decimal price) : base(model, year, price)
    {
    }

    [JsonConstructor]
    public Truck(string internalId, int serialNumber, string model, decimal price, int year)
        : base(internalId, serialNumber, model, price, year){}

    internal static Truck Create(string model, int year, decimal price, int capacity)
    {
        return new Truck(model, year, price);
    }
}