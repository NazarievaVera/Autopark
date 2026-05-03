namespace Car_Dealership.Models;

public class Car : VihicleBase
{
    public override VehicleType Type => VehicleType.Car;
    
    public Car(Guid id, string model, int year, double price) : base(id, model, year, price)
    {
    }
}