internal class Program
{
    private static void Main(string[] args)
    {
        var myCustomNum = new MyCustomNumber();
        myCustomNum.displayValue();

        myCustomNum = new MyCustomNumber(1000);
        myCustomNum.displayValue();
    }
}

public class MyCustomNumber
{
    public int Value { get; set; }

    public MyCustomNumber()
    {
        this.Value = 1;
    }

    public MyCustomNumber(int value)
    {
        this.Value = value;
    }

    public void displayValue()
    {
        Console.WriteLine($"Value is {this.Value}");
    }
}