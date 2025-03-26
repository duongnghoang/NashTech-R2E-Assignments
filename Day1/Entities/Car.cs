namespace Day1.Entities
{
    public class Car
    {
        public Car(string make, string model, int year, CarType type)
        {
            Make = make;
            Model = model;
            Year = year;
            Type = type;
        }
        public Car() { }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; }
        public CarType Type { get; set; }
        public override string ToString()
        {
            return $"Make: {Make}, Model: {Model}, Year: {Year}, Type: {Type}";
        }
    }

    public enum CarType
    {
        Electric,
        Fuel,
    }
}
