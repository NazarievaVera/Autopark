namespace Car_Dealership.Models;

public class Bus : Info
{
    public Bus(string model, int year,decimal price) : base( model, year,price,VehicleType.Bus){}
}