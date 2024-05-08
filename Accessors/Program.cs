internal class Program
{
    static void Main(string[] args)
    {
        Car car = new Car();
        car.Make = "Audi";
        Console.WriteLine(car.Make);

        car = new Car("Lexus");
        Console.WriteLine(car.Make);

        Console.Write("Enter model: ");
        string model = Console.ReadLine();
        car = new Car(model);
        Console.WriteLine(car.Make);
        
        Console.ReadLine();
    }
}

internal class Car
{
    private string make = "";

    public string Make { get => make; set => make = value; }

    public Car()
    {
        Console.WriteLine("New car created");
    }

    public Car(string carMake)
    {
        make = carMake;
        Console.WriteLine($"New {make} car created");
    }
}