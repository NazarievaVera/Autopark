using Car_Dealership.Models;
using NLog;
namespace Car_Dealership;

//Деньги и тачки
public partial class AutoPark
{
    private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    
    private List<Info> _vehicles;
    private decimal _balance;

    public AutoPark(decimal balance)
    {
        _vehicles = new List<Info>();
        _balance = balance;
        
        logger.Info($"Создан новый автопарк с начальным балансом: {_balance:N0} руб.");
    }

    public decimal Balance => _balance; // чтобы посмотреть•
    public List<Info> Vehicles => _vehicles; // для чтения списка в файл

    public void LoadData(List<Info> vehicles, decimal balance)
    {
        logger.Info($"Загрузка данных в автопарк: {vehicles.Count} машин, баланс: {balance:N0} руб.");
        _vehicles = vehicles;
        _balance = balance;
        
        logger.Info($" Данные успешно загружены в автопарк. Текущее состояние: {_vehicles.Count} машин, баланс: {_balance:N0} руб.");
    }
}