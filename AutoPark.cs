using Car_Dealership.Models;

namespace Car_Dealership;

//Деньги и тачки
public partial class AutoPark
{
    private List<Info> _vehicles;
    private decimal _balance;

    public AutoPark(decimal balance)
    {
        _vehicles = new List<Info>();
        _balance = balance;
    }

    public decimal Balance => _balance; // чтобы посмотреть
    public List<Info> Vehicles => _vehicles; // для чтения списка в файл

    public void LoadData(List<Info> vehicles, decimal balance)
    {
        _vehicles = vehicles;
        _balance = balance;
    }
}