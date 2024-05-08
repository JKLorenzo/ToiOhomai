internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("How many numbers would you like to generate? ");
        int userInput = int.Parse(Console.ReadLine());

        RandomNumberGenerator rng = new RandomNumberGenerator(userInput);
        rng.Display();

        Console.ReadLine();
    }
}

class RandomNumberGenerator
{
    public int[] numbers { get; set; }

    public RandomNumberGenerator(int size)
    {
        Random random = new Random();

        numbers = new int[size];
        for (int i = 0; i < size; i++)
        {
            numbers[i] = random.Next();
        }
    }

    public void Display()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"{numbers[i]} ");
        }
    }
}