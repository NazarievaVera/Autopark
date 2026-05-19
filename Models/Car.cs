namespace Car_Dealership.Models;

public class Car:Info
{ 
    public Car(string model, int year,decimal price) : base( model, year,price,VehicleType.Car){}
}

