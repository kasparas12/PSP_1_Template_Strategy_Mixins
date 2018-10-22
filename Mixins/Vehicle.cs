using System;

namespace Mixins
{
    public enum Fuel
    {
        Gasoline,
        Gas,
        Diesel,
        Electric,
        Hybrid
    }
    public class Vehicle
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string RegistrationCountry { get; set; }
        public Fuel FuelType { get; set; }
        public int Run { get; set; }
        public DateTime CheckUpDate { get; set; }

        public Vehicle(string brand, string model, int year, int price, Fuel fuel, int run, DateTime checkUpDate)
        {
            Brand = brand;
            Model = model;
            Year = year;
            Price = price;
            FuelType = fuel;
            Run = run;
            CheckUpDate = checkUpDate;
        }

        public bool IsCheckUpValid()
        {
            return (DateTime.Today - CheckUpDate).TotalDays / 365 <= 2;
        }
    }
}
