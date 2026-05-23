using System.Text.Json.Serialization;
namespace Car_Dealership.Models;

public class Truck : Info
{
    public override VehicleType Type => VehicleType.Truck;
    public Truck(string model, int year,decimal price) : base(model, year,price){}
    
    [JsonConstructor]
    public Truck(string internalId, int serialNumber, string model, decimal price, int year) 
        : base(internalId, serialNumber, model, price, year) { }
}
