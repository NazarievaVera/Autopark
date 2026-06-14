using System.Text.Json.Serialization;

namespace Car_Dealership.Models;

public class Car : Info
{
    public override VehicleType Type => VehicleType.Car;

    internal static readonly string[] Models =
    {
        "Lada Vesta", "Lada Granta", "Kia Rio", "Hyundai Solaris",
        "Volkswagen Polo", "Skoda Rapid", "Renault Logan", "Toyota Camry",
        "BMW 3 Series", "Mercedes C-Class", "Audi A4", "Mazda 6"
    };

    internal static readonly (int min, int max) PriceRange = (500_000, 5_000_000);
    public Car(string model, int year, decimal price) : base(model, year, price) {}
    [JsonConstructor]
    public Car(string internalId, int serialNumber, string model, decimal price, int year)
        : base(internalId, serialNumber, model, price, year){}
    internal static Car Create(string model, int year, decimal price)
    {
        return new Car(model, year, price);
    }
}