using System.Text.Json.Serialization;
namespace Car_Dealership.Models;

public class Bus : Info
{
    public override VehicleType Type => VehicleType.Bus;
    public Bus(string model, int year,decimal price) : base( model, year,price){}
    
    [JsonConstructor]
    public Bus(string internalId, int serialNumber, string model, decimal price, int year) 
        : base(internalId, serialNumber, model, price, year) { }
}