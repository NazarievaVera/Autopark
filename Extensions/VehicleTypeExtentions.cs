using Car_Dealership.Models;

namespace Car_Dealership.Extensions;

public static class VehicleTypeExtensions
{
    public static string VehicleTypeToString(this VehicleType vehicleType)
    {
        return vehicleType switch
        {
            VehicleType.Car => "Легковая",
            VehicleType.Bus => "Автобус",
            _ => "Неизвестный"
        };
    }
}