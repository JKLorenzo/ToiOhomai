internal class Program
{
    public static void Main(string[] args)
    {
        var p = new Algorithm(10000);
        p.Display();

        var occurenceResult = p.NumOccurenceSearch(128, 2);
        if (occurenceResult < 0)
        {
            Console.WriteLine($"doesnt exist");
        }
        else
        {
            Console.WriteLine($"found the 2 occurence of 128 at index [{occurenceResult}]");
        }
        Console.ReadKey();
    }
}

internal class Algorithm
{
    public int[] numbers;

    public Algorithm(int num)
    {
        var randomDigit = new Random();
        numbers = new int[num];

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

    /**
     * num - the value we are searching
     * n - the nth occurence of the num value we are searching
    **/
    public int NumOccurenceSearch(int num, int n)
    {
        // set initial value (no occurence)
        var occurence = 0;

        // iterate loop
        for (int i = 0; i < numbers.Length; i++)
        {
            // check if current index has the value that we are searching
            if (numbers[i] == num)
            {
                // increment occurence value
                occurence++;

                // check if the current occurence is the nth occurence
                if (occurence == n)
                {
                    // return the current index
                    return i;
                }
            }
        }

        // nth occurence not found
        return -1;
    }
}