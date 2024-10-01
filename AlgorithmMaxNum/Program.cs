internal class Program
{
    public static void Main(string[] args)
    {
        Console.Write("enter # of array: ");
        int num = int.Parse(Console.ReadLine());

        Algorithm algorithm = new Algorithm(num);

        algorithm.Display();
        Console.Write("Enter no. of elements u want: ");
        int n = int.Parse(Console.ReadLine());

        algorithm.FindNumMax(n);
    }
}

internal class Algorithm
{
    private int[] numbers;

    public Algorithm(int num)
    {
        numbers = new int[num];
        var randomDigit = new Random();

        for (int i = 0; i < num; i++)
        {
            int r = randomDigit.Next(100, 1000);
            numbers[i] = r;
        }
    }

    public void Display()
    {
        Console.WriteLine("results of algo");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.WriteLine(numbers[i]);
        }
    }

    public void FindNumMax(int n)
    {

        if (n > numbers.Length)
        {
            Console.WriteLine($"try again, < {numbers.Length}");
            return;
        }

        int[] topNum = new int[n];
        for (int i = 0; i < n; i++)
        {
            topNum[i] = 0;
        }

        foreach (int num in numbers)
        {
            for (int i = 0; i < n; i++)
            {
                if (topNum[i] < num)
                {
                    int temp = topNum[i];
                    topNum[i] = num;

                    for (int j = i + 1; j < n; j++)
                    {
                        topNum[j] = temp;

                        if (j + 1 < n)
                        {
                            temp = topNum[j + 1];
                        }
                    }
                    break;
                }
            }
        }

        foreach (int num in topNum)
        {
            Console.WriteLine(num);
        }
    }
}