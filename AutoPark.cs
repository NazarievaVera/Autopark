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

    public void InitCar()
    {
        bool isLoaded = Save_file.Load(this, "save.json");
        if (!isLoaded)
        {
            Console.WriteLine("Сохранение не найдено. Создаем новый автопарк...");
            // Легковые
            _vehicles.Add(new Car("Toyota Camry", 2021, 8000000));
            _vehicles.Add(new Car("Kia Rio", 2022, 1200000));
            _vehicles.Add(new Car("BMW X5", 2020, 4500000));
            // Автобусы
            _vehicles.Add(new Bus("LiAZ-5292", 2019, 600000));
            _vehicles.Add(new Bus("Mercedes Sprinter", 2021, 3500000));
            // Грузовики
            _vehicles.Add(new Truck("Kamaz-6520", 2018, 5000000));
            _vehicles.Add(new Truck("Volvo FH", 2022, 9000000));
        }
    }
}