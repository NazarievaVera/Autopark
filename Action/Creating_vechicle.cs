using Car_Dealership.Models;

namespace Car_Dealership;

public static class Creating_vechicle
{
    private static readonly Random _random = new Random();

    public static Info GenerateRandomVehicle()
    {
        int chance = _random.Next(0, 100);

        return chance switch
        {
            < 40 => GenerateRandomCar(),
            < 70 => GenerateRandomTruck(),
            _ => GenerateRandomBus()
        };
    }

    public static Car GenerateRandomCar()
    {
        string model = Car.Models[_random.Next(Car.Models.Length)];
        int price = _random.Next(Car.PriceRange.min, Car.PriceRange.max + 1);
        int year = _random.Next(2015, 2027);

        return Car.Create(model, year, price);
    }
    public static Bus GenerateRandomBus()
    {
        string model = Bus.Models[_random.Next(Bus.Models.Length)];
        int price = _random.Next(Bus.PriceRange.min, Bus.PriceRange.max + 1);
        int year = _random.Next(2012, 2027);
        int passengers = _random.Next(20, 80);

        return Bus.Create(model, year, price, passengers);
    }
    public static Truck GenerateRandomTruck()
    {
        string model = Truck.Models[_random.Next(Truck.Models.Length)];
        int price = _random.Next(Truck.PriceRange.min, Truck.PriceRange.max + 1);
        int year = _random.Next(2010, 2027);
        int capacity = _random.Next(5, 40);

        return Truck.Create(model, year, price, capacity);
    }

}