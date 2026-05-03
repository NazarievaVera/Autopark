namespace Car_Dealership.Models;

public class Truck : VihicleBase
{
    public override VehicleType Type => VehicleType.Truck;
    public Truck(Guid id, string model, int year,double price) : base(id, model, year, price){}
}