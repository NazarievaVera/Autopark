using System.Text.Json.Serialization;
namespace Car_Dealership.Models;

public class Car:Info
{ 
    public override VehicleType Type => VehicleType.Car;
    public Car(string model, int year,decimal price) : base( model, year,price){}
    
    [JsonConstructor]
    public Car(string internalId, int serialNumber, string model, decimal price, int year) 
        : base(internalId, serialNumber, model, price, year) { }
}

