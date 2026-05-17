namespace Car_Dealership.Models;

public static class VehicleTypeExtensions
{
    public static string GetTypeName(this VehicleType type) => type switch
    {
        VehicleType.Car=> "Легковая",
        VehicleType.Bus => "Автобус",
        VehicleType.Truck => "Грузовик",
        _ => "Неизвестно"
    };
}