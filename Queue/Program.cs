using System.Collections;
using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {
        MyQueue myQueue = new MyQueue();

        // Array of customers and their corresponding processing time
        String[] customers = { "Tradesman Joe", "Dr Windy Pops", "Grandpa Bob", "Billy the kid", "Chris on crutches" };
        int[] processingTime = { 5, 2, 8, 3, 6 };

        Console.WriteLine("Welcome to KiwiBank!\n");
        Console.WriteLine("Select 3 customers to be processed from below.");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"{i + 1}. {customers[i]} - {processingTime[i]} seconds processing time.");
        }

        Console.WriteLine();


        for (int i = 1; i <= 3; i++)
        {
            Console.Write($"Enter customer id ({i}/3): ");
            int indexOfCustomer = int.Parse(Console.ReadLine()) - 1;
            // Add customer name and processing time to queue
            myQueue.Enqueue(customers[indexOfCustomer]);
            myQueue.Enqueue(processingTime[indexOfCustomer]);
        }

        StartProcessing(myQueue);

        Console.ReadLine();
    }

    static void StartProcessing(MyQueue myQueue)
    {
        bool billyTheKidGotHisID = false;

        // First queue is customer's name then its processing time
        String customer = (String)myQueue.Dequeue();

        while (customer != null)
        {
            int processingTime = (int)myQueue.Dequeue();

            Console.WriteLine();
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"* {customer} has arrived at the teller *");
            Console.WriteLine();
            Console.WriteLine("Teller: Can I see your identification please?");

            if (customer == "Billy the kid" && billyTheKidGotHisID == false)
            {
                Console.WriteLine($"{customer}: Oh no! I forgot my ID in the car. I'll go get it and wait in line again! :(");
                Console.WriteLine("Teller: OK.");

                // Add billy back to the queue
                myQueue.Enqueue(customer);
                myQueue.Enqueue(processingTime);
                billyTheKidGotHisID = true;
            }
            else
            {
                Console.WriteLine($"{customer}: Here ya go!");
                Console.WriteLine("Teller: Please wait while I check your credentials...");

                Wait(processingTime);

                Console.WriteLine();
                Console.WriteLine($"* {processingTime} seconds later *");
                Console.WriteLine();

                Console.WriteLine("Teller: Done!");
            }

            // Get next customer
            customer = (String)myQueue.Dequeue();
        }
    }

    static void Wait(int seconds)
    {
        // Code from https://stackoverflow.com/questions/91108/how-do-i-get-my-c-sharp-program-to-sleep-for-50-milliseconds
        Stopwatch stopwatch = Stopwatch.StartNew();
        while (true)
        {
            int millisecondsToWait = seconds * 1000;
            if (stopwatch.ElapsedMilliseconds >= millisecondsToWait)
            {
                break;
            }
            Thread.Sleep(1);
        }
    }
}

class MyQueue
{
    private ArrayList ALQueue;

    public MyQueue()
    {
        ALQueue = new ArrayList();
    }

    public void Enqueue(object obj)
    {
        ALQueue.Add(obj);
    }

    public object Dequeue()
    {
        // Return null if arraylist is empty
        if (ALQueue.Count == 0) return null;

        object obj = ALQueue[0];
        ALQueue.RemoveAt(0);
        return obj;
    }
}
