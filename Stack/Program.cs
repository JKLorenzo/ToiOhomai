internal class Program
{
    static void Main(string[] args)
    {
        // Sequence 1
        decodeSequence("N * O I * * T S * E * U * Q Y * * S A E");

        // Sequence 2
        decodeSequence("T U * * O T S * * R I * * F N * I T * S A * * L");

        // Sequence 3
        decodeSequence("W * O R * R O * O M 2 O * T *");

        // Sequence 4
        decodeSequence("U O Y * * E E * * C S * I");


        Console.ReadLine();
    }

    static void decodeSequence(String sequence)
    {
        Console.WriteLine($"Sequence: {sequence}");

        // Push or Pop based on the value
        Stack<String> stack = new Stack<String>();
        foreach (String str in sequence.Split(' '))
        {
            if (str == "*")
            {
                stack.Pop();
            }
            else
            {
                stack.Push(str);
            }
        }

        // Print stack
        Console.Write($"Sequence Output: ");
        foreach (String str in stack)
        {
            Console.Write(str);
        }
        Console.WriteLine("\n");
    }
}