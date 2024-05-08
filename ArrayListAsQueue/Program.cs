using System.Collections;

internal class Program
{
    static void Main(string[] args)
    {
        MyQueue myQueue = new MyQueue();
        myQueue.Enqueue("a");
        myQueue.Enqueue("b");
        myQueue.Enqueue("c");
        myQueue.Enqueue("d");

        Console.WriteLine(myQueue.Dequeue());
        Console.WriteLine(myQueue.Dequeue());
        Console.WriteLine(myQueue.Dequeue());
        Console.WriteLine(myQueue.Dequeue());

        Console.ReadLine();
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