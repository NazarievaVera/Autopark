namespace Car_Dealership.Models;

public class Truck : Info
{
    public Truck(string model, int year,decimal price) : base(model, year,price, VehicleType.Truck){}
}
