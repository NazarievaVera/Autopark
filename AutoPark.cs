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
            
            _vehicles.Add(car1);
            _vehicles.Add(car2);
            _vehicles.Add(car3);
            _vehicles.Add(bus1);
            _vehicles.Add(bus2);
            _vehicles.Add(truck1);
            _vehicles.Add(truck2);
        }
  
}