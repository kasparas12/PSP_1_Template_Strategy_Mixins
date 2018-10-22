namespace Mixins
{
    public class RealEstate
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Age { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string Location { get; set; }

        public RealEstate(string name, decimal price, int age, string location, int width, int height)
        {
            Name = name;
            Price = price;
            Age = age;
            Location = location;
            Width = width;
            Height = height;
        }

        public decimal CalculatePricePerSquareMeter()
        {
            return Price / GetArea();
        }

        public int GetArea()
        {
            return Width * Height;
        }
    }
}
