using System.Text.Json.Serialization;

namespace Car_Dealership.Models;

public class Bus : Info
{
    public override VehicleType Type => VehicleType.Bus;

    internal static readonly string[] Models =
    {
        "LiAZ 5256", "PAZ 3205", "MAZ 206", "Mercedes Sprinter",
        "Ford Transit", "Gazelle Next", "Volvo 9700"
    };

    internal static readonly (int min, int max) PriceRange = (2_000_000, 5_000_000);

    public Bus(string model, int year, decimal price) : base(model, year, price)
    {
    }

    [JsonConstructor]
    public Bus(string internalId, int serialNumber, string model, decimal price, int year)
        : base(internalId, serialNumber, model, price, year){}

    internal static Bus Create(string model, int year, decimal price, int passengerCapacity)
    {
        return new Bus(model, year, price);
    }
}