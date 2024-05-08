internal class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter the size of array: ");
        Algorithm myAlgorithm = new Algorithm(int.Parse(Console.ReadLine()));
        myAlgorithm.Display();

        Console.ReadLine();
    }
}

public class Algorithm
{
    public int[] myNumbers;

    public Algorithm(int sizeOfArray)
    {
        Random random = new Random();

        // dictates the size of the array
        myNumbers = new int[sizeOfArray];

        for (int i = 0; i < sizeOfArray; i++)
        {
            // random number is generated
            int randomNumber = random.Next();
            // the array populated
            myNumbers[i] = randomNumber;
        }
    }

    public void Display()
    {
        for (int i = 0; i < myNumbers.Length; i++)
        {
            Console.WriteLine($"The value of index {i} is {myNumbers[i]}.");
        }
    }
}