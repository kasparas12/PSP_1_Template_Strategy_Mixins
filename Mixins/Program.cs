using System;

namespace Mixins
{
    class Program
    {
        static void Main(string[] args)
        {
            var vehicle = new VehicleExtended("Toyota", "Avensis", 2008, 9000, Fuel.Diesel, 100000, DateTime.Parse("2017-05-04")
                        , new LithuaniaIncomeTaxCalculator(), new LTEUAgeEvaluator(), new FromDollarsToEurConverter());

            var employee = new EmployeeExtended("John", "Doe", "Manager", Gender.Male, 28, 3000
                        , new PolandIncomeTaxCalculator(), new CROEUCriteriaEvaluator(), new FromEurToDollarsConverter());

            var realEstate = new RealEstateExtended("Villa Croatia", 2000000, 5, "Croatia", 25, 20
                        , new LithuaniaIncomeTaxCalculator(), new CROEUCriteriaEvaluator(), new FromEurToDollarsConverter());

            Console.WriteLine($"Check-up for this car is valid? {vehicle.IsCheckUpValid()}");
            Console.WriteLine($"Income tax from this car in LT: {vehicle.CalculateTaxes(vehicle.Price)}");
            Console.WriteLine($"Car costs {vehicle.Price} dollars, equivalent in {vehicle.ConvertCurrency((double)vehicle.Price)} EUR");
            Console.WriteLine($"This car was made after LT joined EU? {vehicle.IsEUCriteriaMatched(vehicle.Year)}");

            Console.WriteLine();

            Console.WriteLine(employee.GenerateReport());
            Console.WriteLine($"Income tax from salary: {employee.CalculateTaxes(employee.Salary)}");
            Console.WriteLine($"{employee.Name} earns {employee.Salary} EUR, equivalent in {employee.ConvertCurrency((double)employee.Salary)} USD");
            Console.WriteLine($"{employee.Name} was born after CRO joined EU? {employee.IsEUCriteriaMatched((DateTime.Today.Year - employee.Age))}");

            Console.WriteLine();

            Console.WriteLine($"Real estate name: {realEstate.Name}, price per square meter: {realEstate.CalculatePricePerSquareMeter()}");
            Console.WriteLine($"Income tax from this real estate in PL: {realEstate.CalculateTaxes(realEstate.Price)}");
            Console.WriteLine($"Object costs {realEstate.Price} EUR, equivalent in {realEstate.ConvertCurrency((double)realEstate.Price)} USD");
            Console.WriteLine($"This object was build after CRO joined EU? {realEstate.IsEUCriteriaMatched(realEstate.Age)}");


        }
    }
}
