using Car_Dealership.Models;
using System.Threading;
namespace Car_Dealership
{
    public abstract class Info
    {
        public string InternalId { get; }
        public int SerialNumber { get; set; }
        public string Model { get; }
        public VehicleType Type { get; }
        public decimal Price { get; }
        public int Year { get; }
        
        private static int _nextSerialNumber = 0; //счетчик
 
        public Info(string model, int year,decimal price, VehicleType type)
        {
            InternalId = Guid.NewGuid().ToString();
            SerialNumber = Interlocked.Increment(ref _nextSerialNumber);
            Model = model;
            Price = price;
            Year = year;
            Type = type;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"№: {SerialNumber} {Type.GetTypeName()} | {Model} ({Year} г.) | Цена: {Price}");
            
        }
        public bool MatchesInternalId(string id) => InternalId == id; // Для поиска по id
    
    }
    public class Car:Info
    {
      public Car(string model, int year,decimal price) : base( model, year,price,VehicleType.Car){}
    }

    public class Bus : Info
    {
        public Bus(string model, int year,decimal price) : base( model, year,price,VehicleType.Bus){}
    }

    public class Truck : Info
    {
        public Truck(string model, int year,decimal price) : base(model, year,price, VehicleType.Truck){}
    }
    
    //Деньги и тачки
    public class AutoPark
    {   
        private List<Info> Vehicles;
        private decimal _balance;

        public AutoPark(decimal balance)
        {
            Vehicles = new List<Info>();
            _balance = balance;
        }
        public decimal Balance => _balance; // чтобы посмотреть

        public void InitCar()
        {   // Легковые
            var car1 = new Car("Toyota Camry", 2021, 8000000);
            var car2 = new Car( "Kia Rio", 2022, 1200000);
            var car3 = new Car( "BMW X5", 2020, 4500000);
            
            // Автобусы 
            var bus1 = new Bus( "LiAZ-5292", 2019, 600000);
            var bus2 = new Bus( "Mercedes Sprinter", 2021, 3500000);

            // Грузовики
            var truck1 = new Truck("Kamaz-6520", 2018, 5000000);
            var truck2 = new Truck( "Volvo FH", 2022, 9000000);
            
            Vehicles.Add(car1);
            Vehicles.Add(car2);
            Vehicles.Add(car3);
            Vehicles.Add(bus1);
            Vehicles.Add(bus2);
            Vehicles.Add(truck1);
            Vehicles.Add(truck2);
        }
        
        // Покупка
        public void Add(Info info)
        {
            // если хотябы 1 совпадает
            if (Vehicles.Any(v => v.InternalId == info.InternalId))
            {
                Console.WriteLine($"Машина с системным ID {info.InternalId} уже в автопарке. ");
                return;
            }

            if (_balance >= info.Price)
            {
                _balance -= info.Price;
                Vehicles.Add(info);
                Console.WriteLine($"№ {info.SerialNumber} {info.Model} добавлена в гараж. Остаток {_balance} руб.");
            }
            else
            {
                Console.WriteLine($"Недостаточно средств.Остаток {_balance} руб.");
            }
        }

        public void Delete(int serialNumber)
        {
            var info = Vehicles.FirstOrDefault(c =>c.SerialNumber == serialNumber);
            if (info != null)
            { 
                _balance += info.Price;
                Vehicles.Remove(info);
                
                //перенумеровываем
                for (int i = 0; i < Vehicles.Count; i++)
                {
                    Vehicles[i].SerialNumber = i + 1;
                }
                Console.WriteLine($"Успешно продано: {info.Model}. Баланс: {_balance} руб.");
            }
            else
            {
                Console.WriteLine($"Машина под номером {serialNumber} не найдена");
            }
        }
        
        // Просмотр
        public void Print()
        {
            Console.WriteLine("Ваш автопарк");
            if (Vehicles.Count == 0)
            {
                Console.WriteLine("Пусто.");
            }
            else
            {
                foreach (var c in Vehicles)
                {
                    c.DisplayInfo();
                }
            }
 
            Console.WriteLine($"Баланс: {_balance} руб.");
        }
    }
};