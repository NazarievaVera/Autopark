namespace Car_Dealership.Models;

public abstract class VihicleBase
{
    public Guid Id { get; } 
    public string Model { get; }
    public abstract VehicleType Type { get; }
    public double Price { get; }
    public int Year { get; }
 
    public VihicleBase(Guid id,string model, int year,double price)
    {
        Id = id;
        Model = model;
        Price = price;
        Year = year;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"ID: {Id} ,{Type} | {Model} ({Year} г.) | Цена: {Price}");
    }
}