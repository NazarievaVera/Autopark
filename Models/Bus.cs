namespace Car_Dealership.Models;

public class Bus : VihicleBase
{
    public override VehicleType Type => VehicleType.Bus;
    
    public Bus(Guid id, string model, int year,double price) : base(id, model, year,price){}
}