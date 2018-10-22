namespace Mixins
{
    public enum Gender
    {
        Male,
        Female
    }
    public class Employee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Position { get; set; }
        public Gender Gender { get; set; }
        public int Age { get; set; }
        public string Nationality { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, string surname, string position, Gender gender, int age, decimal salary)
        {
            Name = name;
            Surname = surname;
            Position = position;
            Gender = gender;
            Age = age;
            Salary = salary;
        }

        public string GenerateReport()
        {
            return $"This is report about employee {Name} {Surname}, position - {Position}, " +
                $"who is {Gender} and {Age} years old and currently gets {Salary} per month ";
        }

    }
}
