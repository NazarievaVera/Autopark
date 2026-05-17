using Car_Dealership.Models;
namespace Car_Dealership
{
    public abstract class Info
    {
        public string Id { get; } 
        public string Model { get; }
        public VehicleType Type { get; }
        public decimal Price { get; }
        public int Year { get; }
 
        public Info(string id,string model, int year,decimal price, VehicleType type)
        {
            Id = id;
            Model = model;
            Price = price;
            Year = year;
            Type = type;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id} ,{Type.GetTypeName()} | {Model} ({Year} г.) | Цена: {Price}");
        }
    }
    public class Car:Info
    {
      public Car(string id, string model, int year,decimal price) : base(id, model, year,price,VehicleType.Car){}
    }

    public class Bus : Info
    {
        public Bus(string id, string model, int year,decimal price) : base(id, model, year,price,VehicleType.Bus){}
    }

    public class Truck : Info
    {
        public Truck(string id, string model, int year,decimal price) : base(id, model, year,price, VehicleType.Truck){}
    }
    
    //Деньги и тачки
    public class AutoPark
    {   
        private List<Info> _fleets;
        private decimal _balance;

        public AutoPark(decimal balance)
        {
            _fleets = new List<Info>();
            _balance = balance;
        }
        public decimal Balance => _balance; // чтобы посмотреть

        public void InitCar()
        {   // Легковые
            var car1 = new Car("C001", "Toyota Camry", 2021, 8000000);
            var car2 = new Car("C002", "Kia Rio", 2022, 1200000);
            var car3 = new Car("C003", "BMW X5", 2020, 4500000);

            // Автобусы 
            var bus1 = new Bus("B001", "LiAZ-5292", 2019, 600000);
            var bus2 = new Bus("B002", "Mercedes Sprinter", 2021, 3500000);

            // Грузовики
            var truck1 = new Truck("T001", "Kamaz-6520", 2018, 5000000);
            var truck2 = new Truck("T002", "Volvo FH", 2022, 9000000);
            
            _fleets.Add(car1);
            _fleets.Add(car2);
            _fleets.Add(car3);
            _fleets.Add(bus1);
            _fleets.Add(bus2);
            _fleets.Add(truck1);
            _fleets.Add(truck2);
        }
        
        // Покупка
        public void Add(Info info)
        {
            if (_balance >= info.Price)
            {
                _balance -= info.Price;
                _fleets.Add(info);
                Console.WriteLine($"Машина {info.Model} добавлена в гараж. Остаток {_balance} руб.");
            }
            else
            {
                Console.WriteLine($"Недостаточно средств.Остаток {_balance} руб.");
            }
        }

        public void Delete(string id)
        {
            var info = _fleets.FirstOrDefault(с => с.Id == id);
            if (info != null)
            { 
                _balance += info.Price;
                _fleets.Remove(info);
                Console.WriteLine($"Успешно продано: {info.Model}. Баланс: {_balance} руб.");
            }
            else
            {
                Console.WriteLine("Машина не найдена");
            }
        }
        
        // Просмотр
        public void Print()
        {
            Console.WriteLine("Ваш автопарк");
            if (_fleets.Count == 0)
            {
                Console.WriteLine("Пусто.");
            }
            else
            {
                foreach (var c in _fleets)
                {
                    c.DisplayInfo();
                }
            }
 
            Console.WriteLine($"Баланс: {_balance} руб.");
        }
    }
};